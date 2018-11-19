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
    public class MeiTComment 
    {
        public static string QueryComment(IHttpClientFactory httpFactory)
        {
            var commentModel = new SOrderComment
            {
                app_poi_code = "4856022",
                start_time = DateTime.Now.AddDays(-1).ToString("yyyyMMdd"),
                end_time = DateTime.Now.AddDays(-1).ToString("yyyyMMdd"),
                pageoffset = 1,
                pagesize = 20,
                replyStatus = -1
            };
            commentModel.sig = SignHelper.Sign<SOrderComment>(commentModel, MeiTAction.orderComment);
            var client = httpFactory.CreateClient();
            //FormUrlEncodedContent content = new FormUrlEncodedContent(SignHelper.ToDictionary(commentModel));
            try
            {
                var connectParams = "";
                var commentParams = SignHelper.ToDictionary(commentModel);
                if (commentParams != null)
                {
                    foreach (var commentParam in commentParams)
                    {
                        connectParams+= commentParam.Key+"="+commentParam.Value+"&";
                    }
                }

                connectParams = connectParams.Substring(0, connectParams.Length - 1);
                var getUrl = MeiTAction.orderComment + "?" + connectParams;
                var response = client.GetAsync(getUrl).Result.Content.ReadAsStringAsync().Result;
                return response;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }     
}
