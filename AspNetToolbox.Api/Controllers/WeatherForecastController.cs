using Microsoft.AspNetCore.Mvc;
using Toolbox.Dto.Response;
using Toolbox.Service;

namespace AspNetToolbox.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        
        private readonly WeatherForecastService _service;

        public WeatherForecastController(WeatherForecastService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastResponse> Get()
        {
            /*
             * Nesse caso o filtro n�o ser� utilizado pois o retorno do m�todo n�o � do tipo IActionResult
             */
            return _service.GetAll();
        }

        [HttpGet("get-with-filter")]
        public async Task<ActionResult> GetWithFilter()
        {
            /*
             *  A �nica diferen�a entre os dois endpoints �: O retorno do m�todo
             *  Para utilizar o FILTER � necess�rio que o retorno do m�todo na assinatura seja ActionResult ou IActionResult
             *  O m�todo em sim, deve ent�o retornar um 'm�todos de retorno' que conter� o objeto nesse caso _service.GetAll()
            */

            return Ok(_service.GetAll());
        }
    }
}