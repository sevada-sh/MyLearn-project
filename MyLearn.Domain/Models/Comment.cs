using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Commenttext { get; set; }

        public int AccountId { get; set; }

        public Account accounts { get; set; }

        public Course courses { get; set; }
    }
}
