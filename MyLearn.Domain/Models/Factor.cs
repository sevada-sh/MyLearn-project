using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class Factor
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public bool IsFinally { get; set; }


        public Account accounts { get; set; }
        public List<FactorDetail> factordetails { get; set; }
    }
}
