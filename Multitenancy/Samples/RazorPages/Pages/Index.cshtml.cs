using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Csla;
using Multitenancy.Web.RazorPages.Models;
using Csla.AspNetCore.RazorPages;

namespace Multitenancy.Web.RazorPages.Pages
{
    public class IndexModel : PageModel<PersonEdit>
    {

        private  readonly IDataPortal<PersonEdit> _portal;
       
        public IndexModel(ApplicationContext AppCtx,IDataPortal<PersonEdit> portal)
            :base(AppCtx)
        {
            _portal = portal;
        }
        public void OnGet()
        {
            Item = _portal.Create();
        }
    }
}
