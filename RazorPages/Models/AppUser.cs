using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Models
{
    public class AppUser: IdentityUser//une classe public , voici on fait l'heritage de IdentityUser pour avoir les attributs déja existante dans Ide
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsAuthor { get; set; } = false;

        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Faculte { get; set; }

        public string? Niveau { get; set; }

        public string? CVFile { get; set; }

        public string? LetterMotivationFile { get; set; } 

    }
}
