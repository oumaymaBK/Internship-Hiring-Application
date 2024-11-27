using RazorPages.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Models
{
    public class Answer
    {
        [Key]
        public Guid? AnswerId { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        public bool IsCorrect { get; set; }

    }
}