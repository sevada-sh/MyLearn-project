using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Domain.Interfaces
{
    public interface IArticleRepository
    {
        void Save();

        IEnumerable<Article> GetAllArticles();

        Article FindArticle(int articleId);

        void DeleteArticle(Article article);

        void AddArticle(Article article);

        IEnumerable<Article> FindArticles(int articleId);

    }
}
