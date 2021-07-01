using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeituanApi.Core;
using MeituanApi.Core.Enums;
using MeituanApi.Data.DataBase;
using MeituanApi.Data.External.Receive;
using MeituanApi.Services.DataServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeituanApi.Web.Controllers
{
    public class HandlePriceController : Controller
    {
        private readonly IMeiTOrderLogService _orderLogService;
        private readonly IMeiTOrderPriceService _meiTOrderPriceService;


        public HandlePriceController(IMeiTOrderLogService meiTOrderLogService,
            IMeiTOrderPriceService meiTOrderPriceService)
        {
            _orderLogService = meiTOrderLogService;
            _meiTOrderPriceService = meiTOrderPriceService;
        }

        public IActionResult Index()
        {
            var logList = _orderLogService.GetOrderLogs();
            if (logList != null && logList.Count > 0)
            {
                var cancelOrders = _orderLogService.GetCancelOrder();
                foreach (var meiTOrderLog in logList)
                {
                    //解析json
                    var orderDetail = JsonConvert.DeserializeObject<DesOrderPayed>(meiTOrderLog.OrderContext);
                    var orderPrice = new MeiTPriceInfo
                    {
                        ShopId = orderDetail.app_poi_code,
                        ShopName = orderDetail.wm_poi_name,
                        OrderId = orderDetail.order_id.ToString(),
                        DaySeq = orderDetail.day_seq,
                        Total = orderDetail.total,
                        ActualTotal = orderDetail.original_price - orderDetail.shipping_fee,
                        OriginalPrice = orderDetail.original_price,
                        IsCanceled = cancelOrders.Where(p => p.OrderId == orderDetail.order_id).Count() > 0,
                        CreatedAt = CommonHelper.GenericTimeStamp(orderDetail.ctime)
                    };
                    var priceDetail = JsonConvert.DeserializeObject<PoiReceiveDetail>(meiTOrderLog.OrderPoiReceiveDetail);
                    orderPrice.ActualReceive = decimal.Round((decimal)priceDetail.wmPoiReceiveCent / 100, 2);
                    orderPrice.ServiceFee = decimal.Round((decimal)priceDetail.foodShareFeeChargeByPoi / 100, 2);
                    //计算商家承担成本
                    decimal poiCost = 0;
                    if (priceDetail.actOrderChargeByPoi != null && priceDetail.actOrderChargeByPoi.Count > 0)
                    {
                        foreach (var poiDetail in priceDetail.actOrderChargeByPoi)
                        {
                            poiCost += decimal.Round((decimal)poiDetail.moneyCent / 100, 2);
                        }
                    }

                    orderPrice.DiscountAmount = poiCost;
                    orderPrice.CreateTime=DateTime.Now;
                    _meiTOrderPriceService.Add(orderPrice);
                }
            }
            _orderLogService.SetHandeled();
            return Content("success");
        }
    }
}