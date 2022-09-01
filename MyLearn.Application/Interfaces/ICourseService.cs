using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();

        void AddCourse(Course course);

        void Save();

        IEnumerable<Course> FindCourses(int courseId);

        void DeleteCourse(Course course);

        Course SingleOrDefaultOrder(int orderId);

        IEnumerable<Course> Search(string search);

        Course FindCourse(int courseId);
    }
}
