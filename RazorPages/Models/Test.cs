using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Models
{
    public class Test
    {
        [Key]
        public Guid? TestId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        public ICollection<Question> Questions { get; set; }


        public Guid ProjectId { get; set; }
        [ForeignKey("ProjectId")]

        public Project Project { get; set; }
    }
}
