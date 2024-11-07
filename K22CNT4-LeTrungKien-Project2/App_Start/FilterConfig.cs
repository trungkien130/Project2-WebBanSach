using System.Web;
using System.Web.Mvc;

namespace Web_thuc_tap_chuyen_de_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
