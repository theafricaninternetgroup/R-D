using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenancy.Library
{
    public interface ITenantResolver<TTenant>
    {
       public TTenant? Tenant { get; }
    }
}
