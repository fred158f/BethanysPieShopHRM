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
           var result = new List<Schedule>();
            return result;
        }

        public async void CreateSchedule(Schedule schedule)
        {
            string serialized = JsonConvert.SerializeObject(schedule);
            StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44340/");
                HttpResponseMessage response = await client.PostAsync("api/Schedule", content);
              
            }            
        }

        public async Task<List<Schedule>> GetSchedulesFromDate(DateTime date)
        {            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44340/");
                var response = await client.GetAsync($"api/Schedule/{date.ToShortDateString()}");
                var content = await response.Content.ReadAsStringAsync();
                var events = JsonConvert.DeserializeObject<List<Schedule>>(content);
                return events;
            }
        }

    }
}
