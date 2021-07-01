using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.DataBase
{
    [Table("MeiTPriceInfo")]
    public class MeiTPriceInfo:BaseEntity
    {
        public string ShopId { get; set; }

        public string ShopName { get; set; }

        public string OrderId { get; set; }

        public int DaySeq { get; set; }

        public decimal? Total { get; set; }

        public decimal? ActualTotal { get; set;  }

        public decimal? OriginalPrice { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? ServiceFee { get; set; }

        public decimal? ActualReceive { get; set; }

        public bool? IsCanceled { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? CreateTime { get; set; }

    }
}
