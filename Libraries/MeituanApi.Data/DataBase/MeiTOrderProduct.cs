using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace MeituanApi.Data.DataBase
{
    [Table("MeiTOrderProduct")]
    public class MeiTOrderProduct:BaseEntity
    {

        public long OrderId { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public string Attributes { get; set; }

        public string NewSpecs { get; set; }

        public decimal? UserPrice { get; set; }

        public decimal? ShopPrice { get; set; }

        public decimal BoxNum { get; set; }

        public decimal BoxPrice { get; set; }

        public int CartId { get; set; }

        public string FoodProperty { get; set; }
    }
}
