using BethanysPieShopHRM.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BethanysPieShopHRM.ComponentsLibrary.CalendarScheduler
{
    public partial class Calendar
    {
        List<string> monthNames = new List<string>();
        List<string> days = new List<string>();
        List<WeekClass> weeks = new List<WeekClass>();
        DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime endDate = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).AddMonths(1).AddDays(-1);

        protected override void OnInitialized()
        {
            monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames.ToList().FindAll(x=> x != string.Empty);
            GenerateCalendarHead();
            GeneratorCalendarBody();
            base.OnInitialized();
        }

        private void LoadCalendar(ChangeEventArgs e)
        {
            int monthIndex = DateTime.ParseExact(e.Value.ToString(), "MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")).Month;
            startDate = new DateTime(DateTime.Now.Year, monthIndex, 1);
            endDate = (new DateTime(DateTime.Now.Year, monthIndex, 1)).AddMonths(1).AddDays(-1);
            GeneratorCalendarBody();

        }

        private void GenerateCalendarHead()
        {
            days = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames.ToList();
        }

        private void GeneratorCalendarBody()
        {
            weeks.Clear();
            int weekDayCounter = 0;
            WeekClass week = new WeekClass();
            List<CalendarDay> dates = new List<CalendarDay>();
            int totalDays = endDate.Day;
            int totalDaysAdded = 0;

            // Iterate through all days from startdate to enddate
            for (DateTime currentDay = startDate; currentDay <= endDate;)
            {
                // Get index of the currentDay
                int weekDayIndex = (int)currentDay.DayOfWeek;

                if (weekDayIndex == weekDayCounter)
                {
                    CalendarDay dayToAdd = new CalendarDay()
                    {
                        Date = currentDay,
                        DateValue = currentDay.ToString("dd-MMM-yyyy"),
                        DayName = currentDay.ToString("dddd")
                    };
                    dates.Add(dayToAdd);
                    dayToAdd.GetState();
                    
                    currentDay = currentDay.AddDays(1);
                    totalDaysAdded++;
                }
                else
                {
                    dates.Add(null);
                }

                // If we've reached saturday (index 6) add the week and reset dayCounter
                if (weekDayCounter == 6)
                {
                    week = new WeekClass();
                    week.Dates = dates;
                    weeks.Add(week);

                    dates = new List<CalendarDay>();
                    weekDayCounter = 0;
                }
                else
                {
                    weekDayCounter++;
                }

                // If there are no more days to add, then add the week and break
                if (totalDaysAdded == totalDays)
                {
                    // foreach empty day add a null value
                    for (int i = weekDayCounter; i < 7; i++)
                    {
                        dates.Add(null);
                    }
                    week = new WeekClass();
                    week.Dates = dates;
                    weeks.Add(week);
                    break;
                }
            }
        }
    }
}
