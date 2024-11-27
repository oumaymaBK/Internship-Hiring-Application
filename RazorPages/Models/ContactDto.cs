using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models
{
    public class ContactDto
    {
        [Required,MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Phone { get; set; }
        [Required, MaxLength(100)]
        public string Subject { get; set; }
        [Required,MinLength(20),MaxLength(10000)]
        public string Message { get; set; }
        public IFormFileCollection? Attachments { get; set; }
    }
}
