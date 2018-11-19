using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{
    public interface IMeiTOrderInfoService:IRepository<MeiTOrderInfo>
    {
        MeiTOrderInfo GetMeiTOrderInfo(long orderId);
    }
    public class MeiTOrderInfoService:Repository<MeiTOrderInfo>,IMeiTOrderInfoService
    {
        public MeiTOrderInfo GetMeiTOrderInfo(long orderId)
        {
            var selectSql = $"select * from MeiTOrderInfo where OrderId='{orderId}'";
            return _Conn.QueryFirstOrDefault<MeiTOrderInfo>(selectSql);
        }
    }
}
