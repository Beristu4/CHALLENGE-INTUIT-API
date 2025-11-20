using CHALLENGE_INTUIT.Dtos;
using CHALLENGE_INTUIT.Models;
using CHALLENGE_INTUIT.Service;
using Microsoft.AspNetCore.Mvc;

namespace CHALLENGE_INTUIT.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        public ClientController(ClientService clientService) 
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllDto>>> GetAll()
        {
            var result = await _clientService.GetAll();

            if(result == null) NotFound("No se encontraron Clientes");

            return Ok(result ?? new List<GetAllDto>()) ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdDto>> GetById(int id)
        {
            var result = await _clientService.GetById(id);

            if (result == null) NotFound($"No se Cliente que coincida con {id}");

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<GetByIdDto>> GetByName([FromQuery] string name)
        {
            var result = await _clientService.Search(name);

            if (result == null) NotFound($"No se Cliente que coincida con {name}");

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<CreateClientDto>> Insert(CreateClientDto dto)
        {
            var result = await _clientService.Insert(dto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateClientDto>> Update(UpdateClientDto dto)
        {
            var result = await _clientService.Update(dto);

            return Ok(result);
        }
    }
}
