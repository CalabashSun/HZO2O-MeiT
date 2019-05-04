using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MeituanApi.Core.Configuration;
using MeituanApi.Core.Helper;
using MeituanApi.Data.External.Response;
using MeituanApi.Data.External.Submit;
using Newtonsoft.Json;

namespace MeituanApi.Services.MeiT
{
    public class MeiTShop
    {
        public static RShopList BindShopInfo(IHttpClientFactory httpFactory)
        {
            var modelInfo = new BaseSubmit();
            modelInfo.sig = SignHelper.Sign<BaseSubmit>(modelInfo, MeiTAction.getShopInfo);
            var client = httpFactory.CreateClient();
            try
            {
                var connectParams = "";
                var commentParams = SignHelper.ToDictionary(modelInfo);
                if (commentParams != null)
                {
                    foreach (var commentParam in commentParams)
                    {
                        connectParams += commentParam.Key + "=" + commentParam.Value + "&";
                    }
                }

                connectParams = connectParams.Substring(0, connectParams.Length - 1);
                var getUrl = MeiTAction.getShopInfo + "?" + connectParams;
                var response = client.GetAsync(getUrl).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<RShopList>(response);
            }
            catch
            {
                return null;
            }
        }

        public static RShopDetails ShopDetailInfo(IHttpClientFactory httpFactory, string appPoiCodes)
        {
            var modelInfo = new SShopDetail
            {
                app_poi_codes = appPoiCodes
            };
            modelInfo.sig = SignHelper.Sign<BaseSubmit>(modelInfo, MeiTAction.getShopDetail);
            var client = httpFactory.CreateClient();
            try
            {
                var connectParams = "";
                var commentParams = SignHelper.ToDictionary(modelInfo);
                if (commentParams != null)
                {
                    foreach (var commentParam in commentParams)
                    {
                        connectParams += commentParam.Key + "=" + commentParam.Value + "&";
                    }
                }

                connectParams = connectParams.Substring(0, connectParams.Length - 1);
                var getUrl = MeiTAction.getShopDetail + "?" + connectParams;
                var response = client.GetAsync(getUrl).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<RShopDetails>(response);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
