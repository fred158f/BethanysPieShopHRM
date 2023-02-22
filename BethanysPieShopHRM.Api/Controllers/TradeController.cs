using BethanysPieShopHRM.Data.Repositories;
using BethanysPieShopHRM.Shared.TeamWolfiesClasses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : Controller
    {
        TradeSchdulesRepository repo;
        public TradeController(TradeSchdulesRepository traderepo)
        {
            repo = traderepo;
        }
        [HttpGet]
        public IActionResult GetPendingTrades(int id)
        {
            var result = repo.GetTradesCreatedByMe(id);
            return Ok(result);
        } 
        [HttpGet]
        public IActionResult GetTradeRequests(int id)
        {
            var result = repo.GetTradesSentToMe(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTradeRequest(ScheduleTrade trade)
        {
            repo.CreateTrade(trade);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrade(ScheduleTrade tradesChanges)
        {
            var result = await repo.UpdateTrade(tradesChanges);
            return Ok(result);
        }
    }
}
