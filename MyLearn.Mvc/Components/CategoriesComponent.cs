using Microsoft.AspNetCore.Mvc;
using MyLearn.Application.Interfaces;

namespace MyLearn.Mvc.Components
{
    public class CategoriesComponent : ViewComponent
    {
        private readonly ICategoryService _categoryservice;
        public CategoriesComponent(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/CategoriesComponent.cshtml", _categoryservice.GetAllCategories());
        }
    }
}
