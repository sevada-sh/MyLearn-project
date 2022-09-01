using MyLearn.Data.Context;
using MyLearn.Domain.Interfaces;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyLearnContext _context;
        public CategoryRepository(MyLearnContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }
    }
}
