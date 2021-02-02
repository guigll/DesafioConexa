using DesafioHubConexa.Data;
using DesafioHubConexa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHubConexa.Repository
{
    public class OpenWeatherRepository : IOpenWeatherRepository
    {
        public OpenWeatherRepository()
        {
            
        }

        public void SaveTemp(CityModel cityModel, Contexto _context)
        {
            _context.Update(cityModel);
            _context.SaveChanges();
        }

        public void SaveHistoricTemp(List<CityModel> list, Contexto _context)
        {
            foreach (var item in list)
            {
                _context.Add(item);
            }
            _context.SaveChanges();
        }
    }
}
