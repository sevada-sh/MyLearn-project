using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLearn.Application.Interfaces;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc.Pages.Admin.Accounts
{
    public class ShowAccountsModel : PageModel
    {
        private readonly IAccountService _accountservice;
        public IEnumerable<Account> Accounts { get; set; }
        public ShowAccountsModel(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }
        public void OnGet()
        {
            Accounts = _accountservice.GetAllAccounts();
        }
    }
}
