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
    public class ScheduleRepository
    {
        private AppDbContext _appDbContext;

        public ScheduleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Schedule> GetWhere(int id)
        {
            return await _appDbContext.Schedules.FirstOrDefaultAsync(x => x.Id == id);
        } 

        public async Task<List<Schedule>> GetSchedulesByDate(string dato)
        {
            return await _appDbContext.Schedules.Where(x => x.ShiftStart.ToShortDateString() == dato).ToListAsync();
        }
        public async Task<List<Schedule>> GetScheduleByEmployeeId(int id)
        {
            return await _appDbContext.Schedules.Where(x => x.EmployeeId == id).ToListAsync();
        }

        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            await _appDbContext.Schedules.AddAsync(schedule);
            _appDbContext.SaveChangesAsync();
            return schedule;
        }
        public async Task<Schedule> UpdateSchedule(Schedule scheduleChanges)
        {
            var original = await _appDbContext.Schedules.FirstOrDefaultAsync(x => x.Id == scheduleChanges.Id);

            original.EmployeeId = scheduleChanges.EmployeeId;
            original.ShiftStart = scheduleChanges.ShiftStart;
            original.ShiftEnd = scheduleChanges.ShiftEnd;
            _appDbContext.SaveChangesAsync();

            return original;
        }

        public async void DeleteScheduleById(int id)
        {
            var schedule = await this.GetWhere(id);

            _appDbContext.Schedules.Remove(schedule);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
