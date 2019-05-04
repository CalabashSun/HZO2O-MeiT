using System;
using System.Collections.Generic;
using System.Text;
using MeituanApi.Data.External.Submit;

namespace MeituanApi.Data.External.Response
{
    public class RShopList
    {
        /// <summary>
        /// shopInfo
        /// </summary>
        public List<string> data { get; set; }
    }

    public class RShopDetails 
    {
        public List<RShopDetail> data { get; set; }
    }

    public class RShopDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public int is_online { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long utime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string standby_tel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pic_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int open_level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long city_id { get; set; }
        /// <summary>
        /// 丽华快餐
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pre_book_min_days { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string app_poi_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string promotion_info { get; set; }
        /// <summary>
        /// 快餐简餐
        /// </summary>
        public string tag_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal shipping_fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ctime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int location_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pre_book { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int invoice_support { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shipping_time { get; set; }
        /// <summary>
        /// 北苑路北站K酷时代广场4层
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pre_book_max_days { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int invoice_min_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int time_select { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string invoice_description { get; set; }
        /// <summary>
        /// 快餐简餐
        /// </summary>
        public string third_tag_name { get; set; }
    }
}
