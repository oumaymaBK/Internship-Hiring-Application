using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Pages.Admin.Users;
using RazorPages.Pages.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RazorPages.Pages.Admin.Tasks
{

    public class AddTaskModel : PageModel
    {

        private readonly UserManager<AppUser> _userManager; // Add UserManager to access user information

        private readonly ProjetDbContext _db;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notify;
        public IEnumerable<Test> testList { get; set; }

        private readonly ILogger<RegisterModel> _logger;

        [BindProperty]//Pour dire que l'objet suivant"Bok"peut avoir une liaison avec le formulaire
        public TestViewModel test { get; set; }
        public AddTaskModel(UserManager<AppUser> userManager, ProjetDbContext db, IMapper mapper, IToastNotification notify, ILogger<RegisterModel> logger)//Nadit ToastNotification
        {
            this._db = db;
            this._mapper = mapper;
            this._notify = notify;
            test = new TestViewModel();
            this._logger = logger;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost([FromForm] string? Description, [FromForm] string? Title, [FromForm] List<Question> Questions, [FromForm] List<Answer> Answers)
{
            _logger.LogError("Error creating jjjjjjjjjjjjjjjjjjjjjj: ", Description);

            try
            {
        Test test = new Test
        {
            TestId = Guid.NewGuid(),
            Description = Description,
            Title = Title,
            Duration = 30
        };

        // Add the test to the database
        _db.Test.Add(test);
        await _db.SaveChangesAsync();

        foreach (var question in Questions)
        {
            // Set the foreign key for the question
            question.TestId = test.TestId;

            // Add the question to the database
            _db.Question.Add(question);
            await _db.SaveChangesAsync();

            foreach (var answer in Answers)
            {
                // Set the foreign key for the answer
                answer.QuestionId = question.QuestionId;

                // Add the answer to the database
                _db.Answer.Add(answer);
            }
        }

        // Save changes after adding all questions and answers
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
