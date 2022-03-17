using BethanysPieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);
        IEnumerable<Pie> GetAllPiesWithCategories();
        void AddPie(Pie pie);
        void Edit(Pie pie);
        bool Delete(int PieId);
    }
}
