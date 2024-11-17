using Back_end.Models.DTO;
using Back_end.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/restorer")]
    public class RestorerController : ControllerBase
    {
        private readonly IRestorerDBService _restorerDBService;

        public RestorerController(IRestorerDBService restorerDBService)
        {
            _restorerDBService = restorerDBService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestorerList()
        {
            IList<RestorerDTO> restorers = await _restorerDBService.GetRestorerList();
            return Ok(restorers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestorerById(int id)
        {
            RestorerDTO restorer = await _restorerDBService.GetRestorerById(id);
            return Ok(restorer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestorer(int id)
        {
            return Ok(await _restorerDBService.DeleteRestorer(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostRestorer(RestorerDTO restorer)
        {
            return Ok(await _restorerDBService.PostRestorer(restorer));
        }

        [HttpPut]
        public async Task<IActionResult> PutRestorer(RestorerDTO restorer)
        {
            return Ok(await _restorerDBService.PutRestorer(restorer));
        }
    }
}
