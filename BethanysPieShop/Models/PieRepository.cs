﻿using System;
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

        public void CreatePie(Pie pie)
        {
            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();

        }

        public void ViewDetails()
        {
            
        }

        public void Edit()
        {
            
        }

        public void Delete()
        {
            
        }

        public void CreatePie()
        {
            throw new NotImplementedException();
        }
    }
}
