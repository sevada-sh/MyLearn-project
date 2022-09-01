using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class FactorDetail
    {
        [Key]
        public int DetailId { get; set; }

        [Required]
        public int FactorId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }


        public Factor factor { get; set; }
        public Course courses { get; set; }
    }
}
