using BethanysPieShopHRM.Data.Repositories;
using BethanysPieShopHRM.Shared.TeamWolfiesClasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private ScheduleRepository repo;
        public ScheduleController(ScheduleRepository repository)
        {
            repo = repository;
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetSchedulesByDate(string date)
        {

            DateTime dateTime = DateTime.Parse(date); 
            List<Schedule> results = await repo.GetSchedulesByDate(dateTime);
            List<Schedule> test = new List<Schedule>()

            {
                new Schedule() {Id = 1, ShiftDate = new DateTime(2023,01,02), ShiftStart = DateTime.Now.TimeOfDay, ShiftEnd = DateTime.Now.AddHours(5).TimeOfDay }
            };
            return Ok(results ?? test);
        }

        [HttpGet]
        public IActionResult GetSchedulesByEmployee(int id)
        {            
            var results = repo.GetScheduleByEmployeeId(id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule(Schedule schedule)
        {
            await repo.CreateSchedule(schedule);  
            return Ok(schedule);
        }

        [HttpPut]
        public IActionResult UpdateSchedule(Schedule schedule)
        {
            repo.UpdateSchedule(schedule);
            return Ok(schedule);
        }


        [HttpDelete]
        public IActionResult DeleteSchedule(int id) 
        {
            repo.DeleteScheduleById(id);
            return Ok();
        }
    }
}
