using System.ComponentModel.DataAnnotations;

namespace RazorPages.Pages.ViewModels
{
    public class UserInputViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password between 6 and 20 cracters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

      
        // Additional properties for file uploads if needed
        //public IFormFile CVFile { get; set; }

        //public IFormFile LetterMotivationFile { get; set; }
    }
}
