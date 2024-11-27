    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Models
{
    public class HrInterview
    {
        [Key]
        public Guid? InterviewId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan? StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan? FinishTime { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string? UserId { get; set; }  // Made nullable
        [ForeignKey("UserId")]
        public virtual AppUser? User { get; set; }

        public static implicit operator HrInterview?(string? v)
        {
            throw new NotImplementedException();
        }
    }
}

