using CHALLENGE_INTUIT.Dtos;
using CHALLENGE_INTUIT.Models;
using CHALLENGE_INTUIT.Service;
using Microsoft.AspNetCore.Mvc;

namespace CHALLENGE_INTUIT.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
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

            return Ok(result);
        }


        [HttpGet("getById/{id}")]
        public async Task<ActionResult<GetByIdDto>> GetById(int id)
        {
            var result = await _clientService.GetById(id);

            return Ok(result);
        }


        [HttpPost("insert")]
        public async Task<ActionResult<CreateClientDto>> Insert(CreateClientDto dto)
        {
            var result = await _clientService.Insert(dto);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<UpdateClientDto>> Update(UpdateClientDto dto)
        {
            var result = await _clientService.Update(dto);

            return Ok(result);
        }
    }
}
