using Microsoft.AspNetCore.Mvc;
using MyLearn.Application.Interfaces;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc.Components
{
    public class CommentsComponent : ViewComponent
    {
        private readonly ICommentService _commentservice;
        public CommentsComponent(ICommentService commentservice)
        {
            _commentservice = commentservice;
        }
        public async Task<IViewComponentResult> InvokeAsync(int courseId)
        {
            return View("/Views/Components/CommentsComponent.cshtml", _commentservice.GetCommentByCourseId(courseId));

        }
    }
}
