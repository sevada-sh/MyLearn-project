using MyLearn.Application.ViewModels;
using MyLearn.Data.Context;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private MyLearnContext _context;
        public CourseRepository(MyLearnContext context)
        {
            _context = context;
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
        }

        public Course FindCourse(int courseId)
        {
            return _context.Courses.Find(courseId);
        }

        public IEnumerable<Course> FindCourses(int courseId)
        {
            return (IEnumerable<Course>)_context.Courses.Find(courseId);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Course> Search(string search)
        {
            return _context.Courses.Where(s => s.CourseName.Contains(search) || s.CourseTags.Contains(search)).Distinct();
        }

        public Course SingleOrDefaultOrder(int orderId)
        {
            return _context.Courses.SingleOrDefault(p => p.OrderId == orderId);
        }
    }
}
