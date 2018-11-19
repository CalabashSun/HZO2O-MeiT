using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MeituanApi.Core.Configuration;
using MeituanApi.Core.Helper;
using MeituanApi.Data.DataBase;
using MeituanApi.Data.External.Response;
using MeituanApi.Data.External.Submit;
using Newtonsoft.Json;

namespace MeituanApi.Services.MeiT
{
    public class MeiTOrder
    {
        public static string ConfirmOrder(IHttpClientFactory httpFactory,MeiTOrderInfo orderInfo)
        {
            var confirmOrderModel = new SOrderConfirm
            {
                order_id = orderInfo.OrderId
            };
            confirmOrderModel.sig = SignHelper.Sign<SOrderConfirm>(confirmOrderModel, MeiTAction.orderConfirm);
            var client = httpFactory.CreateClient();
            FormUrlEncodedContent content = new FormUrlEncodedContent(SignHelper.ToDictionary(confirmOrderModel));
            try
            {
                var response = client.PostAsync(MeiTAction.foodList, content).Result.Content.ReadAsStringAsync().Result;
                var confrimReturn = JsonConvert.DeserializeObject<RBaseResponse>(response);
                return confrimReturn.data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
