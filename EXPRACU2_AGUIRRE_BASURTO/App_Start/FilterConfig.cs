using System.Web;
using System.Web.Mvc;

namespace EXPRACU2_AGUIRRE_BASURTO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
