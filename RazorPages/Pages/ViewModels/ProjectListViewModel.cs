//using RazorPages.Models;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace RazorPages.Pages.ViewModels
//{
//    public class ProjectListViewModel
//    {

//        [Key]
//        public Guid? ProjectId { get; set; }//ID est généré automatiquement avec l'identity framework
//        public String Title { get; set; }
//        public String Description { get; set; }

//       [Display(Name = "Published Date ")]
//       public DateTime PublishedDate { get; set; }
//        public int Duration { get; set; }
//        public string Level { get; set; }
//        public string Experience_type { get; set; }
//        public string Profil_Required { get; set; }
//        public string Technical_Khowledge { get; set; }


//        public string FileImage { get; set; }
//        public Double Ref { get; set; }


//        [Display(Name ="Department")]
//        public string BookId { get; set; }

//        public Book Book { get; set; }

//        // public AppUser AppUser { get; set; }


//    }
//}

using RazorPages.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPages.Pages.ViewModels
{
    public class ProjectListViewModel
    {
        public Guid? ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int Duration { get; set; }
        public string Level { get; set; }
        public string Experience_type { get; set; }
        public string Profil_Required { get; set; }
        public string Technical_Khowledge { get; set; }
        public string FileImage { get; set; }
        public double Ref { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}

