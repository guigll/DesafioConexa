using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHubConexa.Models
{
    public class HistoricDailyModel
    {
        public int Dt { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public HistoricTempModel Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public float Dew_point { get; set; }
        public float Wind_speed { get; set; }
        public int Wind_deg { get; set; }
        public HistoricWeatherModel[] Weather { get; set; }
        public int Clouds { get; set; }
        public float Pop { get; set; }
        public float Rain { get; set; }
        public float Uvi { get; set; }
    }
}
