using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Receive
{
    public class DesOrderPayed
    {
        /// <summary>
        /// 订单ID（数据库中请用bigint(20)存储此字段）
        /// </summary>
        public long order_id { get; set; }
        /// <summary>
        /// APP方商家ID
        /// </summary>
        public string app_poi_code { get; set; }
        /// <summary>
        /// 美团商家名称
        /// </summary>
        public string wm_poi_name { get; set; }
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
        /// 门店当天的推单流水号，该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public int day_seq { get; set; }
        /// <summary>
        /// 商家对账信息的json数据，该信息默认不推送，如有需求可在开发者中心订阅
        /// </summary>
        public string poi_receive_detail { get; set; }
        /// <summary>
        ///第一种：优惠信息，其值为由list<object> 序列化得到的json字符串 第二种：骑手应付款，其值为由list<object> 序列化得到的json字符串
        /// </summary>
        public string extras { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public long ctime { get; set; }
    }

    public class PoiReceiveDetail
    {
        /// <summary>
        /// 商品分成，即平台服务费，单位为分
        /// </summary>
        public long foodShareFeeChargeByPoi { get; set; }
        /// <summary>
        /// 配送费，单位为分
        /// </summary>
        public long logisticsFee { get; set; }
        /// <summary>
        /// 在线支付款，单位为分
        /// </summary>
        public long onlinePayment { get; set; }
        /// <summary>
        /// 商家应收款，单位为分
        /// </summary>
        public long wmPoiReceiveCent { get; set; }

        public List<PoiDetail> actOrderChargeByPoi { get; set; }=new List<PoiDetail>();
    }


    public class PoiDetail
    {
        public string comment { get; set; }

        public string feeTypeDesc { get; set; }

        public string feeTypeId { get; set; }

        public long moneyCent { get; set; }
    }
}
