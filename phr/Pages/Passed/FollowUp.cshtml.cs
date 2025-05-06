using Microsoft.AspNetCore.Mvc;

namespace phr.Pages.Passed
{
	public class FollowUpModel : BasePageModel
	{
		public void OnGet()
		{
		}

		[BindProperty]
		public List<IFormFile> UploadFiles { get; set; } = new();

		public string? UploadMessage { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (UploadFiles.Count > 4)
			{
				ModelState.AddModelError("", "You can only upload up to 4 files.");
				return Page();
			}

			foreach (var file in UploadFiles)
			{
				if (file.Length > 0)
				{
					//logic
				}
			}

			UploadMessage = "Files uploaded successfully!";
			return Page();
		}
	}
}
