using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc.Pages.Admin.Articles
{
    public class ShowArticlesModel : PageModel
    {
        public IEnumerable<Article> Articles { get; set; }
        private readonly IArticleService _articleservice;
        public ShowArticlesModel(IArticleService articleservice)
        {
            _articleservice = articleservice;
        }
        public void OnGet()
        {
            Articles = _articleservice.GetAllArticles();
        }
    }
}
