using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Models
{
    public class Question
    {
        [Key]
        public Guid? QuestionId { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public Guid? TestId { get; set; }
        [ForeignKey("TestId")]
        public Test Test { get; set; }
    }
}
