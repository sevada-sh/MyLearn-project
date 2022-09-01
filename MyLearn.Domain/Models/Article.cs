using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required]
        public string ArticleName { get; set; }

        [Required]
        public string ArticleText { get; set; }

        [Required]
        public int ArticeView { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string ArticleWriter { get; set; }

    }
}
