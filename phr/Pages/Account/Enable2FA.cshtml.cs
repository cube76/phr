using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OtpNet;
using QRCoder;
using System.Text;
using System;
using phr.Config;
using phr.Models;

namespace phr.Pages.Account
{
    public class Enable2FAModel : BasePageModel
    {
        private readonly ILogger<Enable2FAModel> _logger;

        public Enable2FAModel(ILogger<Enable2FAModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string SharedKey { get; set; }
        public string QRCodeUri { get; set; }
        public string Enabled { get; set; }
        [BindProperty]
        public string VerificationCode { get; set; }
             
        public IActionResult OnGet()
        {
            var user = HttpContext.Session.GetObjectFromJson<LoginResponse>("User");
            var existingKey = HttpContext.Session.GetString("SharedKey");

            if (existingKey != null)
            {
                SharedKey = existingKey;
                QRCodeUri = GenerateQRCodeUri("IEM", user.userName, SharedKey);
                SharedKey = FormatKey(SharedKey);
            }
            else
            {
                var sharedKey = GenerateSharedKey();
                HttpContext.Session.SetString("SharedKey", sharedKey);

                QRCodeUri = GenerateQRCodeUri("IEM", user.userName, sharedKey);
                SharedKey = FormatKey(sharedKey);
            }

            _logger.LogInformation("sharedKey get: {ErrorMessage}", SharedKey);
            Enabled = HttpContext.Session.GetString("2FAEnabled");

            return Page();  
        }

        public IActionResult OnPost(string verificationCode)
        {
            // Retrieve shared key from session
            var sharedKey = HttpContext.Session.GetString("SharedKey");
            if (sharedKey == null) return RedirectToPage("/Login");

            // Validate verification code
            if (VerifyCode(sharedKey, verificationCode))
            {
                HttpContext.Session.SetString("2FAEnabled", "true");

                return RedirectToPage("/Index");
            }
                
            ModelState.AddModelError("VerificationCode", "Invalid code.");
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("Token");
            return RedirectToPage("/Login"); 
        }
        public IActionResult OnPostRefresh()
        {
            return RedirectToPage(); 

        }

        private string GenerateSharedKey()
        {
            var rng = new byte[10];
            using var generator = System.Security.Cryptography.RandomNumberGenerator.Create();
            generator.GetBytes(rng);
            return Base32Encoding.ToString(rng); 
        }

        private string FormatKey(string unformattedKey)
        {
            return string.Join(" ", Enumerable.Range(0, unformattedKey.Length / 4)
                .Select(i => unformattedKey.Substring(i * 4, 4)));
        }

        private string GenerateQRCodeUri(string appName, string email, string key)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode($"otpauth://totp/{appName}:{email}?secret={key}&issuer={appName}&digits=6", QRCodeGenerator.ECCLevel.Q);
                var qrCode = new PngByteQRCode(qrCodeData);
                var qrCodeBytes = qrCode.GetGraphic(20);

                return Convert.ToBase64String(qrCodeBytes);
            }
        }

        private bool VerifyCode(string sharedKey, string verificationCode)
        {
            var totp = new OtpNet.Totp(Base32Encoding.ToBytes(sharedKey));
            return totp.VerifyTotp(verificationCode, out _);
        }
    }
}
