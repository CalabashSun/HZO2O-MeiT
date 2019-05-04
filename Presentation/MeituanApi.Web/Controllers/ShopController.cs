using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.DataServices;
using MeituanApi.Services.MeiT;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeituanApi.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMeiTConfigService _meiTConfigService;

        public ShopController(IHttpClientFactory httpClientFactory
        ,IMeiTConfigService meiTConfigService)
        {
            _httpClientFactory = httpClientFactory;
            _meiTConfigService = meiTConfigService;
        }

        public IActionResult Index()
        {
            var returnModels=new Dictionary<string,string>();
            var returnString = "";
            var infos = MeiTShop.BindShopInfo(_httpClientFactory);
            if (infos != null)
            {
                var appCodes = string.Empty;
                foreach (var info in infos.data)
                {
                    appCodes += info + ",";
                }

                appCodes = appCodes.Substring(0, appCodes.Length - 1);

                var shopDetails = MeiTShop.ShopDetailInfo(_httpClientFactory, appCodes);
                foreach (var rShopDetail in shopDetails.data)
                {
                    returnModels.Add(rShopDetail.app_poi_code, rShopDetail.name);
                    //判断是否已经存在门店
                    var exist = _meiTConfigService.GetMeiTConfigByShopId(rShopDetail.app_poi_code);
                    if (exist == null)
                    {
                        //像数据库中插入数据
                        var configBuild = new MeiTConfig
                        {
                            AppKey = "2863",
                            AppSecret = "728e9163c49542ac20c4bf473e731f66",
                            InterUrl = "",
                            Name = rShopDetail.name,
                            ShopId = rShopDetail.app_poi_code,
                            Zp_ShopId = "1",
                            Zp_ShopName = "1"
                        };
                        _meiTConfigService.Add(configBuild);
                    }
                    else
                    {
                        continue;
                    }
                }

                returnString = JsonConvert.SerializeObject(returnModels);
            }

            return Content(returnString);
        }
    }
}