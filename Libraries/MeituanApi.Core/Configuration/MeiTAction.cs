﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Core.Configuration
{
    public static   class MeiTAction
    {
        public static string foodList = "https://waimaiopen.meituan.com/api/v1/food/list";
        /// <summary>
        /// 创建或更新门店信息
        /// </summary>
        public static string shopSave = "https://waimaiopen.meituan.com/api/v1/poi/save";
        /// <summary>
        /// 订单确认
        /// </summary>
        public static string orderConfirm = "https://waimaiopen.meituan.com/api/v1/order/confirm";

        public static string orderComment = "https://waimaiopen.meituan.com/api/v1/comment/query";
        /// <summary>
        /// 获取门店id
        /// </summary>
        public static string getShopInfo = "https://waimaiopen.meituan.com/api/v1/poi/getids";
        /// <summary>
        /// 批量获取门店详细信息
        /// </summary>
        public static string getShopDetail = "https://waimaiopen.meituan.com/api/v1/poi/mget";

    }
}
