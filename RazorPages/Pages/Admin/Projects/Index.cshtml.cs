//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using RazorPages.Data;
//using RazorPages.Pages.ViewModels;

//namespace RazorPages.Pages.Admin.Projects
//{
//    public class IndexModel : PageModel
//    {//1 : Injection de BD dans le Ctor 

//        private readonly ProjetDbContext _db;
//        ////2:Déclaration de la liste nomée Projects
//        public IEnumerable < ProjectListViewModel> Projects { get;set;}
//        public IndexModel(ProjetDbContext db)
//        {
//           this._db = db;
//        }
//        //3 le handler exécutée le premier est asyn tkoun 3la chakl path
//        public async Task OnGet()
//        {
//            Projects = await _db.Project.Include(p=> p.Book)
//            .Select(k=> new ProjectListViewModel 

//            {
//                      ProjectId = k.ProjectId,
//                      Title = k.Title,
//                      Technical_Khowledge = k.Technical_Khowledge,
//                      Duration = k.Duration,
//               //ToShortDateString()
//                       PublishedDate = (k.PublishedDate==DateTime.MinValue ? null : k.PublishedDate.ToShortDateString()),
//                FileImage = k.FileImage,
//                Book = k.Book.Name,    

//            }).ToListAsync();
//        }
//    }
//}
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using RazorPages.Data;
//using RazorPages.Pages.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace RazorPages.Pages.Admin.Projects
//{
//    public class IndexModel : PageModel
//    {
//        private readonly ProjetDbContext _db;

//        public IEnumerable<ProjectListViewModel> Projects { get; set; }

//        public IndexModel(ProjetDbContext db)
//        {
//            _db = db;
//        }

//        public async Task OnGet()
//        {
//            Projects = await _db.Project
//                .Include(p => p.Book)
//                .Select(k => new ProjectListViewModel
//                {
//                    ProjectId = k.ProjectId,
//                    Title = k.Title,
//                    Description = k.Description,
//                    Duration = k.Duration,
//                    // si PublishedDate a une valeur, la méthode ToShortDateString() sera appelée sur cette valeur. Sinon, une chaîne vide sera assignée à PublishedDate
//                    // Ancienne Initialisation
//                    PublishedDate = k.PublishedDate.HasValue ? k.PublishedDate.Value.ToShortDateString(): null,

//                    Level = k.Level,
//                    Experience_type = k.Experience_type,
//                    Profil_Required = k.Profil_Required,
//                    Technical_Khowledge = k.Technical_Khowledge,
//                    FileImage = k.FileImage,
//                    // Assurez-vous que k.Book.Name n'est pas null avant d'accéder à sa propriété
//                    Book = k.Book,
//                })
//                .ToListAsync();
//        }


//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Pages.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Pages.Admin.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ProjetDbContext _db;


        public IndexModel(ProjetDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
         
        }
    }
}

