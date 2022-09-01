using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Application.ViewModels.Admin;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc.Pages.Admin.Articles
{
    public class AddArticleModel : PageModel
    {
        public AddEditArticleViewModel Article { get; set; }
        private readonly IArticleService _articleservice;
        public AddArticleModel(IArticleService articleservice)
        {
            _articleservice = articleservice;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var article = new Article()
                {
                    ArticleName = Article.ArticleName,
                    ArticleText = Article.ArticleText,
                    ArticleWriter = Article.ArticleWriter,
                };

                _articleservice.AddArticle(article);
                _articleservice.Save();

                if (Article.ArticleImage?.Length > 0)
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Article", Article.ArtilceId + ".jpg");
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        Article.ArticleImage.CopyTo(stream);
                    }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
