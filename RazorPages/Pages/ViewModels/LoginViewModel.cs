using System.ComponentModel.DataAnnotations;

namespace RazorPages.Pages.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password between 6 and 20 cracters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display (Name="RememberMe")]
        public bool RememberMe { get; set; }

    }
}
