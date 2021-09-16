using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Api.Extensions
{
    public static class IoCExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProjectRepository, ProjectRepository>();
        }
    }
}