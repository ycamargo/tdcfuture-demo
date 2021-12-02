using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Liquid.Repository.EntityFramework.Extensions;
using Liquid.WebApi.Http.Extensions.DependencyInjection;
using Liquid.Messaging.ServiceBus.Extensions.DependencyInjection;
using System;
using TdcFuture.Domain;
using TdcFuture.Domain.Entities;
using TdcFuture.Repository;

namespace TdcFuture.WebApi
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
            #region Liquid Services
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            void options(DbContextOptionsBuilder opt) => opt.UseMySQL(Configuration.GetConnectionString(nameof(TdcFutureDbContext)));

            services.AddLiquidEntityFramework<TdcFutureDbContext, Product, int>(options);
            services.AddLiquidEntityFramework<TdcFutureDbContext, ShoppingCart, int>(options);
            services.AddLiquidEntityFramework<TdcFutureDbContext, ShoppingCartProduct, int>(options);

            services.AddLiquidHttp(typeof(IDomainInjection).Assembly);

            services.RegisterCrud<Product, int>();
            services.RegisterCrud<ShoppingCart, int>();
            services.RegisterCrud<ShoppingCartProduct, int>();

            services.AddLiquidServiceBusProducer<ShoppingCart>("Liquid:Messaging:ServiceBus:ShoppingCart");
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseLiquidConfigure();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
