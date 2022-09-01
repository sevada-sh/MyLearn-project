using MyLearn.Data.Context;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MyLearnContext _context;
        public CommentRepository(MyLearnContext context)
        {
            _context = context;
        }
        public bool AddComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Comment> GetCommentByCourseId(int courseId)
        {
            return _context.Comments.Where(c => c.courses.CourseId == courseId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
