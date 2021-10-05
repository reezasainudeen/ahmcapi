using MyTest.API.Filters;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;

namespace MyTest.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
         
        }
        public static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection filters)
        {
            filters.Add(new IdentityBasicAuthenticationAttribute());
            filters.Add(new TokenAuthenticationAttribute());
           
        }
    }
}
