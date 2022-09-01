using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLearn.Application.Interfaces;

namespace MyLearn.Mvc.Components
{
    public class AccountMenuComponent : ViewComponent
    {
        private readonly IAccountService _accountService;
        public AccountMenuComponent(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/AccountMenuComponent.cshtml");
        }
    }

}