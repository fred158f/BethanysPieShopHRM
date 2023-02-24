using BethanysPieShopHRM.Shared.TeamWolfiesClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.Models
{
    public class CalendarDay
    {
        public enum DayState
        {
            None,
            Partial,
            Full,
            NbrOfItems
        }
        public DayState State { get; set; } = DayState.None;
        public DateTime Date { get; set; }
        public string DateValue { get; set; }
        public string DayName { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();

        public void GetState()
        {
            Random rnd = new Random();
            State = (DayState)rnd.Next((int)DayState.NbrOfItems);
        }
    }
}
