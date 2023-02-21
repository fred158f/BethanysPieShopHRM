using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.TeamWolfiesClasses
{
    public class Schedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public DateTime DayOfWork { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }

    }
}
