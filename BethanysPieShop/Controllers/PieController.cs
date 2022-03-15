using System.Collections.Generic;
using System.Linq;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }

        public ViewResult PieManager()
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
            {//mapiranje
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

        public IActionResult Edit(PieVM vm)
        {
            var pie = new Pie();

            pie.AllergyInformation = vm.AllergyInformation;
            pie.Category = vm.Category;
            pie.CategoryId = vm.CategoryId;
            pie.ImageThumbnailUrl = vm.ImageThumbnailUrl;
            pie.ImageUrl = vm.ImageUrl;
            pie.InStock = vm.InStock;
            pie.IsPieOfTheWeek = vm.IsPieOfTheWeek;
            pie.LongDescription = vm.LongDescription;
            pie.Name = vm.Name;
            pie.PieId = vm.PieId;
            pie.ShortDescription = vm.ShortDescription;
            pie.Price = vm.Price;

            //_appDbContext.Pies.Update(pie);
            //_appDbContext.SaveChanges();

            ViewBag.EditCompletteMessage = "Pie Edited";
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int PieId)
        {
            //var pie = await _appDbContext.Pies.FindAsync(PieId);
            //_appDbContext.Pies.Remove(pie);
            //_appDbContext.SaveChangesAsync();
            ViewBag.DeleteMessage = "Pie Deleted";
            return View();
        }

        public ViewResult AddPie()
        {
            var vm = new PieVM(){ };

            return View(vm);
        }
    }
}
