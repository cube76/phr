using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace phr.Pages.Exceptions
{
    public class WellDetailInformationModel : BasePageModel
    {
        public void OnGet(string id, string uwi, string field, string name, string bfpd, string bopd, string areas)
        {
            ViewData["id"] = id;
            ViewData["uwi"] = uwi;
            ViewData["name"] = name;
            ViewData["field"] = field;
            ViewData["area"] = areas;
            ViewData["bfpd"] = bfpd;
            ViewData["bopd"] = bopd;
        }
    }
}
