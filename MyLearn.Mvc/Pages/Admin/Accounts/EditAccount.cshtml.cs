using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Application.ViewModels.Admin;

namespace MyLearn.Mvc.Pages.Admin.Accounts
{
    public class EditAccountModel : PageModel
    {
        private readonly IAccountService _accountservice;
        public AddEditAccountViewModel Account { get; set; }
        public EditAccountModel(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }
        public void OnGet(int accountId)
        {
            var account = _accountservice.FindAccounts(accountId);
            Account = (AddEditAccountViewModel)account;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var account = _accountservice.FindAccount(Account.UserId);

                account.UserName = Account.UserName;
                account.Email = Account.Email;
                account.Password = Account.Password;
                account.IsAdmin = Account.IsAdmin;
                account.IsTeacher = Account.IsTeacher;
                account.IsWriter = Account.IsWriter;


                _accountservice.Save();

                if (Account.AccountImage?.Length > 0)
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Accounts", Account.UserId + ".jpg");
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        Account.AccountImage.CopyTo(stream);
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
