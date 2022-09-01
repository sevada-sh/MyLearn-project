using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class Account
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(250)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsWriter { get; set; }

        public bool IsTeacher { get; set; }

        public List<Factor> factors { get; set; }
        public List<Comment> comments { get; set; }
    }
}
