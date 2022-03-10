using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BethanysPieShop.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ManagerController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            var pies = _pieRepository.GetAllPiesWithCategories().ToList();

            var vm = new PieManagerVM()
            {
                Pies = pies
            };

            return View(vm);
        }

        public IActionResult ViewDetails(int pieId)
        {
            var pie = _pieRepository.GetPieById(pieId);
            var allCategories = _categoryRepository.AllCategories;

            var vm = new PieVM()
            {
                AllergyInformation = pie.AllergyInformation,
                Category = pie.Category,
                CategoryId = pie.CategoryId,
                ImageThumbnailUrl = pie.ImageThumbnailUrl,
                ImageUrl = pie.ImageUrl,
                InStock = pie.InStock,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
                LongDescription = pie.LongDescription,
                Name = pie.Name,
                PieId = pie.PieId,
                ShortDescription = pie.ShortDescription,
                Price = pie.Price,
                Categories = allCategories
            };

            return View(vm);
        }

        public IActionResult Edit(int pieId) 
        {


            return View();
        }
    }
}
