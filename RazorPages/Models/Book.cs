using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models
{
    public class Book

    {
        [Key]
        public Guid? BookId { get; set; }

        //Voici les  DataAnnotations --> Les Conditions  de Name:
        [Display(Name = "Feature.Name")]//Nom d'affichage  raja3nehom pour etre affiché directement de BD dans la liste d'une maniére automatique
        //[Required(ErrorMessage ="Feature name is required")]//required=c'est_a_dire obligatoire itha ma7atitlch ytla3lik
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters.")]//max et min 
         public string Name { get; set; } = String.Empty;// *{ get; set; }: Cela indique que cette propriété a à la fois un accesseur en lecture (get) et un accesseur en écriture (set).*String.Empty:si aucun autre valeur n'est assignée à Name, elle sera toujours initialisée avec une chaîne vide.


       [Display(Name="Order Display")]
       // [Required(ErrorMessage ="Order Display is required")]
        [Range(0,50,ErrorMessage ="Price must be between 1 and 50")]
        public int OrderDisplay { get; set; }

        public static implicit operator Book?(string? v)
        {
            throw new NotImplementedException();
        }
    }
}
