using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace MeituanApi.Data.DataBase
{
    [Table("MeiTProductInfo")]
    public class MeiTProductInfo : BaseEntity
    {
        public string ShopId { get; set; }

        public int CateId { get; set; }

        public string CateName { get; set; }

        public string ProductName { get; set; }

        public string ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public string Zp_ProductId { get; set; }

        public string Zp_ProductName { get; set; }
        /// <summary>
        /// 1:使用中 2:已替换 3:已删除
        /// </summary>
        public int ProductState { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        public int MeiTCreatTime { get; set; }

        public int MeiTUpdateTime { get; set; }

    }


    public class TempMeiTProductInfo : MeiTProductInfo
    {
        public int DealState { get; set; } = 0;

    }
}
