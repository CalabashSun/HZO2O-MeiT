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

        public DateTime CreateTime { get; set; }
    }
}
