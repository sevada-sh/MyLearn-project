using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.ViewModels
{
    public class CourseAndArticleViewModel
    {
        public Course Courses { get; set; }
        public Article Articles { get; set; }
    }
}
