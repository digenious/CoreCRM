using CoreCRM.Common.Interfaces;
using CoreCRM.DataLayer.DbDomain.Model;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCRM.Plugins.Configuration.DataLayerPGSQLConfiguration
{
    public class DataAccessProviderRegistration : IDataAccessProviderRegistration
    {
        public void Register(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
               .AddDbContext<DomainContext>();
        }
    }
}
