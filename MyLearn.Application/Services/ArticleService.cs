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
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articlerepository;
        public ArticleService(IArticleRepository articlerepository)
        {
            _articlerepository = articlerepository;
        }

        public void AddArticle(Article article)
        {
            _articlerepository.AddArticle(article);
        }

        public void DeleteArticle(Article article)
        {
            _articlerepository.DeleteArticle(article);
        }

        public Article FindArticle(int articleId)
        {
            return _articlerepository.FindArticle(articleId);
        }

        public IEnumerable<Article> FindArticles(int articleId)
        {
            return _articlerepository.FindArticles(articleId);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articlerepository.GetAllArticles().ToList();
        }

        public void Save()
        {
            _articlerepository.Save();
        }
    }
}
