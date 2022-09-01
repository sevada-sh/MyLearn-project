using MyLearn.Application.Interfaces;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentrepository;
        public CommentService(ICommentRepository commentrepository)
        {
            _commentrepository = commentrepository;
        }
        public bool AddComment(Comment comment)
        {
            return _commentrepository.AddComment(comment);
        }

        public IEnumerable<Comment> GetCommentByCourseId(int courseId)
        {
            return _commentrepository.GetCommentByCourseId(courseId);
        }

        public void Save()
        {
            _commentrepository.Save();
        }
    }
}
