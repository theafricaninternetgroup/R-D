using Csla.Configuration;
using Csla.Web.Mvc;
using Multitenancy.Library.Extensions;
using Multitenancy.Web.RazorPages;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages().AddMvcOptions(options =>
{
    options.ModelBinderProviders.Insert(0, new CslaModelBinderProvider());
});
builder.Services.AddCsla(o => o
  .AddAspNetCore());
builder.Services.AddHttpContextAccessor();
builder.Services.AddMultitenancy<Tenant, TenantResolver>();
builder.Services.AddRazorPages(); 


var app = builder.Build();
app
    .UseStaticFiles()
    .UseRouting();
app.MapRazorPages();
    

app.Run();
