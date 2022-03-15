using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository: IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        


        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.Include(c => c.Category).FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> GetAllPiesWithCategories() 
        {
            return _appDbContext.Pies.Include(c => c.Category);
        }

        public void Edit(PieVM vm)
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
        }

        public void Delete(int PieId)
        {
            //Pie pie = new Pie();
            _appDbContext.Pies.Remove(GetPieById(PieId));
            _appDbContext.SaveChanges();
        }

        public void AddPie(PieVM vm)
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

            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();
        }
    }
}
