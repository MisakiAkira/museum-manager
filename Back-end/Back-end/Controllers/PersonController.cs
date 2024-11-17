using Back_end.Models.DTO;
using Back_end.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonDBService _personDBService;

        public PersonController(IPersonDBService personDBService)
        {
            _personDBService = personDBService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonList()
        {
            IList<PersonDTO> people = await _personDBService.GetPersonList();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            PersonDTO person = await _personDBService.GetPersonById(id);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            return Ok(await _personDBService.DeletePerson(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostPerson(PersonDTO person)
        {
            return Ok(await _personDBService.PostPerson(person));
        }

        [HttpPut]
        public async Task<IActionResult> PutPerson(PersonDTO person)
        {
            return Ok(await _personDBService.PutPerson(person));
        }
    }
}
