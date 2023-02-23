using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.Models
{
    public class DayEvent
    {
        public int DayEventId { get; set; }
        public string Note { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string DateValue { get; set; }
        public string DayName { get; set; }
        public string Message { get; set; }
    }
}
