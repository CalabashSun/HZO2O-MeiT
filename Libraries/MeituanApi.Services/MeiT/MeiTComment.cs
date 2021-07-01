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
        public static RMeitCommentsModel QueryComment(IHttpClientFactory httpFactory, string shopId, string start, string end, int offset, int pageSize)
        {
            var commentModel = new SOrderComment
            {
                app_poi_code = shopId,
                start_time = start,
                end_time = end,
                pageoffset = offset,
                pagesize = pageSize,
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
                        connectParams += commentParam.Key + "=" + commentParam.Value + "&";
                    }
                }

                connectParams = connectParams.Substring(0, connectParams.Length - 1);
                var getUrl = MeiTAction.orderComment + "?" + connectParams;
                var response = client.GetAsync(getUrl).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<RMeitCommentsModel>(response);
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
