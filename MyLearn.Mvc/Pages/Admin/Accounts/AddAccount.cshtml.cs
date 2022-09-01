using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Application.ViewModels.Admin;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc.Pages.Admin.Accounts
{
    public class AddAccountModel : PageModel
    {
        public AddEditAccountViewModel Account { get; set; }
        private readonly IAccountService _accountservice;
        public AddAccountModel(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var account = new Account()
                {
                    Email = Account.Email,
                    Password = Account.Password,
                    UserName = Account.UserName,
                    IsAdmin = Account.IsAdmin,
                    IsTeacher = Account.IsTeacher,
                    IsWriter = Account.IsWriter

                };

                _accountservice.Save();

                if (Account.AccountImage?.Length > 0)
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images" ,"Accounts", Account.UserId + ".jpg");
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
