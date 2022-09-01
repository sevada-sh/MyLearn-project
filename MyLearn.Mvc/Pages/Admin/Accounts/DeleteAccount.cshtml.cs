using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;

namespace MyLearn.Mvc.Pages.Admin.Accounts
{
    public class DeleteAccountModel : PageModel
    {
        private readonly IAccountService _accountservice;
        public DeleteAccountModel(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }
        public void OnGet(int accountId)
        {
            _accountservice.FindAccount(accountId);
        }

        public IActionResult OnPost(int courseId)
        {
            var course = _accountservice.FindAccount(courseId);
            _accountservice.DeleteAccount(course);
            _accountservice.Save();

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Accounts", ".jpg");
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }

            return RedirectToAction("Index");
        }
    }
}
