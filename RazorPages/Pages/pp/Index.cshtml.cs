using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Pages.Admin.Users;
using System.Drawing;

namespace RazorPages.Pages.pp
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager; // Add UserManager to access user information

        private readonly ProjetDbContext _db;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notify;
        public IEnumerable<HrInterview> interList { get; set; }

        private readonly ILogger<RegisterModel> _logger;

        [BindProperty]//Pour dire que l'objet suivant"Bok"peut avoir une liaison avec le formulaire
        public InterviewViewModel intrv { get; set; }
        public IndexModel(UserManager<AppUser> userManager, ProjetDbContext db, IMapper mapper, IToastNotification notify, ILogger<RegisterModel> logger)//Nadit ToastNotification
        {
            this._db = db;
            this._mapper = mapper;
            this._notify = notify;
            intrv = new InterviewViewModel();
            this._logger = logger;
            _userManager = userManager;
        }

        public async Task OnGet()
        {
            try
            {
                interList = await _db.HrInterview
                    .Include(interview => interview.User) // Include the related User entity
                    .Select(interview => new HrInterview
                    {
                        InterviewId = interview.InterviewId,
                        Date = interview.Date,
                        StartTime = interview.StartTime,
                        FinishTime = interview.FinishTime,
                        UserId = interview.UserId ?? null,
                        User = interview.UserId!=null ? interview.User:null, // Include the User navigation property for all interviews
                        Status = interview.Status,
                    })
                    .ToListAsync();

                _logger.LogError("Error fetching interview list: ", interList);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching interview list: ", ex);
                // Handle the error gracefully, perhaps display a message to the user
            }
        }


        public async Task<IActionResult> OnGetUserDetailsAsync(string userId)
        {
            try
            {
                var user = await _db.Users
                    .Where(u => u.Id == userId)
                    .Select(u => new
                    {
                        u.UserName,
                        u.Email,
                        u.PhoneNumber,
                       // CvFile = u.CvFileUrl, // Assuming you have URLs for files
                        //MotivationLetter = u.MotivationLetterUrl // Assuming you have URLs for files
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return new JsonResult(new { success = false, message = "User not found" });
                }

                return new JsonResult(new { success = true, data = user });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching user details: {Error}", ex);
                return new JsonResult(new { success = false, message = "Error fetching user details" });
            }
        }


        public async Task<IActionResult> OnPost([FromForm] DateTime? Date, [FromForm] TimeSpan? StartTime, [FromForm] TimeSpan? FinishTime)
        {

            if (Date == null || StartTime == null || FinishTime == null)
            {
                return BadRequest("Date, StartTime, and FinishTime are required.");
            }

            try
            {
                HrInterview newInterview = new HrInterview
                {
                    InterviewId = Guid.NewGuid(),
                    Date = Date.Value,
                    StartTime = StartTime.Value,
                    FinishTime = FinishTime.Value,
                    Status = "Available"
                };

                await _db.HrInterview.AddAsync(newInterview);
                await _db.SaveChangesAsync();

                _notify.AddSuccessToastMessage("Interview created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating interview: ", ex);
                _notify.AddErrorToastMessage("Failed to create interview.");
            }

            return RedirectToPage();
        }

    }
}
