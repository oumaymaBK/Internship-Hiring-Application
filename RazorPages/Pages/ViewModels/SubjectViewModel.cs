using RazorPages.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Pages.ViewModels
{
    public class SubjectViewModel
    {
        public Guid? SubjectId { get; set; }//ID est généré automatiquement avec l'identity framework
        [Required]
        public String Title { get; set; }

        public String Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Duration { get; set; }
        public string Level { get; set; }
        public string Experience_type { get; set; }
        public string Profil_Required { get; set; }
        public string Technical_Khowledge { get; set; }

        //[Display (Name="FileImage")]
        public string FileImage { get; set; }

        //[Display (Name ="Book")]
        public Guid? BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
