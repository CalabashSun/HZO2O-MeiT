using System;
using System.Collections.Generic;
using System.Text;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{
    public interface IMeiTOrderProductService:IRepository<MeiTOrderProduct>
    {

    }

    public class MeiTOrderProductService:Repository<MeiTOrderProduct>,IMeiTOrderProductService
    {
    }
}
