using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentByCourseId(int courseId);

        bool AddComment(Comment comment);

        void Save();
    }
}
