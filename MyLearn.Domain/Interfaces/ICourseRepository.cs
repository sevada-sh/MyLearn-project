using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();

        void AddCourse(Course course);

        void Save();

        IEnumerable<Course> FindCourses(int courseId);

        Course FindCourse(int courseId);

        void DeleteCourse(Course course);

        Course SingleOrDefaultOrder(int orderId);

        IEnumerable<Course> Search(string search);
    }
}
