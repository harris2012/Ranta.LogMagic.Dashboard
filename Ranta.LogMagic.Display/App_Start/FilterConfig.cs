using Ranta.Web;
using Ranta.Web.Security;
using System.Web;
using System.Web.Mvc;

namespace Ranta.LogMagic.Display
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new RantaAuthorizeAttribute());
            filters.Add(new HandleExceptionAttribute());
        }
    }
}