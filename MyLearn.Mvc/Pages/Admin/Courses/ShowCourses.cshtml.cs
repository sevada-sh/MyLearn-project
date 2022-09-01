using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Domain.Models;
using System.Collections.Generic;
using MyLearn.Domain.Models;


namespace MyLearn.Mvc.Pages.Admin.Courses
{
    public class ShowCoursesModel : PageModel
    {
        public IEnumerable<Course> Courses { get; set; }
        private readonly ICourseService _courseService;
        public ShowCoursesModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public void OnGet()
        {
            Courses = _courseService.GetAllCourses();
        }
    }
}
