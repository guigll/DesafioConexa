using DesafioHubConexa.Models;
using DesafioHubConexa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTests.Model
{
    public class CityModelMock : IOpenWeatherService
    {
        private readonly List<CityModel> _listCityModel;        

        public CityModelMock()
        {
            _listCityModel = new List<CityModel>()
            {
                new CityModel() { Id = 1,
                    Name = "California", Data = DateTimeOffset.Now, Temp = 5.2F, Lat = 33.44F, Lon = -94.04F },
                new CityModel() { Id = 2,
                    Name = "Chicago", Data = DateTimeOffset.Now, Temp = 8.2F, Lat = 33.44F, Lon = -94.04F},
                new CityModel() { Id = 3,
                    Name = "Chicago", Data = DateTimeOffset.Now, Temp = 9.2F, Lat = 33.44F, Lon = -94.04F},
                new CityModel() { Id = 4,
                    Name = "New York", Data = DateTimeOffset.Now, Temp = 9.2F, Lat = 35.44F, Lon = -94.04F}

            };
        }

        public async Task<CityModel> BuscarTemperaturaPorCidade(string cidade)
        {
            List<CityModel> list = await GetListAsync();
            return list.Where(t => t.Name == cidade).FirstOrDefault();
        }

        public async Task<CityModel> BuscarTemperaturaPorGeolocalizacao(float latitude, float longitude)
        {
            List<CityModel> list = await GetListAsync();
            return list.Where(a => a.Lat == latitude && a.Lon == longitude).FirstOrDefault();
        }

        public async Task<List<CityModel>> BuscarHistoricoPorGeolocalizacao(float latitude, float longitude)
        {
            List<CityModel> list = await GetListAsync();
            return (List<CityModel>)list.Where(a => a.Lat == latitude && a.Lon == longitude);
        }

        private async Task<List<CityModel>> GetListAsync()
        {
            List<CityModel> list = await Task.Run(() => _listCityModel);
            return list;
        }
        
    }
}
