using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.TeamWolfiesClasses
{
    public class Schedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan ShiftStart { get; set; }
        public TimeSpan ShiftEnd { get; set; }

    }
}
