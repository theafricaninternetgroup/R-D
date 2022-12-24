using Multitenancy.Library.Extensions;
using Multitenancy.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddMultitenancy<Tenant, TenantResolver>();
builder.Services.AddRazorPages(); 


var app = builder.Build();
app
    .UseStaticFiles()
    .UseRouting();
app.MapRazorPages();
    

app.Run();
