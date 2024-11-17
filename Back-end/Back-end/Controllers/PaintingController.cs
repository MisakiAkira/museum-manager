using Back_end.Models.DTO;
using Back_end.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/painting")]
    public class PaintingController : ControllerBase
    {
        private readonly IPaintingDBService _paintingDBService;

        public PaintingController(IPaintingDBService paintingDBService)
        {
            _paintingDBService = paintingDBService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaintingList()
        {
            IList<PaintingDTO> paintingList = await _paintingDBService.GetPaintingList();
            return Ok(paintingList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaintingById(int id)
        {
            PaintingDTO painting = await _paintingDBService.GetPaintingById(id);
            return Ok(painting);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePainting(int id)
        {
            return Ok(await _paintingDBService.DeletePainting(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostPainting(PaintingDTO painting)
        { 
            return Ok(await _paintingDBService.PostPainting(painting));
        }

        [HttpPut]
        public async Task<IActionResult> PutPainting(PaintingDTO painting)
        {
            return Ok(await _paintingDBService.PutPainting(painting));
        }
    }
}
