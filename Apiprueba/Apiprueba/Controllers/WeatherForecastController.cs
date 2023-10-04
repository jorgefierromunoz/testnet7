using Apiprueba.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Text;

namespace Apiprueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DBContext _context;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DBContext _dbcontext)
        {
            _logger = logger;
            _context = _dbcontext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetTablaPrueba")]
        public async Task<IActionResult> GetTablaPrueba()
        {
            return Ok(new { Respuesta = false, Data = await _context.TablaPrueba.ToListAsync() });
        }


        [HttpGet("TelnetDB")]
        public async Task<IActionResult> TelnetDB(string host,int port)
        {
            string resp = "";
            using (TcpClient client = new TcpClient(host, port))
            using (NetworkStream stream = client.GetStream())
            {
                // Envía un comando telnet (por ejemplo, "echo hello")
                byte[] data = Encoding.ASCII.GetBytes("echo hello\r\n");
                stream.Write(data, 0, data.Length);

                // Lee la respuesta
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                resp += "\n" + response;
            }
            return Ok(new { Respuesta = true, Data = resp });
        }


    }
}