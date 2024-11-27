using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Pages.ViewModels;

namespace RazorPages.Pages.Admin.Books
{
    public class AddOrEditModel : PageModel
    //  @ * permet de recuperer la page model *@//

    {
        private readonly ProjetDbContext _db;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notify;


        [BindProperty]//Pour dire que l'objet suivant"Bok"peut avoir une liaison avec le formulaire
        public BookViewModel Bok { get; set; }
        //ctor + double tabulation ==> pour la création de constructeur 
        //On fait l'injection des dépendences injecter dans le Construteur l'objet qui nous permet de connecter à la BD )
        public AddOrEditModel(ProjetDbContext db, IMapper mapper, IToastNotification notify)//Nadit ToastNotification
        {
            this._db = db;
            this._mapper = mapper;
            this._notify = notify;
            Bok= new BookViewModel();//MIch nista3malha min ba3id wa9 les boutons yt7awlou min save l update w lkol 
        }
        public async Task OnGet(string? BookId)
        {
            if (BookId != null)
            {
                Book BookToEdit = await _db.Book
                    .FirstOrDefaultAsync(b => b.BookId.ToString() == BookId);
                Bok = _mapper.Map<BookViewModel>(BookToEdit);

            }

        }    //Nsaliouha ONPost mouch Post fil action Post na3mlou ...

         public async Task<IActionResult> OnPost()
            {
                if (ModelState.IsValid )//ModelState:model existant
            {



                Book bokToDB = _mapper.Map<Book>(Bok);
            
                if (Bok.BookId == null)
                {

                    ///////Ajout ///////////

                    // Book bokToDB = new()
                    //{
                    // Name = Bok.Name,
                    // OrderDisplay = Bok.OrderDisplay,

                    //};
                    // Najem n7otou min fou9 5iir mili no93od niktib fih martine fi ajout w update
                    // Book bokToDB = _mapper.Map<Book>(Bok);
                    await _db.Book.AddAsync(bokToDB);
                    int res = await _db.SaveChangesAsync();
                    if (res > 0)
                    {
                        _notify.AddSuccessToastMessage("Department created successfully");
                        return RedirectToPage("Index");//tawa mak ajoutit lazem traja3ni lil page index w twarini inik ajoutit hety resultat mta3ha de 
                                                       //type IActionResult heka 3leh lazem nzidha fi Task 
                    }
                    else
                    {
                        _notify.AddErrorToastMessage("Department not created successfully");
                    }// Rediriger vers une autre page après l'ajout du livre si nécessaire
                     // return RedirectToPage("/NomDeLaPage");

                }
                else {
                    //////EDit ////////
                    _db.Update(bokToDB);
                    await _db.SaveChangesAsync();
                    _notify.AddSuccessToastMessage("Feature Edited successfully");
                    return RedirectToPage("Index");
                }
            }
                return Page();//Sinon mich na9a fil page nafsha mouch mich nit7awel lil index 
            }





            ////////////FONCTION DELETE//////////////////
            public async Task<IActionResult> OnGetDelete(string BookId) 
            { //puisque la suppression est via lien Donc c'est Get n'est pas Post *BookId le variablequi se trouve avec handeler Delete le mem nom ili fi routing 


                Book? BookToDelete = await _db.Book
                    .FirstOrDefaultAsync(b => b.BookId.ToString() == BookId);
                if (BookToDelete != null)
                {
                    _db.Book.Remove(BookToDelete);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }

                return Page();
            }
        }

    } 



