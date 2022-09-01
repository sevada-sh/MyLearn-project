using Microsoft.AspNetCore.Mvc;

namespace MyLearn.Mvc.Areas.UserDashBoard.Controllers
{
    public class UserDashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult Wallet()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Logout", "Account");
        }

        public IActionResult MyCourses()
        {
            return View();
        }

        public IActionResult EditAccountSettings()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
