using AutoMapper;
using RazorPages.Models;
using RazorPages.Pages.ViewModels;

namespace RazorPages.Utility
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<HrInterview, InterviewViewModel>().ReverseMap();
            CreateMap<Answer, AnswerViewModel>().ReverseMap();
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<Test, TestViewModel>().ReverseMap();
            CreateMap<AppUser, UserInputViewModel>().ReverseMap();
            CreateMap<Project,ProjectViewModel>().ReverseMap();    
        }
    }
}
