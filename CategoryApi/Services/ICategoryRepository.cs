using CategoryApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryApi.Services
{
   public interface ICategoryRepository
    {
        //Category GetCategory(Guid categoryId);
        Category AddCategory(Category category);
        void DeleteCategory(int categoryId);
         int UpdateCategory(Category category);
       // Category UpdateCategory(Category category);
        IEnumerable<Category> GetAllCategories();
        Category GetCategory(int categoryId);
    }
}
