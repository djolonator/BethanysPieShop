using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class PieAdderController : Controller
    {
        private readonly IPieAdderRepository _pieAdderRepository;

        public PieAdderController(IPieAdderRepository pieAdderRepository)
        {
            _pieAdderRepository = pieAdderRepository;
        }

        public IActionResult AddPie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPie(Pie pie)
        {
            if (ModelState.IsValid)
            {
                _pieAdderRepository.CreatePie(pie);

                 return RedirectToAction("PieAdded");
            }
            return View(pie);
        }

        public IActionResult PieAdded()
        {
            ViewBag.CheckoutCompleteMessage = "New pie added successful";
            return View();
        }
    }
}
