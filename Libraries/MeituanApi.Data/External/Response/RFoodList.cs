using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Response
{
    public class RFoodList
    {
        public List<RFood> data { get; set; }
    }

    public class RFood
    {
        /// <summary>
        /// APP方菜品id
        /// </summary>
        public string app_food_code { get; set; }
        /// <summary>
        /// APP方门店ID(保留字段，目前为空字符串)
        /// </summary>
        public string app_poi_code { get; set; }
        /// <summary>
        /// 打包盒数量
        /// </summary>
        public float  box_num { get; set; }
        /// <summary>
        /// 餐盒价格
        /// </summary>
        public float box_price { get; set; }
        /// <summary>
        /// 菜品分类名
        /// </summary>
        public string category_name { get; set; }
        /// <summary>
        /// 菜品创建时间
        /// </summary>
        public int ctime { get; set; }
        /// <summary>
        /// 菜品描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 1：下架，0：上架
        /// </summary>
        public int is_sold_out { get; set; }
        /// <summary>
        /// 最大购买量
        /// </summary>
        public int min_order_count { get; set; }
        /// <summary>
        /// 菜品名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 菜品图片
        /// </summary>
        public string picture { get; set; }
        /// <summary>
        /// 菜品价格
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 当前分类下的排序序号
        /// </summary>
        public int sequence { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string skus { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 菜品修改时间
        /// </summary>
        public int utime { get; set; }
    }
}
