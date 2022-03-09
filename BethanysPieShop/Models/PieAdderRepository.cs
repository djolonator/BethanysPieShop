using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieAdderRepository : IPieAdderRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieAdderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void CreatePie(Pie pie)
        {
            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();
            
        }
    }
}
