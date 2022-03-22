using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public ViewResult List( string searchString, string pieCategory)
        {
            IEnumerable<Pie> pies;
            pies = _pieRepository.AllPies.OrderBy(p => p.PieId);

            


            if (!string.IsNullOrEmpty(searchString))
            {
                pies = pies.Where(s => s.Name.ToLower()!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(pieCategory))
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == pieCategory)
                  .OrderBy(p => p.PieId);
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                Categories = new SelectList(_categoryRepository.AllCategories.Select(r => r.CategoryName))
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

            _pieRepository.Edit(pie);
            ViewBag.EditCompletteMessage = "Pie Edited";
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int PieId)
        {
            var success = _pieRepository.Delete(PieId);
            if (success)
            {
                ViewBag.DeleteMessage = "Pie Deleted";
            }
            else 
            {
                ViewBag.DeleteMessage = "Pie Not Found";
            }

            return View();
        }

        public ViewResult CreatePie()
        {
            var vm = new PieVM() { };

            return View(vm);
        }

        public ViewResult AddPie()
        {
            var vm = new PieVM() { };

            return View(vm);
        }

        [HttpPost]
        public ViewResult AddPie(PieVM vm)
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

            _pieRepository.AddPie(pie);

            return View(vm);
        }
    }
}