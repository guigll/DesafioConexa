using DesafioHubConexa.Data;
using DesafioHubConexa.Models;
using DesafioHubConexa.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DesafioHubConexa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenWeatherMapController : ControllerBase
    {

        private readonly IOpenWeatherService _openWeatherService;      

        public OpenWeatherMapController(IOpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;           
        }

        /// <summary>
        /// Obtenha Temperatura por nome da cidade
        /// </summary>
        /// <param name="cidade">Ex: New York</param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarTemperaturaPorCidade/{cidade}")]
        public async Task<IActionResult> BuscarTemperaturaPorCidade(string cidade)
        {
            var response = await _openWeatherService.BuscarTemperaturaPorCidade(cidade);

            if (response != null)
            {           
                return Ok(response);
            }

            return BadRequest("Temperatura por cidade não encontrada");
        }

        /// <summary>
        /// Obtenha Temperatura por Geolocalização
        /// </summary>
        /// <param name="latitude">EX: 33.9</param>
        /// <param name="longitude">Ex: 90.5</param>
        /// <returns></returns>        
        [HttpGet]
        [Route("BuscarTemperaturaPorGeolocalizacao/{latitude}/{longitude}")]
        public async Task<IActionResult> BuscarTemperaturaPorGeolocalizacao(float latitude, float longitude)
        {
            var response = await _openWeatherService.BuscarTemperaturaPorGeolocalizacao(latitude, longitude);
            if (response != null)
            {
                return Ok(response);
            }

            return BadRequest("Temperatura por coordenada não encontrada");
        }

        /// <summary>
        /// Obtenha Historico de Temperatura por Geolocalização
        /// </summary>
        /// <param name="latitude">EX: 33.9</param>
        /// <param name="longitude">Ex: 90.5</param>
        /// <returns></returns> 
        [HttpGet]
        [Route("Historico/{latitude}/{longitude}")]
        public async Task<IActionResult> BuscarHistoricoPorGeolocalizacao(float latitude, float longitude)
        {
            var response = await _openWeatherService.BuscarHistoricoPorGeolocalizacao(latitude, longitude);
            if (response.Count > 0)
            {
                 return Ok(response);
            }
            return BadRequest("Histórico de Temperatura por coordenada não encontrada");
        }
    }
}

