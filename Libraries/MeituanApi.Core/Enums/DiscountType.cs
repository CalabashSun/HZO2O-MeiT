using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Core.Enums
{
    public static class DiscountType
    {
        public static string TypeDesc(int type)
        {
            var result = "";
            switch (type)
            {
                case 1: result = "新用户立减";break;
                case 2: result = "满减"; break;
                case 5: result = "满赠"; break;
                case 9: result = "使用红包"; break;
                case 11: result = "提前下单减"; break;
                case 17: result = "折扣商品"; break;
                case 18: result = "美团专送再减"; break;
                case 19: result = "点评券"; break;
                case 20: result = "第二份半价"; break;
                case 21: result = "会员免配送费"; break;

                case 22: result = "门店新客立减"; break;
                case 23: result = "买赠"; break;
                case 24: result = "平台新用户立减"; break;
                case 25: result = "满减配送费"; break;
                case 30: result = "阶梯满减配送费"; break;
                case 46: result = "外卖加价购"; break;
                case 100: result = "满返商家代金券"; break;
                case 101: result = "使用商家代金券"; break;
                case 103: result = "进店领券"; break;
                case 118: result = "商品券"; break;
                default:break;
            }

            return result;
        }
    }
}
