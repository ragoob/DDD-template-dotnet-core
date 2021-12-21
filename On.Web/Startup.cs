using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using On.Core;
using On.Infra;
using On.Domain;
using MediatR;
using On.Application.CommandHandlers.Customers;
using On.Application.Commands.Customers;
using On.Domain.Events.Customers;
using On.Application.EventHandlers.Customers;
using On.Application;

namespace On.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddTransient<ILoggingService, TestableLogger>();
            services.AddTransient<DomainEventDispatcher>();
            services.AddDbContext<OnContext>((provider,options) =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                options.AddInterceptors(provider.GetRequiredService<DomainEventDispatcher>());

            });
            services.AddAutoMapper();
            services.AddRepositories();
            services.AddUnitOfWork();
            services.AddTransient<IRequestHandler<AddCustomerCommand, bool>, AddCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateCustomerCommand, bool>, UpdateCustomerHandler>();
            services.AddTransient<IRequestHandler<DeleteCustomerCommand>, DeleteCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<ActivateCustomerCommand,bool>, ActivateCustomerCommandHanlder>();
            services.AddTransient<INotificationHandler<CustomerActivated>, CustomerActivatedEventHandler>();
            services.AddMediatR(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "On.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "On.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
