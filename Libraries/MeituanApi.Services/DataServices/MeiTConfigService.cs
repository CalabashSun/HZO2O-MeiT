﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MeituanApi.Data.DataBase;
using MeituanApi.Services.Repositorys;

namespace MeituanApi.Services.DataServices
{

    public interface IMeiTConfigService:IRepository<MeiTConfig>
    {
        MeiTConfig GetMeiTConfig(string zpShopId);

        List<MeiTConfig> AllMetTShop();
    }

    public class MeiTConfigService:Repository<MeiTConfig>,IMeiTConfigService
    {
        public MeiTConfig GetMeiTConfig(string zpShopId)
        {
            var selectSql = $"select * from MeiTConfig where Zp_ShopId='{zpShopId}'";
            return _Conn.QueryFirstOrDefault<MeiTConfig>(selectSql);
        }

        public List<MeiTConfig> AllMetTShop()
        {
            var selectSql = $"select * from  dbo.MeiTConfig where ShopId=2";
            return _Conn.Query<MeiTConfig>(selectSql).ToList();
        }
    }
}