using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using On.Core;
using On.Infra;
using On.Infra.DataRepository;
using On.Application.Mappers;
using On.Domain.RepositoriesAbstraction;

namespace On.Web
{
    public static class ServiceCollectionExtention
    {
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
        }

       

        public static void AddUnitOfWork(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
