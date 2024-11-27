using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Admin.Books
{
    public class IndexModel : PageModel {

        private readonly ProjetDbContext _db;
        public IEnumerable<Book>BookList{get;set;}

	public IndexModel(ProjetDbContext db)
        {
          this._db = db;
        }
        public async Task OnGet()

        {
            BookList = await _db.Book.OrderBy(b=>b.OrderDisplay).ToListAsync();
        }
    }
}
