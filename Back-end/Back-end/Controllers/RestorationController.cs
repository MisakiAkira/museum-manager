using Back_end.Models.DTO;
using Back_end.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/restoration")]
    public class RestorationController : ControllerBase
    {
        private readonly IRestorationDBService _restorationDBService;

        public RestorationController(IRestorationDBService restorationDBService)
        {
            _restorationDBService = restorationDBService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestorationList()
        {
            IList<RestorationDTO> restorationList = await _restorationDBService.GetRestorationList();
            return Ok(restorationList);
        }

        [HttpGet("{restorerId}&{paintingId}")]
        public async Task<IActionResult> GetRestorationById(int restorerId, int paintingId)
        {
            RestorationDTO restoration = await _restorationDBService.GetRestorationById(restorerId, paintingId);
            return Ok(restoration);
        }

        [HttpDelete("{restorerId}&{paintingId}")]
        public async Task<IActionResult> DeleteRestoration(int restorerId, int paintingId)
        {
            return Ok(await _restorationDBService.DeleteRestoration(restorerId, paintingId));
        }

        [HttpPost]
        public async Task<IActionResult> PostRestoration(RestorationDTO restoration)
        {
            return Ok(await _restorationDBService.PostRestoration(restoration));
        }

        [HttpPut]
        public async Task<IActionResult> PutRestoration(RestorationDTO restoration)
        {
            return Ok(await _restorationDBService.PutRestoration(restoration));
        }
    }
}
