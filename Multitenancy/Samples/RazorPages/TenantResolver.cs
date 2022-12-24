using System;
using System.Threading.Tasks;
using System.Linq;
using Multitenancy.Library;
namespace Multitenancy.Web
{
    public class TenantResolver :ITenantResolver<Tenant>
    {
        private readonly HttpContext _context;
        private List<Tenant> _tenantList=new List<Tenant> { new Tenant { Id=1,Name="Tenant 1", HostNames = new[] {"localhost:5001","localhost:5002"}}, new Tenant { Id = 2, Name = "Tenant 2", HostNames = new[] { "localhost:5003","localhost:5004"} } };
        public TenantResolver(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext!;
            
            Tenant=_tenantList.FirstOrDefault(t=>t.HostNames!.Any(h=>h.Equals(_context.Request.Host.Value.ToLower())));
        }
         
        public Tenant? Tenant { get; }
        
    }
}
