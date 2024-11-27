using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RazorPages.Models;
using RazorPages.Pages.ViewModels;

namespace RazorPages.Pages.Admin.Users
{
    public class LoginModel : PageModel
    {
        private SignInManager<AppUser> _signInManager;

        [BindProperty]
        public LoginViewModel InputLogin { get; set; }
        //Creation de Constructeur que je  veux nommé SingInManager
        public LoginModel(SignInManager<AppUser> signInManager)
        {
            this._signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        //Bien sur mich tkoun 3andi action Donc=>Task
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager
                        .PasswordSignInAsync(InputLogin.Email, InputLogin
                        .Password, InputLogin.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (InputLogin.Email== "recruiter@gmail.com")
                    {
                        return RedirectToPage("/Candidature/Index");
                    }
                    if (InputLogin.Email== "admin@gmail.com")
                    {
                        return RedirectToPage("IndexUserList");
                    }
                    if (InputLogin.Email== "manager@gmail.com")
                    {
                        return RedirectToPage("/Admin/Books/Index");
                    }
                    if (InputLogin.Email == "candidat@gmail.com")
                    {
                        return RedirectToPage("/Admin/Tasks/Index");
                    }
                    return RedirectToPage("/Home/Index");


                }

                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid Login or password !!!!!!");
                    return Page();
                }
            }

            return Page();
        }
        public async Task<IActionResult> OnGetLogOut() { 
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Admin/Users/Login");
        }
    }
}
