using System;
using System.Collections.Generic;
using System.Text;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{
    public interface IMeiTOrderLogService:IRepository<MeiTOrderLog>
    {

    }

    public class MeiTOrderLogService:Repository<MeiTOrderLog>,IMeiTOrderLogService
    {

    }
}
