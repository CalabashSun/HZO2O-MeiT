using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Submit
{
    public class BaseSubmit
    {
        /// <summary>
        /// 调用接口时的时间戳
        /// </summary>
        public long timestamp { get; set; } =(long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;

        /// <summary>
        /// 美团分配给APP方的id
        /// </summary>
        public string app_id { get; set; } = "4356";
        /// <summary>
        /// 参数签名
        /// </summary>
        public string sig { get; set; }
    }
}
