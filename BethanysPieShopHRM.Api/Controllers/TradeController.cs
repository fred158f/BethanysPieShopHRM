using BethanysPieShopHRM.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetMyTrade(int id)
        {
            var result = repo.ge
            return Ok(result)
        }
    }
}
