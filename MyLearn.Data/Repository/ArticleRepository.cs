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
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyLearnContext _context;
        public ArticleRepository(MyLearnContext context)
        {
            _context = context;
        }

        public void AddArticle(Article article)
        {
            _context.Articles.Add(article);
        }

        public void DeleteArticle(Article article)
        {
            _context.Articles.Remove(article);
        }

        public Article FindArticle(int articleId)
        {
            return _context.Articles.Find(articleId);
        }

        public IEnumerable<Article> FindArticles(int articleId)
        {
            return (IEnumerable<Article>)_context.Articles.Find(articleId);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
