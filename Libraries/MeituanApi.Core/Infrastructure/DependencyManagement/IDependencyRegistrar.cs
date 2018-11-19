using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace MeituanApi.Core.Infrastructure.DependencyManagement
{
    /// <summary>
    /// Dependency registrar interface
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="services">IServiceCollection</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, IServiceCollection services);

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        int Order { get; }
    }
}
