    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using NToastNotify;
    using RazorPages.Data;
    using RazorPages.Models;

    namespace RazorPages.Pages.Admin.Users
    {
        public class UserProjectModel : PageModel
        {
            private readonly UserManager<AppUser> _userManager; // Add UserManager to access user information

            private readonly ProjetDbContext _db;
            private readonly IMapper _mapper;
            private readonly IToastNotification _notify;
            public IEnumerable<ProjectViewModel> projectList { get; set; }

            private readonly ILogger<RegisterModel> _logger;

            [BindProperty]//Pour dire que l'objet suivant"Bok"peut avoir une liaison avec le formulaire
            public ProjectViewModel project { get; set; }
            public UserProjectModel(UserManager<AppUser> userManager, ProjetDbContext db, IMapper mapper, IToastNotification notify, ILogger<RegisterModel> logger)//Nadit ToastNotification
            {
                this._db = db;
                this._mapper = mapper;
                this._notify = notify;
                project = new ProjectViewModel();
                this._logger = logger;
                _userManager = userManager;
            }

            public async Task OnGet()
            {
              

                    var projectList = await _db.Project.ToListAsync();


                    _logger.LogError("Error fetching interview list: ", projectList);


            }

      
        }
    }
