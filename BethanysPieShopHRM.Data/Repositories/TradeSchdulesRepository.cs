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
    public class TradeSchdulesRepository
    {
        private AppDbContext _appDbContext;

        public TradeSchdulesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ScheduleTrade> GetWhere(int id) //you would never know this id
        {
            return await _appDbContext.ScheduleTrades.FirstOrDefaultAsync(x => x.Id == id);
        } 
         
        public async Task<List<ScheduleTrade>> GetTradesCreatedByMe(int id)
        {
            return await _appDbContext.ScheduleTrades.Where(x => x.SenderId == id).ToListAsync();
        }  
        public async Task<List<ScheduleTrade>> GetTradesSentToMe(int id)
        {
            return await _appDbContext.ScheduleTrades.Where(x => x.RecieverId == id).ToListAsync();
        }

        public async Task<ScheduleTrade> CreateTrade(ScheduleTrade schedule)
        {
            await _appDbContext.ScheduleTrades.AddAsync(schedule);
            _appDbContext.SaveChangesAsync();
            return schedule;
        }
        public async Task<ScheduleTrade> UpdateTrade(ScheduleTrade scheduleChanges)
        {
            var original = await _appDbContext.ScheduleTrades.FirstOrDefaultAsync(x => x.Id == scheduleChanges.Id);

            original.RecieverId = scheduleChanges.RecieverId;
            original.TradeStatus = scheduleChanges.TradeStatus;
            _appDbContext.SaveChangesAsync();

            return original;
        }

        public async void DeleteTrade(ScheduleTrade schedule)
        {
            _appDbContext.ScheduleTrades.Remove(schedule);
            await _appDbContext.SaveChangesAsync();
        }
    }
}

