using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Pages.Admin.Users;
using RazorPages.Pages.ViewModels;

namespace RazorPages.Pages.Admin.Tasks
{
    public class IndexModel : PageModel
    {

        private readonly UserManager<AppUser> _userManager; // Add UserManager to access user information

        private readonly ProjetDbContext _db;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notify;
        public IEnumerable<HrInterview> interList { get; set; }

        private readonly ILogger<RegisterModel> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]//Pour dire que l'objet suivant"Bok"peut avoir une liaison avec le formulaire
        public UserInputViewModel user { get; set; }
        public IndexModel(UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment, ProjetDbContext db, IMapper mapper, IToastNotification notify, ILogger<RegisterModel> logger)//Nadit ToastNotification
        {
            this._db = db;
            this._mapper = mapper;
            this._notify = notify;
            user = new UserInputViewModel();
            this._logger = logger;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var appUser = new AppUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            //if (user.CVFile != null && user.CVFile.Length > 0)
            //{
            //    var cvFileName = GetUniqueFileName(user.CVFile.FileName);
            //    var cvFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", cvFileName);

            //    using (var stream = new FileStream(cvFilePath, FileMode.Create))
            //    {
            //        await user.CVFile.CopyToAsync(stream);
            //    }

            //    appUser.CVFile = "/uploads/" + cvFileName;
            //}

            //if (user.LetterMotivationFile != null && user.LetterMotivationFile.Length > 0)
            //{
            //    var letterFileName = GetUniqueFileName(user.LetterMotivationFile.FileName);
            //    var letterFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", letterFileName);

            //    using (var stream = new FileStream(letterFilePath, FileMode.Create))
            //    {
            //        await user.LetterMotivationFile.CopyToAsync(stream);
            //    }

            //    appUser.LetterMotivationFile = "/uploads/" + letterFileName;
            //}

            try
            {
                _db.Users.Add(appUser);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving user data");
                // Handle the exception as needed
                throw;
            }

            return RedirectToPage("/Success");
        }
        private string GetUniqueFileName(string fileName)
        {
            // Generate a unique file name to prevent overwriting existing files
            return Guid.NewGuid().ToString() + "_" + fileName;
        }

    }


}
