using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Application.ViewModels.Admin;

namespace MyLearn.Mvc.Pages.Admin.Articles
{
    public class EditArticleModel : PageModel
    {
        public AddEditArticleViewModel Article { get; set; }
        private readonly IArticleService _articleservice;
        public EditArticleModel(IArticleService articleservice)
        {
            _articleservice = articleservice;
        }
        public void OnGet(int articleId)
        {
            var article = _articleservice.FindArticles(articleId);
            Article = (AddEditArticleViewModel)article;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var article = _articleservice.FindArticle(Article.ArtilceId);

                Article.ArticleName = article.ArticleName;
                Article.ArticleText = article.ArticleText;
                Article.ArticleWriter = article.ArticleWriter;

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
