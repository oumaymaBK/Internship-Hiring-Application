//using RazorPages.Models;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace RazorPages.Pages.ViewModels
//{
//    public class ProjectViewModel
//    {

//        public Guid? ProjectId { get; set; }


//        [Required]  
//        public String Title { get; set; }


//        [Required]
//        public String Description { get; set; }


//       // [Required]
//        public DateTime PublishedDate { get; set; }

//        [Required]
//        public int Duration { get; set; }


//        [Required]
//        public string Level { get; set; }
//        [Required]

//        public string Experience_type { get; set; }
//        [Required]

//        public string Profil_Required { get; set; }
//        [Required]

//        public string Technical_Khowledge { get; set; }

//        [Display(Name = "Project Image")]
//        public string FileImage { get; set; }



//        public Double Ref { get; set; }











//        [Display (Name ="Department")]
//        public Guid? BookId { get; set; }

//      //  public AppUser AppUser { get; set; }


//    }
//}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class ProjectViewModel
{
    public Guid? ProjectId { get; set; }

    [Required]
    public String Title { get; set; }

    [Required]
    public String Description { get; set; }

    
    public DateTime? PublishedDate { get; set; }


    [Required]
    public int Duration { get; set; }


    [Required]
    public string Level { get; set; }
    [Required]

    public string Experience_type { get; set; }
    [Required]

    public string Profil_Required { get; set; }
    [Required]

    public string Technical_Khowledge { get; set; }

    [Display(Name = "Project Image")]
    public string? FileImage { get; set; }

    public Double Ref { get; set; }

    [Display(Name = "Department")]
    public Guid? BookId { get; set; }
}