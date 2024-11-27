using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Data
{
    public class ProjetDbContext: IdentityDbContext //c'est une extension lina 9otlou jibli les informations ili mawjoudine fi IdentityDbContext+Dbset(book)+Dbset(Projet)
    {
        public ProjetDbContext(DbContextOptions<ProjetDbContext>options):base(options)
        {
        
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<HrInterview> HrInterview { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<AppUser> AppUser { get; set; }//Ajout de Table AppUser au ProjetDbContext

        public DbSet<Contact>Contact { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        //public DbSet<Task> Task { get; set; }

    }
    }
   

