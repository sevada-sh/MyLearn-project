using MyLearn.Application.Interfaces;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Application.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryrepository;
        public CategoryService(ICategoryRepository categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
           return _categoryrepository.GetAllCategories();
        }
    }
}
