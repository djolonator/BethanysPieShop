using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BethanysPieShop.ViewModels
{
    public class PiesListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        // //public string CurrentCategory { get; set; }
        //// public string? PieCategory { get; set; }
        // public string? SearchString { get; set; }
        // //public SelectList? Categories { get; set; }
        // public IEnumerable<Category> Categories { get; set; }
        // public string? Category { get; set; }
        //public List<Pie>? Pies { get; set; }
        public SelectList? Categories { get; set; }
        public string? PieCategory { get; set; }
        public string? SearchString { get; set; }


    }
}
