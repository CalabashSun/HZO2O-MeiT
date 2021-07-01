using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace MeituanApi.Data.DataBase
{
    [Table("MeiTOrderLog")]
    public class MeiTOrderLog:BaseEntity
    {
        public long OrderId { get; set; }

        public string OrderContext { get;set; }

        public string OrderPoiReceiveDetail { get; set; }

        public string OrderExtras { get; set; }

        public DateTime CreateTime { get; set; }

        public int IsHandle { get; set; }
    }
}
