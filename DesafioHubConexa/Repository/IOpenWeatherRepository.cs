using DesafioHubConexa.Data;
using DesafioHubConexa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHubConexa.Repository
{
    public interface IOpenWeatherRepository
    {
        void SaveTemp(CityModel cityModel, Contexto _context);
        void SaveHistoricTemp(List<CityModel> list, Contexto _context);

    }
}
