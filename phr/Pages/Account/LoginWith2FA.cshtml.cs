using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OtpNet;
using phr.Config;

namespace phr.Pages.Account
{
    public class LoginWith2FAModel : PageModel
    {
        private readonly ILogger<LoginWith2FAModel> _logger;

        public LoginWith2FAModel(ILogger<LoginWith2FAModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public string TwoFactorCode { get; set; }

        public IActionResult OnPost()
        {
            var sharedKey = HttpContext.Session.GetString("SharedKey"); 
            _logger.LogInformation("sharedKey get: {ErrorMessage}", sharedKey);
            if (sharedKey == null) return RedirectToPage("/Login");

            if (VerifyCode(sharedKey, TwoFactorCode))
            {
                HttpContext.Session.Remove("2FARequired");
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError("TwoFactorCode", "Invalid authentication code.");

            return Page();
        }

        private bool VerifyCode(string sharedKey, string verificationCode)
        {
            var totp = new OtpNet.Totp(Base32Encoding.ToBytes(sharedKey));
            return totp.VerifyTotp(verificationCode, out _);
        }
    }
}
