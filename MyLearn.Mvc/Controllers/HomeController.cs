
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLearn.Application.Interfaces;
using MyLearn.Application.ViewModels;
using MyLearn.Domain.Models;
using MyLearn.Mvc.Models;
using System.Diagnostics;
using ZarinpalSandbox;

namespace MyLearn.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseservice;
        private readonly IOrderService _orderservice;
        private readonly ICommentService _commentservice;
        private readonly IArticleService _articleservice;

        public HomeController(ILogger<HomeController> logger, ICourseService courseservice, ICommentService commentservice, IArticleService articleservice)
        {
            _logger = logger;
            _courseservice = courseservice;
            _commentservice = commentservice;
            _articleservice = articleservice;
        }

        public IActionResult Index()
        {
            var model = new ShowingArticleAndCourseViewModel()
            {
                courses = _courseservice.GetAllCourses(),
                articles = _articleservice.GetAllArticles()
            };

            return View(model);
        }

        public IActionResult courses(string search)
        {
            ViewBag.Name = search;
            return View("SearchedCourses", _courseservice.Search(search));
        }

        public IActionResult Article(int articleId)
        {
            var article = _articleservice.FindArticle(articleId);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        public IActionResult AddToCart(int courseId)
        {
            var course = _courseservice.SingleOrDefaultOrder(courseId);
            if (course != null)
            {
                int userId = _orderservice.FindFirst();
                var order = _orderservice.FirstOrDefaultOrder(userId);
                if (order != null)
                {
                    var orderDetail = _orderservice.FirstOrDefaultFactorDetails(course.CourseId, order.OrderId);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _orderservice.AddFactorDetail(new FactorDetail()
                        {
                            FactorId = order.OrderId,
                            CourseId = course.CourseId,
                            Price = course.Order.Price,
                            Count = 1
                        });
                    }
                }
                else
                {
                    Factor factor = new Factor()
                    {
                        IsFinally = false,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    };
                    _orderservice.AddOrder(factor);
                    _orderservice.Save();
                    _orderservice.AddFactorDetail(new FactorDetail()
                    {
                        FactorId = order.OrderId,
                        CourseId = course.CourseId,
                        Price = course.Order.Price,
                        Count = 1
                    });
                }
                _orderservice.Save();
            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            int userId = _orderservice.FindFirst();
            var order = _orderservice.ShowCart(userId);
            return View(order);
        }

        public IActionResult RemoveCart(int detailId)
        {
            var factordetail = _orderservice.Find(detailId);
            _orderservice.Remove(factordetail);
            _orderservice.Save();
            return RedirectToAction("ShowCart");
        }

        //public IActionResult Payment()
        //{
        //    var order = _orderservice.SingleOrDefaultOrder();
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    var payment = new Payment(order.Sum);
        //    var res = payment.PaymentRequest($"پرداخت فاکتور شما{order.OrderId}",
        //        "https://localhost:46712/Home/OnlinePayment" + order.OrderId, order.accounts.Email);
        //    if (res.Result.Status == 100)
        //    {
        //        return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}

        //public IActionResult OnlinePayment(int id)
        //{
        //    if (HttpContext.Request.Query["Status"] != "" &&
        //        HttpContext.Request.Query["Status"].ToString().ToLower() == "Ok" &&
        //        HttpContext.Request.Query["Authority"] != "")
        //    {
        //        string authority = HttpContext.Request.Query["Authority"].ToString();
        //        var order = _orderservice.FindFactor(id);
        //        var payment = new Payment(order.);
        //        var res = payment.Verification(authority).Result;
        //        if (res.Status == 100)
        //        {
        //            order.IsFinally = true;
        //            _orderservice.Update(order);
        //            _orderservice.Save();
        //            ViewBag.code = res.RefId;
        //            return View();
        //        }
        //    }

        //    return NotFound();
        //}

        public IActionResult AddComment(int commentId, string comment)
        {
            Comment comments = new Comment()
            {
                CommentId = commentId,
                Commenttext = comment,
            };
            _commentservice.AddComment(comments);
            _commentservice.Save();

            return ViewComponent("CommentComponent", _commentservice.GetCommentByCourseId(commentId));
        }

        public IActionResult CallUs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult SiteRules()
        {
            return View();
        }

        public IActionResult Collaboration()
        {
            return View();
        }

        public IActionResult Course(int courseId)
        {
            var course = _courseservice.FindCourse(courseId);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }


        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult SupportAgent()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}