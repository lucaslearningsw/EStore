using EStore.Catalog.Application.Services;
using EStore.Catalog.Data;
using EStore.Catalog.Data.Repository;
using EStore.Catalog.Domain;
using EStore.Catalog.Domain.Events;
using EStore.Catalog.Domain.Interfaces;
using EStore.Core.Mediatr;
using MediatR;

namespace EStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Mediatr
            services.AddScoped<IMediatrHandler, MediatrHandler>();


            //Catalog
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<CatalogContext>();


            services.AddScoped<INotificationHandler<EventProductDropStock>, EventProductHandler>();

        }
    }
}
