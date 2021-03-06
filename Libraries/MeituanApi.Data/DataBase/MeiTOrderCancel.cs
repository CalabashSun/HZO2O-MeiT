﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.DataBase
{
    [Table("MeiTOrderCancel")]
    public class MeiTOrderCancel : BaseEntity
    {
        public long OrderId { get; set; }

        public string ReasonCode { get; set; }

        public string Reason { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }

}
