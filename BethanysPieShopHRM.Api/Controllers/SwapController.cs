using BethanysPieShopHRM.Data.Repositories;
using BethanysPieShopHRM.Shared.TeamWolfiesClasses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwapController : Controller
    {
        SwapRepository repo;
        public SwapController(SwapRepository swapRepo)
        {
            repo = swapRepo;
        }

        [HttpGet]
        public IActionResult GetPendingSwaps(int id)
        {
            var result = repo.GetSwapsCreatedByMe(id);
            return Ok(result);
        } 

        [HttpGet]
        public IActionResult GetSwapRequests(int id)
        {
            var result = repo.GetSwapsSentToMe(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateSwapRequest(Swap swap)
        {
            repo.CreateSwap(swap);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSwap(Swap swapChanges)
        {
            var result = await repo.UpdateSwap(swapChanges);
            return Ok(result);
        }
    }
}
