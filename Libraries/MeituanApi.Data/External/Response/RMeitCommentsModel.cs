using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Response
{
    public class RMeitCommentsModel
    {
        public string poiName { get; set; }

        public string ZpName { get; set; }
        public string shopId { get; set; }
        public List<CommentData> data { get; set; } = new List<CommentData>();
    }

    public class CommentData
    {
        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long comment_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string comment_content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int order_comment_score { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int food_comment_score { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int delivery_comment_score { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string add_comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string add_comment_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int packing_score { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string comment_time { get; set; }
        /// <summary>
        /// 穿戴工服,礼貌热情,仪表整洁,风雨无阻,快速准时,货品完好
        /// </summary>
        public string comment_lables { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ship_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string comment_pictures { get; set; }
        /// <summary>
        /// 西红柿烩牛腩,红烧肉（小份）,葱油菜苔,烤羊肉串（根）,餐具
        /// </summary>
        public string praise_food_list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string critic_food_list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int reply_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string e_reply_content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string e_reply_time { get; set; }
    }
}
