using CategoryApi.AppDbContext;
using CategoryApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryApi.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext _context;

        public CategoryRepository (CategoryContext context)
        {
            _context = context;
        }

        public Category AddCategory(Category category)
        {

            _context.Categories.Add(category);

            _context.SaveChanges();

            return category;
        }

        public void DeleteCategory(int categoryId)
        {
            
            var categoryToDelete = _context.Categories.Where(x => x.CategoryId == categoryId).FirstOrDefault();
            
            _context.Categories.Remove(categoryToDelete);

            _context.SaveChanges();

        }

        public IEnumerable<Category> GetAllCategories() 
        {
            return _context.Categories;
        }

        public Category GetCategory(int categoryId)
        {
            return _context.Categories.FirstOrDefault(a => a.CategoryId == categoryId);
           // _context.Categories.FindAsync(categoryId);
        }

        public int UpdateCategory(Category category)
        {
            
            _context.Update(category);

            _context.SaveChanges();

            return category.CategoryId;

        }

       
    }
}
