using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace phr.Pages.Exceptions
{
    public class WellDetailInformationModel : BasePageModel
    {
        public void OnGet(string id, string uwi, string field, string name, string area, string bfpd, string bopd)
        {
            ViewData["id"] = id;
            ViewData["uwi"] = uwi;
            ViewData["name"] = name;
            ViewData["field"] = field;
            ViewData["area"] = area;
            ViewData["bfpd"] = bfpd;
            ViewData["bopd"] = bopd;
        }
    }
}
