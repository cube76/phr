using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace phr.Pages
{
    public class FilePreviewModel : PageModel
    {
        public string FileUrl { get; set; }
        public string FileExtension { get; set; }
        public string FileContent { get; set; }
        public bool IsSupportedPreview { get; set; }
        public string EncodedFileUrl { get; set; }

        public async Task OnGetAsync(string fileUrl)
        {
            FileUrl = fileUrl;
            FileExtension = System.IO.Path.GetExtension(fileUrl)?.ToLower();
            EncodedFileUrl = Uri.EscapeUriString(fileUrl);

            IsSupportedPreview = FileExtension switch
            {
                ".pdf" or ".jpg" or ".jpeg" or ".png" or ".txt" or ".mp4" or ".docx" or ".pptx" or ".xlsx" or ".xls" => true,
                _ => false
            };

            // Load content for text files
            if (FileExtension == ".txt")
            {
                using var httpClient = new HttpClient();
                FileContent = await httpClient.GetStringAsync(fileUrl);
            }
        }
    }
}
