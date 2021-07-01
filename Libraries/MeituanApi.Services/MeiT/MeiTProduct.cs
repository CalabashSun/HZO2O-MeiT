using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using MeituanApi.Core.Configuration;
using MeituanApi.Core.Helper;
using MeituanApi.Data.External.Response;
using MeituanApi.Data.External.Submit;
using Newtonsoft.Json;

namespace MeituanApi.Data.MeiT
{
    public class MeiTProduct
    {

        public static string ShopSave(IHttpClientFactory httpFactory,SShopSave info)
        {
            info.sig = SignHelper.Sign<SShopSave>(info, MeiTAction.shopSave);
            var client = httpFactory.CreateClient();
            FormUrlEncodedContent content = new FormUrlEncodedContent(SignHelper.ToDictionary(info));
            var response = client.PostAsync(MeiTAction.shopSave, content).Result.Content.ReadAsStringAsync().Result;
            return response;
        }

        public static RFoodList ProductList(IHttpClientFactory httpFactory, string shopId,string appId="",string appSecret="")
        {
            var foodListModel = new SFoodList
            {
                app_poi_code = shopId,
                offset = 0,
                limit = 199
            };
            if (appId != "" && appSecret != "")
            {
                foodListModel.app_id = appId;
            }

            foodListModel.sig = SignHelper.Sign<SFoodList>(foodListModel,MeiTAction.foodList,null,appSecret);
            var client = httpFactory.CreateClient();
            FormUrlEncodedContent content = new FormUrlEncodedContent(SignHelper.ToDictionary(foodListModel));
            try
            {
                var response = client.PostAsync(MeiTAction.foodList, content).Result.Content.ReadAsStringAsync().Result;
                var productList = JsonConvert.DeserializeObject<RFoodList>(response);
                return productList;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
