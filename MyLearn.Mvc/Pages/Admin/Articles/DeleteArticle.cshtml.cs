using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;

namespace MyLearn.Mvc.Pages.Admin.Articles
{
    public class DeleteArticleModel : PageModel
    {
        private readonly IArticleService _articleservice;
        public DeleteArticleModel(IArticleService articleservice)
        {
            _articleservice = articleservice;
        }
        public void OnGet(int articleId)
        {
            _articleservice.FindArticle(articleId);
        }

        public IActionResult OnPost(int courseId)
        {
            var article = _articleservice.FindArticle(courseId);
            _articleservice.DeleteArticle(article);
            _articleservice.Save();

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Article", ".jpg");
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }

            return RedirectToAction("Index");
        }
    }
}
