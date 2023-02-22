using BethanysPieShopHRM.Data.Repositories;
using BethanysPieShopHRM.Shared.TeamWolfiesClasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private ScheduleRepository repo;
        public ScheduleController(ScheduleRepository repository)
        {
            repo= repository;
        }

        [HttpGet]
        public IActionResult GetSchedulesByDate(DateTime date)
        {            
            var results = repo.GetSchedulesByDate(date);
            return Ok(results);
        }        
        
        [HttpGet]
        public IActionResult GetSchedulesByEmployee(int id)
        {            
            var results = repo.GetScheduleByEmployeeId(id);
            return Ok(results);
        }

        [HttpDelete]
        public IActionResult DeleteSchedule(int id) 
        {
            repo.DeleteScheduleById(id);
            return Ok();
        }
    }
}
