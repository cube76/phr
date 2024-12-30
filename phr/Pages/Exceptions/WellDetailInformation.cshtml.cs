using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace phr.Pages.Exceptions
{
    public class WellDetailInformationModel : PageModel
    {
        public void OnGet(string id, string code, string name)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            ViewData["code"] = code;
        }
    }
}
