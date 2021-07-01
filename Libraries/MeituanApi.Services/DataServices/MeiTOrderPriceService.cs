using System;
using System.Collections.Generic;
using System.Text;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{
    public interface IMeiTOrderPriceService:IRepository<MeiTPriceInfo>
    {
        List<MeiTPriceInfo> GetMeitPriceInfos();

    }
    public class MeiTOrderPriceService:Repository<MeiTPriceInfo>,IMeiTOrderPriceService
    {
        public List<MeiTPriceInfo> GetMeitPriceInfos()
        {
            throw new NotImplementedException();
        }
    }
}
