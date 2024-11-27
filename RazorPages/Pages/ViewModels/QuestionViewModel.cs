using System.ComponentModel.DataAnnotations;

namespace RazorPages.Pages.ViewModels
{
    public class QuestionViewModel
    {
        public Guid QuestionId { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}
