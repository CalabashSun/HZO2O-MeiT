using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Dapper.Contrib.Extensions;
using MeituanApi.Core;
using MeituanApi.Data.DataBase;
using MeituanApi.Data.External.Receive;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{
    public interface IOrderToZpService : IRepository<MeiTOrder_ZpOrder>
    {
         void HandleToZp(OrderPayed model, List<OrderProduct> products);
    }


    public class OrderToZpService : Repository<MeiTOrder_ZpOrder>, IOrderToZpService
    {
        private readonly IMeiTConfigService _meiTConfigService;
        private readonly IMeiTProductInfoService _meiTProductInfoService;

        public OrderToZpService(IMeiTConfigService meiTConfigService
        ,IMeiTProductInfoService meiTProductInfoService)
        {
            _meiTConfigService = meiTConfigService;
            _meiTProductInfoService = meiTProductInfoService;
        }

        public async void HandleToZp(OrderPayed model, List<OrderProduct> products)
        {
            var configInfo = _meiTConfigService.GetMeiTConfigByShopId(model.app_poi_code);
            if (configInfo != null && !string.IsNullOrEmpty(configInfo.Zp_ShopId))
            {
                //获取当前门店的菜品
                var cpList = _meiTProductInfoService.ListProductInfo(model.app_poi_code);
                if (cpList == null || cpList.Count == 0)
                {
                    return;
                }

                var insertData = new MeiTOrder_ZpOrder
                {
                    OrderId = model.order_id,
                    CQ_KT_DC_TH = "自结美团",
                    Bas_text = "自结外卖",
                    People = model.dinners_number,
                    Cope = model.total,
                    TotalPrice = model.original_price - model.shipping_fee,
                    Ptdjh = "#" + model.day_seq + "美团外卖",
                    door_id = configInfo.Zp_ShopId,
                    door_name = configInfo.Zp_ShopName,
                    WM_PT = "MT",         
                };
                if (model.delivery_time != 0)
                {
                    insertData.DeliverTime = CommonHelper.GenericTimeStamp(model.delivery_time);
                }

                if (products != null && products.Count > 0)
                {
                    var zpCp = "";
                    foreach (var orderProduct in products)
                    {
                        var cpInfo = cpList.FirstOrDefault(p => p.ProductName == orderProduct.food_name);
                        if (cpInfo == null || string.IsNullOrEmpty(cpInfo.Zp_ProductId))
                        {
                            continue;
                        }
                        else
                        {
                            zpCp += "<" + cpInfo.Zp_ProductId + "^" + orderProduct.quantity + "^" +
                                    orderProduct.food_property
                                    + '^' + orderProduct.price.ToString("0.00") + ">";
                        }
                    }
                    //计算餐盒费
                    var boxPrice = products.Sum(p => p.box_num * p.box_price);
                    zpCp += "<990103^" + boxPrice + "^^1.00>";
                    insertData.Eat_BM_CP = zpCp;
                    insertData.Eat_allremark =ZpOrderRemark(model.day_seq, WebUtility.UrlDecode(model.caution));
                }

                try
                {
                    //将结果插入数据库
                    await _Conn.InsertAsync(insertData);
                }
                catch
                {
                    //直接抛掉错误
                    throw;
                }

            }




        }


        public string ZpOrderRemark(int daySeq, string remark)
        {
            var connectString = "#" + daySeq + "美团外卖," + remark;
            return SubComment(connectString, 80);
        }


        public static string SubComment(string original, int width)
        {
            int len = original.Length;
            if (len < width)
                return original;
            int clen = 0;//当前长度 
            int cwidth = 0;//当前宽度 
            while (clen < len && cwidth < width)
            {
                if ((int)original[clen] > 128)
                    cwidth++;
                clen++;
                cwidth++;
            }
            return original.Substring(0, clen);
        }

    }
}
