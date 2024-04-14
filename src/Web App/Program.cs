using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Web_App;
using Web_App.Data;
using Web_App.Extensions;
using Web_App.Interfaces;
using Web_App.Repository;

var builder = WebApplication.CreateBuilder(args);

#region DATABASE

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program));

#endregion

#region MVC CONFIGURATIONS

builder.Services.AddMvc(options =>
{
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "Invalid value for this field");
    options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "This field must be filled");
    options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "This field must be filled");
    options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "It's necessary that body isn't void");
    options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => "This value is invalid for this field");
    options.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "This value is invalid for this field");
    options.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "Filed must be numeric");
    options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => "This value is invalid for this field");
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "This value is invalid for this field");
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "This filed must be numeric");
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "This field must be filled");
});

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddSingleton<IValidationAttributeAdapterProvider, CoinValidationAttributeAdapterProvider>();

builder.Services.AddControllersWithViews();

#endregion

#region CULTURE CONFIGURATIONS

var defaultCulture = new CultureInfo("pt-BR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture, },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

#endregion

#region APP CONFIGURATIONS

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

#endregion

