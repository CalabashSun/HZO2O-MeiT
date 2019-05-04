using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace MeituanApi.Data.DataBase
{
    [Table("MeiTOrder_ZpOrder")]
    public class MeiTOrder_ZpOrder:BaseEntity
    {
        public long OrderId { get; set; }

        public string CQ_KT_DC_TH { get; set; }

        public string Eat_BM_CP { get; set; }

        public string Bas_text { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int People { get; set; }

        public decimal Cope { get; set; }

        public decimal TotalPrice { get; set; }

        public string Ptdjh { get; set; }

        public string Eat_allremark { get; set; }

        public string door_id { get; set; }

        public string door_name { get; set; }

        public int OrderStatus { get; set; } = 2;

        public DateTime? DeliverTime { get; set; }

        public string WM_PT { get; set;}
    }
}
