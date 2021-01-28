using DesafioHubConexa.Data;
using DesafioHubConexa.Models;
using DesafioHubConexa.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioHubConexa.Services
{
    public interface IOpenWeatherService
    {
        Task<CityModel> BuscarTemperaturaPorCidade(string cidade);
        Task<CityModel> BuscarTemperaturaPorGeolocalizacao(float latitude, float longitude);
        Task<List<CityModel>> BuscarHistoricoPorGeolocalizacao(float lat, float lon);
    }   

}
