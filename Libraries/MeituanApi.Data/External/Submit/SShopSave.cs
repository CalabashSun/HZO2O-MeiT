using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Submit
{
    public class SShopSave:BaseSubmit
    {
        /// <summary>
        /// Y APP方门店ID
        /// </summary>
        public string app_poi_code { get; set; }
        /// <summary>
        /// Y 门店名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Y 门店地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// Y 门店纬度 （美团使用的是高德坐标系，也就是火星坐标系，如果是百度坐标系需要转换）(门店坐标不需要乘以一百万)
        /// </summary>
        public double latitude { get; set; }
        /// <summary>
        /// Y 门店经度 （美团使用的是高德坐标系，也就是火星坐标系，如果是百度坐标系需要转换）(门店坐标不需要乘以一百万)
        /// </summary>
        public double longitude { get; set; }
        /// <summary>
        /// N 门店图片地址（默认图片为：http://p1.meituan.net/crm/__37375183__1582979.jpg）图片比例1:1，需要为Jpg/JPEG格式，大于256x256
        /// </summary>
        public string pic_url { get; set; }
        /// <summary>
        /// N 门店图片地址（默认图片为：http://p1.meituan.net/crm/__37375183__1582979.jpg ）图片比例4:3，需要为Jpg/JPEG格式，大于400x300
        /// </summary>
        public string pic_url_large { get; set; }
        /// <summary>
        /// Y 客服电话号码 （注意：此号码留客服号码）
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// N 门店电话号码 （注意：此号码留商家电话）(已废弃)
        /// </summary>
        public string standby_tel { get; set; }
        /// <summary>
        /// Y 每个订单的配送费
        /// </summary>
        public decimal shipping_fee { get; set; }
        /// <summary>
        /// Y 门店营业时间 （注意格式，且保证不同时间段之间不存在交集） 7:00-9:00,11:30-19:00
        /// </summary>
        public string shipping_time { get; set; }
        /// <summary>
        /// N 门店推广信息
        /// </summary>
        public string promotion_info { get; set; }
        /// <summary>
        /// Y 门店的营业状态：1为可配送，3为休息中
        /// </summary>
        public int open_level { get; set; }
        /// <summary>
        /// Y 门店上下线状态：1为上线，0为下线，门店必须在菜品、配送范围和门店信息都齐全后，才能提交上线 （注意：此字段不为1时门店不会提交审核）
        /// </summary>
        public int is_online { get; set; }
        /// <summary>
        /// N 门店是否支持发票
        /// </summary>
        public int invoice_support { get; set; }
        /// <summary>
        /// N 门店支持开发票的最小订单价（invoice_suport为1时可用）
        /// </summary>
        public int invoice_min_price { get; set; }
        /// <summary>
        /// N 发票相关说明（invoice_suport为1时可用）
        /// </summary>
        public string invoice_description { get; set; }
        /// <summary>
        ///Y 目前最多支持上传两个门店品类：一个主营品类（上传的第一个品类为主营品类），一个辅营品类；部分门店品类只支持上传一个品类（例如：火锅，特色菜，地方菜，东南亚菜，日韩料理，生活超市）
        /// </summary>
        public string third_tag_name { get; set; }
        /// <summary>
        /// N 是否支持营业时间范围外预下单，1表支持，0表不支持
        /// </summary>
        public int pre_book { get; set; }
        /// <summary>
        /// N 是否支持营业时间范围内预下单，1表支持，0表不支持，此字段开启后不可关闭，新建门店将自动开启
        /// </summary>
        public int time_select { get; set; }
        /// <summary>
        /// N 第三方品牌code值（对接的三方需要提前将该值告诉美团技术同学）
        /// </summary>
        public string app_brand_code { get; set; }
    }
}
