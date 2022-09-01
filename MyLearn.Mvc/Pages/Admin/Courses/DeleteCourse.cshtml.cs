using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc.Pages.Admin.Courses
{
    public class DeleteCourseModel : PageModel
    {
        private readonly ICourseService _courseservice;
        public DeleteCourseModel(ICourseService courseservice)
        {
            _courseservice = courseservice;
        }
        public void OnGet(int courseId)
        {
            _courseservice.FindCourse(courseId);
        }

        public IActionResult OnPost(int courseId)
        {
            var course = _courseservice.FindCourse(courseId);
            _courseservice.DeleteCourse(course);
            _courseservice.Save();

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Courses", ".jpg");
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }

            return RedirectToAction("Index");
        }
    }
}
