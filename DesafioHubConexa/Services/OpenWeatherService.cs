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
    public class OpenWeatherService : BaseService, IOpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string openweatherAppId;
        private OpenWeatherRepository _repository = new OpenWeatherRepository();
        private Contexto _context;
       

        public OpenWeatherService(HttpClient httpClient, IConfiguration configuration, Contexto context)
        {
            httpClient.BaseAddress = new System.Uri(configuration["OpenweatherApiHostName"]);
            _httpClient = httpClient;
            openweatherAppId = configuration["OpenweatherApiId"];
            _context = context;
        }

        public async Task<CityModel> BuscarTemperaturaPorCidade(string cidade)
        {
            var response = await _httpClient.GetAsync($"weather?q={cidade}&appid={openweatherAppId}&units=metric");
            var rootModel = new RootModel();
            var cityModel = new CityModel();

            if (response.IsSuccessStatusCode)
            {
                rootModel = await DeserializarObjetoResponse<RootModel>(response);
                cityModel.Name = rootModel.Name;
                cityModel.Temp = rootModel.Main.Temp;                
                SalvarTemperatura(cityModel);
            }
            else
            {
                cityModel = null;
            }

            return cityModel;
        }

        public async Task<CityModel> BuscarTemperaturaPorGeolocalizacao(float latitude, float longitude)
        {
            var response = await _httpClient.GetAsync($"weather?lat={latitude}&lon={longitude}&appid={openweatherAppId}&units=metric");
            var rootModel = new RootModel();
            var cityModel = new CityModel();

            if (response.IsSuccessStatusCode)
            {
                rootModel = await DeserializarObjetoResponse<RootModel>(response);
                cityModel.Name = rootModel.Name;
                cityModel.Temp = rootModel.Main.Temp;
                SalvarTemperatura(cityModel);
            }
            else
            {
                cityModel = null;
            }

            return cityModel;
        }

        public async Task<List<CityModel>> BuscarHistoricoPorGeolocalizacao(float latitude, float longitude)
        {
            var response = await _httpClient.GetAsync($"onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={openweatherAppId}&units=metric");
            var historicModel = new HistoricModel();
            var result = new List<CityModel>();
            historicModel = await DeserializarObjetoResponse<HistoricModel>(response);
            foreach (var day in historicModel.Daily)
            {
                result.Add(new CityModel
                {
                    Temp = day.Temp.Day,
                    Data = DateTimeOffset.FromUnixTimeSeconds(day.Dt)
                });
            }
            SalvarHistoricoTemperatura(result);
            return result;
        }

        private void SalvarTemperatura(CityModel cityModel)
        {            
            _repository.SaveTemp(cityModel, _context);
        }
        private void SalvarHistoricoTemperatura(List<CityModel> listCityModel)
        {
            _repository.SaveHistoricTemp(listCityModel, _context);
        }
    }

}
