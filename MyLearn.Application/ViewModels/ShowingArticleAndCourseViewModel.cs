using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.ViewModels
{
    public class ShowingArticleAndCourseViewModel
    {
        public IEnumerable<Course> courses { get; set; }

        public IEnumerable<Article> articles { get; set; }
    }
}
