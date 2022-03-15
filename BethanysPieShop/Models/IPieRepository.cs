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
        void ViewDetails();
        void CreatePie();
        void Edit();
        void Delete();
    }
}
