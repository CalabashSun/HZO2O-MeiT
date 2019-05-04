using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MeituanApi.Core.DbContext;
using MeituanApi.Core.Infrastructure;
using MeituanApi.Core.Infrastructure.DependencyManagement;
using MeituanApi.Services.DataServices;
using MeituanApi.Services.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace MeituanApi.Services
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, IServiceCollection services)
        {
            //services
            builder.RegisterType<DapperDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //美团商品信息
            builder.RegisterType<MeiTConfigService>().As<IMeiTConfigService>().InstancePerLifetimeScope();
            builder.RegisterType<MeiTProductInfoService>().As<IMeiTProductInfoService>().InstancePerLifetimeScope();
            builder.RegisterType<MeiTOrderInfoService>().As<IMeiTOrderInfoService>().InstancePerLifetimeScope();
            builder.RegisterType<MeiTOrderProductService>().As<IMeiTOrderProductService>().InstancePerLifetimeScope();
            builder.RegisterType<MeiTOrderLogService>().As<IMeiTOrderLogService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderToZpService>().As<IOrderToZpService>().InstancePerLifetimeScope();
        }

        public int Order { get; } = 1;
    }
}
