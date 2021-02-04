namespace Martenio.Infrastructure
{
    using System.Reflection;
    using Marten;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMarten(options =>
            {
                options.AutoCreateSchemaObjects = AutoCreate.All;
                options.Connection(configuration.GetConnectionString("Marten"));
            }).InitializeStore();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
