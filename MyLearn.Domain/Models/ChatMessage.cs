using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Models
{
    public class ChatMessage
    {
        public string SenderName { get; set; }
        public string text { get; set; }
        public DateTimeOffset SendAt { get; set; }
    }
}
