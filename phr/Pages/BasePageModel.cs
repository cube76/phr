using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class BasePageModel : PageModel
{
    protected string Token { get; private set; }
    public void OnGet()
    {
        // Check for the token in session
        Token = HttpContext.Session.GetString("Token");

        if (string.IsNullOrEmpty(Token))
        {
            Console.WriteLine("Hello World!" + Token);
            // Redirect to login page if token does not exist
            Response.Redirect("/Login"); // Change to your login page URL
            return;
        }
    }


}