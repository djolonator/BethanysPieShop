using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly AppDbContext _appDbContext;

        public ManagerController(IPieRepository pieRepository, ICategoryRepository categoryRepository, AppDbContext appDbContext)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _appDbContext = appDbContext;
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

            _appDbContext.Pies.Update(pie);
            _appDbContext.SaveChanges();

            ViewBag.EditCompletteMessage = "Pie Edited";
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int PieId)
        {
            var pie = await _appDbContext.Pies.FindAsync(PieId);
            _appDbContext.Pies.Remove(pie);
            await _appDbContext.SaveChangesAsync();
            ViewBag.DeleteMessage = "Pie Deleted";
            return View();
        }
    }
}