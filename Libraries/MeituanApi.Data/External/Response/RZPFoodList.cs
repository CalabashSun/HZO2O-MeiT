using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Response
{
    public class RZPFoodList
    {
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RowsItem> rows { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pagecount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageindex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pagesize { get; set; }
    }

    public class RowsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Door_Autoid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Eat_XfCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Zp_ProductId { get; set; }
        /// <summary>
        /// 锅锅牛腩
        /// </summary>
        public string Eat_XFName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Eat_XFPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Update_Time { get; set; }
        /// <summary>
        /// 草原牛类
        /// </summary>
        public string Eat_Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CQASP_Pager_RowRank { get; set; }
    }
}
