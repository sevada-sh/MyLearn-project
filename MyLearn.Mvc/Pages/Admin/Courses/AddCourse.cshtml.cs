using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Application.ViewModels.Admin;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc.Pages.Admin.Courses
{
    public class AddCourseModel : PageModel
    {
        [BindProperty]
        public AddEditCourseViewModel Course { get; set; }
        private readonly ICourseService _courseService;
        public AddCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var course = new Course()
                {
                    CourseName = Course.CourseName,
                    CourseTeacher = Course.CourseTeacher,
                    CoursePrice = Course.CoursePrice,
                    CourseDescription = Course.CourseDescription,
                    CourseTags = Course.CourseTags,
                    CourseVideosCount = Course.CourseVideosCount,
                    CourseLevel = Course.CourseLevel,
                    CourseIsHolding = Course.CourseIsHolding,
                    Discount = Course.Discount

                };

                _courseService.AddCourse(course);
                _courseService.Save();

                if (Course.CourseImage?.Length > 0)
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Courses", Course.CourseId + ".jpg");
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        Course.CourseImage.CopyTo(stream);
                    }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
