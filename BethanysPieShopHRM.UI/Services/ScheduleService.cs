using BethanysPieShopHRM.Shared.TeamWolfiesClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public class ScheduleService
    {
        public List<Schedule> GetByDatetime(DateTime date)
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

        public async void CreateSchedule(Schedule schedule)
        {
            string serialized = JsonConvert.SerializeObject(schedule);
            StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync("api/ScheduleController", content);

                if (!response.IsSuccessStatusCode)                
                    throw new Exception("Api returns bad");                
            }            
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesFromDate(DateTime date)
        {
            string searchBy = date.ToShortDateString();    
            
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"api/ScheduleController/{searchBy}");
                var content = await response.Content.ReadAsStringAsync();
                var events = System.Text.Json.JsonSerializer.Deserialize<List<Schedule>>(content);
                return events;
            }
        }

    }
}
