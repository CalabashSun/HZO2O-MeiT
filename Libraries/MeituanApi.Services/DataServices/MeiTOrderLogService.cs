using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{
    public interface IMeiTOrderLogService:IRepository<MeiTOrderLog>
    {
        List<MeiTOrderLog> GetOrderLogs();

        void SetHandeled();

        List<MeiTOrderCancel> GetCancelOrder();
    }

    public class MeiTOrderLogService : Repository<MeiTOrderLog>, IMeiTOrderLogService
    {
        public List<MeiTOrderCancel> GetCancelOrder()
        {
            var selectSql = $"select * from MeiTOrderCancel where DATEDIFF(DAY,CreateTime,GETDATE())=0";
            return _Conn.Query<MeiTOrderCancel>(selectSql).ToList();
        }

        public List<MeiTOrderLog> GetOrderLogs()
        {
            var selectSql = $"select * from MeiTOrderLog where isHandle=0";
            return _Conn.Query<MeiTOrderLog>(selectSql).ToList();
        }

        public void SetHandeled()
        {
            var execSql = $"update MeiTOrderLog set isHandle=1 where isHandle=0";
            _Conn.Execute(execSql);
        }
    }
}
