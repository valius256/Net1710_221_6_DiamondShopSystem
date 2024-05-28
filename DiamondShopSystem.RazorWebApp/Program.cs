
using DiamondShopSystem.Business.Business.Implement;
using DiamondShopSystem.Business.Business.Interfaces;
using DiamondShopSystem.Business.Business.Imp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
builder.Services.AddScoped<IMainDiamondBusiness, MainDiamondBusiness>();
builder.Services.AddScoped<IDiamondSettingBusiness, DiamondSettingBusiness>();
builder.Services.AddScoped<ISideStoneBusiness, SideStoneBusiness>();
builder.Services.AddScoped<ProductBusiness>();
builder.Services.AddScoped<IOrderBusiness, OrderBusiness>();
builder.Services.AddScoped<ICustomerBusiness, CustomerBusiness>();
/*builder.Services.AddDbContext<Net1710_221_6_DiamondShopSystemContext>();*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
