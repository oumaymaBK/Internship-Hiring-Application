using System.ComponentModel.DataAnnotations;

namespace RazorPages.Pages.ViewModels
{
    public class TestViewModel
    {
        public Guid? TestId { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The Duration field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The Duration field must be a positive integer.")]
        public int Duration { get; set; }

        [Display(Name = "Project")]
        public string ProjectId { get; set; }

        // Additional properties or validation attributes can be added as needed

        // Optional: Add a collection of QuestionViewModels if necessary
        // public ICollection<QuestionViewModel> Questions { get; set; }
    }
}
