using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Pages.ViewModels;

namespace RazorPages.Pages.Admin.Users
{
    public class RegisterModel : PageModel
    {  //Pour bind avec register torbit ma3neha lazem ndiclariw prop de type UserInputViewModel
        private UserManager<AppUser> _userManager;
        private IToastNotification _notify;
        private IMapper _mapper;
        private readonly ProjetDbContext _db;
        private readonly ILogger<RegisterModel> _logger;

        [BindProperty]

        public UserInputViewModel UserInput { get; set; }
        public RegisterModel(ProjetDbContext db, UserManager<AppUser> userManager, IToastNotification notify, IMapper mapper, ILogger<RegisterModel> logger)
        //le service que j'ai besoins
        {
            this._userManager = userManager;
            this._notify = notify;
            this._mapper = mapper;
            this._db = db;
            UserInput = new UserInputViewModel();
            _logger = logger;
        }
        public async Task OnGet(string? Id)
        {
            if (Id != null)
            {
                 AppUser UserToEdit = await _db.AppUser
                    .FirstOrDefaultAsync(b => b.Id.ToString() == Id);
                UserInput = _mapper.Map<UserInputViewModel>(UserToEdit);

            }

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                AppUser user = _mapper.Map<AppUser>(UserInput);
                user.UserName = UserInput.Email;//on a le cle primaire dans IdentityUser est UserName donc ici je l'effectue manuellement à email
                var res = await _userManager.CreateAsync(user, UserInput.Password);//On a prend le user+mode de passe

                if (res.Succeeded)
                {
                    _notify.AddSuccessToastMessage("User created successfully");
                    return RedirectToPage("Login");
                }
                else
                {
                    _notify.AddErrorToastMessage("User not created successfully");
                    return Page(); // Retourner à la même page si la création a échoué
                }
                
            }
            // Si ModelState.IsValid est faux, il faut retourner également une valeur
            return Page();// Retourner à la même page si le modèle n'est pas valide
        }


        
    }
}