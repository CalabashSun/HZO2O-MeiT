using Autofac;
using MeituanApi.Core.Infrastructure;
using MeituanApi.Core.Infrastructure.DependencyManagement;
using Microsoft.Extensions.DependencyInjection;

namespace MeituanApi.Web.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, IServiceCollection services)
        {
            //file provider
            builder.RegisterType<ProjectFileProvider>().As<IProjectFileProvider>().InstancePerLifetimeScope();
           

        }
        

        public int Order => 0;
    }
}
