using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Receive
{
    public class OrderCanceled
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public long order_id { get; set; }

        /// <summary>
        /// 全额退款通知类型，参考值：apply-发起退款；
        /// agree-确认退款；
        /// reject-驳回退款；
        /// cancelRefund-用户取消退款申请；
        /// cancelRefundComplaint-用户取消退款申诉。
        /// </summary>
        public string notify_type { get; set; }

        /// <summary>
        /// 订单取消原因code
        /// </summary>
        public long refund_id { get; set; }

        /// <summary>
        /// 本次退款申请的发起时间
        /// </summary>
        public int ctime { get; set; }

        /// <summary>
        /// 取消原因
        /// </summary>
        public string reason { get; set; }

        /// <summary>
        /// 退款状态类型，参考值：0-未处理；1-商家驳回退款请求；2-商家同意退款；3-客服驳回退款请求；4-客服帮商家同意退款；5-超过3小时自动同意；6-系统自动确认；7-用户取消退款申请；8-用户取消退款申诉。
        /// </summary>
        public int res_type { get; set; }
        /// <summary>
        /// 本次申请是否为用户申诉退款，参考值：0-否；1-是。如为1则表示用户第一次申请全额退款时已被商家驳回，本次用户发起的申诉会由美团客服介入处理，商家不能操作。
        /// </summary>
        public int is_appeal { get; set; }
    }
}
