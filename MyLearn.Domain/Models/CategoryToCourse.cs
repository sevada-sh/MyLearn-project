using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class CategoryToCourse
    {
        public int CategoryId { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public Category Category { get; set; }
    }
}
