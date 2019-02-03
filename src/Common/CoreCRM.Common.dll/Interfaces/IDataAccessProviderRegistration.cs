using Microsoft.Extensions.DependencyInjection;

namespace CoreCRM.Common.Interfaces
{
    public interface IDataAccessProviderRegistration
    {
        void Register(IServiceCollection services);
    }
}
