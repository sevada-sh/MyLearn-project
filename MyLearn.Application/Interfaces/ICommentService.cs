using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetCommentByCourseId(int courseId);

        bool AddComment(Comment comment);

        void Save();
    }
}
