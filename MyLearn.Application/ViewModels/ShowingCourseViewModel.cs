using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.ViewModels
{
    public class ShowingCourseViewModel
    {
        public IEnumerable<Course> courses { get; set; }
        public IEnumerable<Course> searchedcourses { get; set; }
    }
}
