using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Models
{
    public class Project
    {
        [Key]
        public Guid? ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? Duration { get; set; }
        public string Level { get; set; }
        public string Experience_type { get; set; }
        public string Profil_Required { get; set; }
        public string Technical_Khowledge { get; set; }
        public string ImageUrl { get; set; }
        public double? Ref { get; set; }
        public Guid? BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }


        public static implicit operator Project?(string? v)
        {
            throw new NotImplementedException();
        }
    }
}
