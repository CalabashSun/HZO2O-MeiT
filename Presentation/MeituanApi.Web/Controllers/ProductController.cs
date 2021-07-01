using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MeituanApi.Data.DataBase;
using MeituanApi.Data.External.Response;
using MeituanApi.Data.MeiT;
using MeituanApi.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace MeituanApi.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMeiTConfigService _meiTConfigService;
        private readonly IMeiTProductInfoService _meiTProductInfoService;

        public ProductController(IHttpClientFactory httpClientFactory
            , IMeiTConfigService meiTConfigService
        ,IMeiTProductInfoService meiTProductInfoService)
        {
            _httpClientFactory = httpClientFactory;
            _meiTProductInfoService = meiTProductInfoService;
            _meiTConfigService = meiTConfigService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FoodList(string zpShopId)
        {
            if (string.IsNullOrEmpty(zpShopId))
            {
                return Content("商家的id不存在");
            }
            //此处获取的是正品的shopId
            var shopInfo = _meiTConfigService.GetMeiTConfig(zpShopId);
            if (shopInfo == null)
            {
                return Content("商家的id不能和美团商户匹配");
            }

            var shopId = shopInfo.ShopId;
            var appId = shopInfo.AppKey;
            var appSecret = shopInfo.AppSecret;
            var result = MeiTProduct.ProductList(_httpClientFactory, shopId,appId,appSecret);
            try
            {
                DealShopProduct(result, shopId);
                return Content("数据更新成功");
            }
            catch
            {
                return Content("更新数据失败了联系it处理");
            }
        }

        public IActionResult DealZpProduct(string zpShopId)
        {
            if (string.IsNullOrEmpty(zpShopId))
            {
                return Content("商家的id不存在");
            }
            //此处获取的是正品的shopId
            var shopInfo = _meiTConfigService.GetMeiTConfig(zpShopId);
            if (shopInfo == null)
            {
                return Content("商家的id不能和美团商户匹配");
            }
            return null;
        }



        public IActionResult BatchUpdateProduct()
        {
            var shopList = _meiTConfigService.AllMetTShop();
            try
            {
                foreach (var meiTConfig in shopList)
                {
                    var rsult = MeiTProduct.ProductList(_httpClientFactory, meiTConfig.ShopId);
                    DealShopProduct(rsult, meiTConfig.ShopId);
                }

                return Content("更新成功");
            }
            catch (Exception e)
            {
                return Content("更新数据失败了:"+e.Message);
            }

        }


        private void DealShopProduct(RFoodList result,string shopId)
        {
            if (result?.data != null && result.data.Count > 0)
            {

                var productList = _meiTProductInfoService.ListProductInfo(shopId);
                if (productList != null && productList.Any())
                {
                    foreach (var rFood in result.data)
                    {
                        var exist = productList.FirstOrDefault(p => p.ProductName == rFood.name && p.ShopId == shopId);
                        if (exist != null)
                        {
                            //1.相同
                            if (exist.ProductPrice==rFood.price)
                            {
                                exist.DealState = 1;
                                continue;
                            }
                            //2.数据变更
                            else
                            {
                                //新增数据
                                var productInfo = new MeiTProductInfo
                                {
                                    ShopId = shopId,
                                    CateId = 0,
                                    CateName = rFood.category_name,
                                    ProductId = rFood.app_food_code,
                                    ProductName = rFood.name,
                                    ProductPrice = rFood.price,
                                    UpdateTime = DateTime.Now,
                                    ProductState = 1,
                                    MeiTCreatTime = rFood.ctime,
                                    MeiTUpdateTime = rFood.utime
                                };
                                _meiTProductInfoService.Add(productInfo);

                            }
                        }
                        else//不存在
                        {
                            //新增数据
                            var productInfo = new MeiTProductInfo
                            {
                                ShopId = shopId,
                                CateId = 0,
                                CateName = rFood.category_name,
                                ProductId = rFood.app_food_code,
                                ProductName = rFood.name,
                                ProductPrice = rFood.price,
                                UpdateTime = DateTime.Now,
                                ProductState = 1,
                                MeiTCreatTime = rFood.ctime,
                                MeiTUpdateTime = rFood.utime
                            };
                            _meiTProductInfoService.Add(productInfo);
                        }
                    }
                    //获取删除的数据
                    var deleteFoods = productList.Where(p => p.DealState == 0);
                    foreach (var tempMeiTProductInfo in deleteFoods)
                    {
                        var deleteFood = (MeiTProductInfo)tempMeiTProductInfo;
                        _meiTProductInfoService.Remove(deleteFood);
                    }
                }
                else
                {
                    foreach (var product in result.data)
                    {
                        var productInfo = new MeiTProductInfo
                        {
                            ShopId = shopId,
                            CateId = 0,
                            CateName = product.category_name,
                            ProductId = product.app_food_code,
                            ProductName = product.name,
                            ProductPrice = product.price,
                            UpdateTime = DateTime.Now,
                            ProductState = 1,
                            MeiTCreatTime = product.ctime,
                            MeiTUpdateTime = product.utime
                        };
                        _meiTProductInfoService.Add(productInfo);
                    }
                }
            }
        }
    }
}