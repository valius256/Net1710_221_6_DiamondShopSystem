using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DiamondShopSystem.Business
{
    public static class AppBuilderExtensions
    {
        public static void DIServices(this IServiceCollection service)
        {
            service.AddScoped<IProductBusiness, ProductBusiness>();
            service.AddScoped<IMainDiamondBusiness, MainDiamondBusiness>();
            service.AddScoped<IDiamondSettingBusiness, DiamondSettingBusiness>();
            service.AddScoped<ISideStoneBusiness, SideStoneBusiness>();
            service.AddScoped<ProductBusiness>();
            service.AddScoped<IOrderBusiness, OrderBusiness>();
            service.AddScoped<ICustomerBusiness, CustomerBusiness>();
        }
    }
}
