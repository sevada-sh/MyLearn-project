using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyLearn.Application.Interfaces;
using MyLearn.Application.Security;
using MyLearn.Application.ViewModels.Accounts;
using MyLearn.Domain.Models;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;

namespace MyLearn.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(IAccountService accountService, SignInManager<IdentityUser> signInManger, UserManager<IdentityUser> userManager)
        {
            _accountService = accountService;
            _signInManager = signInManger;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model, IFormCollection form)
        {
            if (ModelState.IsValid)
            {

                Account user = new Account()
                {
                    Email = model.Email.Trim().ToLower(),
                    Password = PasswordHelper.EncodePasswordMd5(model.Password),
                    UserName = model.UserName
                };

                _accountService.RegisterUser(user);
                _accountService.Save();

                return RedirectToAction("Login", "Account");
            }

            string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            string secretKey = "6Le72MwgAAAAAEwP7GdK6DH6SceVpmLbH3fuDJ_L";
            string gRecaptchaResponse = form["g-recaptcha-response"];

            var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            // send post data
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
            }

            // receive the response now
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            // validate the response from Google reCaptcha
            var captChaesponse = JsonConvert.DeserializeObject<reCaptchaResponse>(result);
            if (!captChaesponse.Success)
            {
                ViewBag.Message = "Sorry, please validate the reCAPTCHA";
                return View();
            }

            // go ahead and write code to validate username password against database

            ViewBag.IsSuccess = true;

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            //var model = new LoginViewModel()
            //{
            //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            //};
            //return View(model);
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (!_accountService.IsExistUser(model.Email, model.Password))
                {
                    ModelState.AddModelError("Email", "کاربری پیدا نشد ...");
                    return View(model);
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                         new Claim(ClaimTypes.Name,model.Email),
                         new Claim(ClaimTypes.NameIdentifier,model.Email),
                         new Claim(ClaimTypes.Email,model.Email)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = model.RememberMe
                    };

                    HttpContext.SignInAsync(principal, properties);

                    return RedirectToAction("Index", "Home");
                }
            }


            string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            string secretKey = "6Le72MwgAAAAAEwP7GdK6DH6SceVpmLbH3fuDJ_L";
            string gRecaptchaResponse = form["g-recaptcha-response"];

            var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            // send post data
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
            }

            // receive the response now
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            // validate the response from Google reCaptcha
            var captChaesponse = JsonConvert.DeserializeObject<reCaptchaResponse>(result);
            if (!captChaesponse.Success)
            {
                ViewBag.Message = "Sorry, please validate the reCAPTCHA";
                return View();
            }

            //// go ahead and write code to validate username password against database

            ViewBag.IsSuccess = true;

            //model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return View(model);


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    var redirectUrl = Url.Action("ExternalLoginCallBack", "Account",
        //        new { ReturnUrl = returnUrl });

        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        //    return new ChallengeResult(provider, properties);
        //}

        //public async Task<IActionResult> ExternalLoginCallBack(string remoteError = null)
        //{
        //    var loginViewModel = new LoginViewModel()
        //    {
        //        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        //    };

        //    if (remoteError != null)
        //    {
        //        ModelState.AddModelError("", $"Error : {remoteError}");
        //        return View("Login", loginViewModel);
        //    }

        //    var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
        //    if (externalLoginInfo == null)
        //    {
        //        ModelState.AddModelError("ErrorLoadingExternalLoginInfo", $"مشکلی پیش آمد");
        //        return View("Login", loginViewModel);
        //    }

        //    var signInResult = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
        //        externalLoginInfo.ProviderKey, false, true);

        //    if (signInResult.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);

        //    if (email != null)
        //    {
        //        var user = await _userManager.FindByEmailAsync(email);
        //        if (user == null)
        //        {
        //            var userName = email.Split('@')[0];
        //            user = new IdentityUser()
        //            {
        //                UserName = (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
        //                Email = email,
        //                EmailConfirmed = true
        //            };

        //            await _userManager.CreateAsync(user);
        //        }

        //        await _userManager.AddLoginAsync(user, externalLoginInfo);
        //        await _signInManager.SignInAsync(user, false);

        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View();
        //}

    }
}
