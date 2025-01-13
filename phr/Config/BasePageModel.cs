using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class BasePageModel : PageModel
{
    public override void OnPageHandlerExecuting(Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutingContext context)
    {
        var token = HttpContext.Session.GetString("Token");
        var twoFactorRequired = HttpContext.Session.GetString("2FARequired");
        if (string.IsNullOrEmpty(token))
        {
            // Redirect to login page
            context.Result = RedirectToPage("/Login");
        }
        else if (twoFactorRequired == "true")
        {
            context.Result = RedirectToPage("/Account/LoginWith2FA");
        }


        base.OnPageHandlerExecuting(context);
    }


}