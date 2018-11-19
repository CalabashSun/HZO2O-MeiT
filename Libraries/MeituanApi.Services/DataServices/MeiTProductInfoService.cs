using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{

    public interface IMeiTProductInfoService:IRepository<MeiTProductInfo>
    {
        void TuncateProductByShopId(string shopId);
        /// <summary>
        /// 批量获取产品列表
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        List<TempMeiTProductInfo> ListProductInfo(string shopId);
    }


    public class MeiTProductInfoService:Repository<MeiTProductInfo>,IMeiTProductInfoService
    {
        public void TuncateProductByShopId(string shopId)
        {
            var truncateSql = $"delete from MeiTProductInfo where ShopId='{shopId}'";
            _Conn.Execute(truncateSql);
        }

        public List<TempMeiTProductInfo> ListProductInfo(string shopId)
        {
            var selectSql = $"select * from MeiTProductInfo where ShopId='{shopId}'";
            return _Conn.Query<TempMeiTProductInfo>(selectSql).ToList();
        }
    }
}
