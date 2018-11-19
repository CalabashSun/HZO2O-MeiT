using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace MeituanApi.Data.DataBase
{
    [Table("MeiTOrderInfo")]
    public class MeiTOrderInfo:BaseEntity
    {
        public string ShopId { get; set; }

        public string ShopName { get; set; }

        public long OrderId { get; set; }

        public string Consignee { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public decimal DeliverFee { get; set; }

        public decimal Income { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeliverTime { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public decimal OriginalPrice { get; set; }

        public string DaySeq { get; set; }

        public decimal PackageBagMoney { get; set; }

        public DateTime? CancelOrderDescription { get; set; }

        public DateTime? CancelOrderCreatedAt { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int DinnersNumber { get; set; }

    }
}
