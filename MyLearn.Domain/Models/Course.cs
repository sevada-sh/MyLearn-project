using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(30)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseTeacher { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double CoursePrice { get; set; }

        [DataType(DataType.Time)]
        public DateTime CourseTime { get; set; }

        [Required]
        [StringLength(1500)]
        public string CourseDescription { get; set; }

        [Required]
        public int CourseVideosCount { get; set; }

        [Required]
        public string CourseLevel { get; set; }

        [Required]
        public bool CourseIsHolding { get; set; }

        [Required]
        public string CourseTags { get; set; }

        public decimal Discount { get; set; }

        public int OrderId { get; set; }

        public ICollection<CategoryToCourse> CategoryToCourses { get; set; }
        public Order Order { get; set; }
        public List<FactorDetail> factordetails { get; set; }


    }
}
