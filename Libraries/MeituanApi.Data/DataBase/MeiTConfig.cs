using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace MeituanApi.Data.DataBase
{
    [Table("MeiTConfig")]
    public  class MeiTConfig:BaseEntity
    {
        public string Name { get; set; }

        public string ShopId { get; set; }

        public string AppKey { get; set; }

        public string AppSecret { get; set; }

        public string InterUrl { get; set; }

        public string Zp_ShopId { get; set; }

        public string Zp_ShopName { get; set; }

    }
}
