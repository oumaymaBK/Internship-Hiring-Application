using System.ComponentModel.DataAnnotations;

namespace RazorPages.Pages.ViewModels
{
    public class AnswerViewModel
    {
        public Guid AnswerId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
