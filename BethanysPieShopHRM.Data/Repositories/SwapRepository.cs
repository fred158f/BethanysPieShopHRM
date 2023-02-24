using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared.TeamWolfiesClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Data.Repositories
{
    public class SwapRepository
    {
        private AppDbContext _appDbContext;

        public SwapRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Swap> GetWhere(int id) //you would never know this id
        {
            return await _appDbContext.Swap.FirstOrDefaultAsync(x => x.Id == id);
        } 
         
        public async Task<List<Swap>> GetSwapsCreatedByMe(int id)
        {
            return await _appDbContext.Swap.Where(x => x.SenderId == id).ToListAsync();
        }  
        public async Task<List<Swap>> GetSwapsSentToMe(int id)
        {
            return await _appDbContext.Swap.Where(x => x.RecieverId == id).ToListAsync();
        }

        public async Task<Swap> CreateSwap(Swap schedule)
        {
            await _appDbContext.Swap.AddAsync(schedule);
            _appDbContext.SaveChangesAsync();
            return schedule;
        }
        public async Task<Swap> UpdateSwap(Swap scheduleChanges)
        {
            var original = await _appDbContext.Swap.FirstOrDefaultAsync(x => x.Id == scheduleChanges.Id);

            original.RecieverId = scheduleChanges.RecieverId;
            original.SwapStatusInt = scheduleChanges.SwapStatusInt;
            _appDbContext.SaveChangesAsync();

            return original;
        }

        public async void DeleteSwap(Swap schedule)
        {
            _appDbContext.Swap.Remove(schedule);
            await _appDbContext.SaveChangesAsync();
        }
    }
}

