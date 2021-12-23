using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using On.Core;
using On.Infra;
using On.Infra.DataRepository;
using On.Application.Mappers;
using On.Domain.RepositoriesAbstraction;
using MediatR;
using On.Application.Commands.Customers;
using On.Domain.Events.Customers;
using On.Application.CommandHandlers.Customers;
using On.Application.EventHandlers.Customers;

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

        public static void AddMediatR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRequestHandler<AddCustomerCommand, bool>, AddCustomerCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<UpdateCustomerCommand, bool>, UpdateCustomerHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteCustomerCommand>, DeleteCustomerCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<ActivateCustomerCommand, bool>, ActivateCustomerCommandHanlder>();
            serviceCollection.AddTransient<INotificationHandler<CustomerActivated>, CustomerActivatedEventHandler>();
            serviceCollection.AddMediatR(typeof(Startup));
        }
    }
}
