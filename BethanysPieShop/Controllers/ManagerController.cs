using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class ManagerController : Controller
    {
        
        private readonly IPieRepository _pieRepository;

        public ManagerController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
            
        }

        public ViewResult List()
        {
            IEnumerable<Pie> pies;
            pies = _pieRepository.AllPies.OrderBy(p => p.PieId);

            return View(new PiesListViewModel
            {
                Pies = pies,
                
            });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            return View(selectedPie);
        }
    }
}
