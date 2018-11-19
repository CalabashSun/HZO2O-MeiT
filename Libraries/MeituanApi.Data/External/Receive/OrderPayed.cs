using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Receive
{
    public class OrderPayed
    {
        /// <summary>
        /// 订单ID（数据库中请用bigint(20)存储此字段）
        /// </summary>
        public long order_id { get; set; }
        /// <summary>
        /// 订单展示ID
        /// </summary>
        public long wm_order_id_view { get; set; }
        /// <summary>
        /// APP方商家ID
        /// </summary>
        public string app_poi_code { get; set; }
        /// <summary>
        /// 美团商家名称
        /// </summary>
        public string wm_poi_name { get; set; }

        /// <summary>
        /// 美团商家地址
        /// </summary>
        public string wm_poi_address { get; set; }

        /// <summary>
        /// 美团商家电话
        /// </summary>
        public string wm_poi_phone { get; set; }
        /// <summary>
        /// 收件人地址(此字段为用户填写的收货地址，可在开发者中心订阅是否根据经纬度反查地址，若订阅则会在此字段后追加反查结果，并用“@#”符号分隔，如：用户填写地址@#反查结果)
        /// </summary>
        public string recipient_address { get; set; }
        /// <summary>
        /// 收件人电话（请兼容13812345678和13812345678_123456两种号码格式，以便对接隐私号订单，最多不超过20位）
        /// </summary>
        public string recipient_phone { get; set; }
        /// <summary>
        /// 收件人姓名（若用户没有填写姓名，此字段默认为空。可在开发者中心订阅是否用“美团客人”填充此字段
        /// </summary>
        public string recipient_name { get; set; }
        /// <summary>
        /// 门店配送费
        /// </summary>
        public decimal shipping_fee { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal total { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal original_price { get; set; }
        /// <summary>
        /// 忌口或备注
        /// </summary>
        public string caution { get; set; }
        /// <summary>
        /// 送餐员电话
        /// </summary>
        public string shipper_phone { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 城市ID（目前暂时用不到此信息）
        /// </summary>
        public long city_id { get; set; }
        /// <summary>
        /// 是否开发票
        /// </summary>
        public int has_invoiced { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public string invoice_title { get; set; }
        /// <summary>
        /// 纳税人识别号，该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public string taxpayer_id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public long ctime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public long utime { get; set; }
        /// <summary>
        /// 用户预计送达时间，“立即送达”时为0
        /// </summary>
        public int delivery_time { get; set; }
        /// <summary>
        /// 是否是第三方配送平台配送,0表否，1表是）
        /// </summary>
        public int is_third_shipping { get; set; }
        /// <summary>
        /// 支付类型，1表货到付款，2表在线支付）
        /// </summary>
        public int pay_type { get; set; }
        /// <summary>
        /// 取餐类型（0：普通取餐；1：到店取餐），该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public int pick_type { get; set; }
        /// <summary>
        /// 实际送餐地址纬度
        /// </summary>
        public double latitude { get; set; }
        /// <summary>
        /// 实际送餐地址经度
        /// </summary>
        public double longitude { get; set; }
        /// <summary>
        /// 门店当天的推单流水号，该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public int day_seq { get; set; }
        /// <summary>
        /// is_favorites
        /// </summary>
        public bool is_favorites { get; set; }
        /// <summary>
        /// 用户是否第一次在此门店点餐（true, false），该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public bool is_poi_first_order { get; set; }
        /// <summary>
        /// 用餐人数（0：用户没有选择用餐人数；1-10：用户选择的用餐人数；-10：10人以上用餐；99：用户不需要餐具），该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public int dinners_number { get; set; }
        /// <summary>
        /// 订单配送方式，该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public string logistics_code { get; set; }
        /// <summary>
        /// 商家对账信息的json数据，该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public string poi_receive_detail { get; set; }
        /// <summary>
        /// 订单商品详情，其值为由list<object>序列化得到的json字符串
        /// </summary>
        public string detail { get; set; }
        /// <summary>
        ///第一种：优惠信息，其值为由list<object>序列化得到的json字符串 第二种：骑手应付款，其值为由list<object>序列化得到的json字符串
        /// </summary>
        public string extras { get; set; }
        /// <summary>
        /// 门店平均配送时长，单位为秒
        /// </summary>
        public int avg_send_time { get; set; }
        /// <summary>
        /// 餐盒费？
        /// </summary>
        public decimal package_bag_money { get; set; }
    }

    public class OrderProduct
    {
        public string app_food_code { get; set; }

        public string food_name { get; set; }
        /// <summary>
        /// /sku编码
        /// </summary>
        public string sku_id { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 商品单价，此字段默认为活动折扣后价格，可在开发者中心订阅是否替换为原价
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 餐盒数量
        /// </summary>
        public int box_num { get; set; }
        /// <summary>
        /// 	餐盒价格
        /// </summary>
        public decimal box_price { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 商品折扣，默认为1，仅美团商家可设置
        /// </summary>
        public float food_discount { get; set; }
        /// <summary>
        /// 菜品属性，多个属性用半角逗号隔开，该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public string food_property { get; set; }
        /// <summary>
        /// 菜品规格名称，该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public string spec { get; set; }
        /// <summary>
        /// 商品所在的口袋，0为1号口袋，1为2号口袋，以此类推，如有需求请在开发者中心订阅
        /// </summary>
        public int cart_id { get; set; }
    }
}
