using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{
    public interface IMeiTOrderCancelService : IRepository<MeiTOrderCancel>
    {
        void AddCancelRecord(MeiTOrderCancel orderCancel);
    }
    public class MeiTOrderCancelService : Repository<MeiTOrderCancel>, IMeiTOrderCancelService
    {
        public void AddCancelRecord(MeiTOrderCancel orderCancel)
        {
            //判断退单是否存在
            var sqlString = $"select * from MeiTOrderCancel where OrderId='{orderCancel.OrderId}'";
            var existData = _Conn.QueryFirstOrDefault<MeiTOrderCancel>(sqlString);
            if (existData == null)
            {
                _Conn.Insert<MeiTOrderCancel>(orderCancel);
            }
        }
    }
}
