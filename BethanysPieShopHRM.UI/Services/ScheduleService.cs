using BethanysPieShopHRM.Shared.TeamWolfiesClasses;
using System;
using System.Collections.Generic;

namespace BethanysPieShopHRM.UI.Services
{
    public class ScheduleService
    {
        private int currentUserId;
        public ScheduleService()
        {
            
        }

        public IEnumerable<Schedule> GetByDatetime(DateTime date)
        {
            List<Schedule> list = new List<Schedule>()
            {
                new Schedule()
                {
                    EmployeeId = 1,
                    Id = 0,
                    ShiftStart = date.AddHours(11),
                    ShiftEnd = date.AddHours(16)
                },
                new Schedule()
                {
                    EmployeeId = 2,
                    Id = 1,
                    ShiftStart = date.AddHours(11),
                    ShiftEnd = date.AddHours(16)
                },
                new Schedule()
                {
                    EmployeeId = 3,
                    Id = 2,
                    ShiftStart = date.AddHours(11),
                    ShiftEnd = date.AddHours(16)
                }
            };

            return list;
        }

        public void CreateSchedule(Schedule schedule)
        {

        }

    }
}
