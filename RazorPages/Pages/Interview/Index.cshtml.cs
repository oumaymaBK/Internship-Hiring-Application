using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Pages.ViewModels;
using Microsoft.Extensions.Logging;

namespace RazorPages.Pages.Interview
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ProjetDbContext _db;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notify;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<HrInterview> interList { get; set; }

        [BindProperty]
        public InterviewViewModel Intrv { get; set; }

        public IndexModel(UserManager<AppUser> userManager, ProjetDbContext db, IMapper mapper, IToastNotification notify, ILogger<IndexModel> logger)
        {
            _db = db;
            _mapper = mapper;
            _notify = notify;
            _logger = logger;
            _userManager = userManager;
            Intrv = new InterviewViewModel();
        }

        public async Task OnGetAsync()
        {
            try
            {
                interList = await _db.HrInterview
                    .Select(interview => new HrInterview
                    {
                        InterviewId = interview.InterviewId,
                        Date = interview.Date,
                        StartTime = interview.StartTime,
                        FinishTime = interview.FinishTime,
                        Status = interview.Status,
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching interview list: ", ex);
            }
        }

        public async Task<IActionResult> OnPostChooseAsync([FromForm] Guid? InterviewId, [FromForm] string UserId)
        {
            _logger.LogError("Processing interview ID: {InterviewId}", InterviewId);

            if (InterviewId == null)
            {
                return new JsonResult(new { success = false, message = "Interview ID is null." });
            }

            var interview = new HrInterview { InterviewId = InterviewId }; // Create a new interview entity with only the InterviewId set

            _db.Attach(interview); // Attach the interview entity to the context

            var user = await _userManager.GetUserAsync(User);

            interview.UserId = user.Id; // Set the UserId property

            interview.Status = "Unavailable";

            _db.Entry(interview).Property(x => x.UserId).IsModified = true; // Mark the UserId property as modified

            await _db.SaveChangesAsync(); // Save the changes to the database

            return RedirectToPage();
        }
    }
}
