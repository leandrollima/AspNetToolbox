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
             * Nesse caso o filtro não será utilizado pois o retorno do método não é do tipo IActionResult
             */
            return _service.GetAll();
        }

        [HttpGet("get-with-filter")]
        public async Task<ActionResult> GetWithFilter()
        {
            /*
             *  A única diferença entre os dois endpoints é: O retorno do método
             *  Para utilizar o FILTER é necessário que o retorno do método na assinatura seja ActionResult ou IActionResult
             *  O método em sim, deve então retornar um 'métodos de retorno' que conterá o objeto nesse caso _service.GetAll()
            */

            return Ok(_service.GetAll());
        }
    }
}