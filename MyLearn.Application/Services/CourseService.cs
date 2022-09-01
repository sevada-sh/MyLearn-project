using MyLearn.Application.Interfaces;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void AddCourse(Course course)
        {
            _courseRepository.AddCourse(course);
        }

        public void DeleteCourse(Course course)
        {
            _courseRepository.DeleteCourse(course);
        }

        public Course FindCourse(int courseId)
        {
            return _courseRepository.FindCourse(courseId);
        }

        public IEnumerable<Course> FindCourses(int courseId)
        {
            return _courseRepository.FindCourses(courseId);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAllCourses().ToList();
        }

        public void Save()
        {
            _courseRepository.Save();
        }

        public IEnumerable<Course> Search(string search)
        {
            return _courseRepository.Search(search).ToList();

        }

        public Course SingleOrDefaultOrder(int orderId)
        {
            return _courseRepository.SingleOrDefaultOrder(orderId);
        }
    }
}
