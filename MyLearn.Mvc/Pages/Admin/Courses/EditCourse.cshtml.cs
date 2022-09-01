using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Application.ViewModels.Admin;
using MyLearn.Data.Context;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc.Pages.Admin.Courses
{
    public class EditCourseModel : PageModel
    {
        public AddEditCourseViewModel Course { get; set; }
        private readonly ICourseService _courseservice;
        public EditCourseModel(ICourseService courseservice)
        {
            _courseservice = courseservice;
        }

        public void OnGet(int courseId)
        {
            var course = _courseservice.FindCourses(courseId);

            Course = (AddEditCourseViewModel)course;
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                var course = _courseservice.FindCourse(Course.CourseId);

                course.CourseName = Course.CourseName;
                course.CourseTeacher = Course.CourseTeacher;
                course.CoursePrice = Course.CoursePrice;
                course.CourseDescription = Course.CourseDescription;
                course.CourseTags = Course.CourseTags;
                course.CourseLevel = Course.CourseLevel;
                course.CourseVideosCount = Course.CourseVideosCount;
                course.CourseIsHolding = Course.CourseIsHolding;
                course.Discount = Course.Discount;

                _courseservice.Save();

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
