using B3.Domain.Commands.Inputs;
using B3.Domain.Commands.Results;
using B3.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdbController : ControllerBase
    {
        private readonly ICdbService _service;

        public CdbController(ICdbService service)
        {
            _service = service;
        }




        [HttpPost("calcular")]
        public IActionResult Calcular(CalcularCdbCommand command)
        {
            try
            {
               var result = _service.Calcular(command);
                if (!command.IsValid)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
