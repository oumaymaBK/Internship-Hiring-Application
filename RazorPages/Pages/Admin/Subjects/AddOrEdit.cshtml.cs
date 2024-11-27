using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Pages.ViewModels;

namespace RazorPages.Pages.Admin.Subjects
{
    public class AddOrEditModel : PageModel
    {
        [BindProperty]
        public SubjectViewModel SubjectViewModel { get; set; }
        public void OnGet()
        {
        }
    }
}
