using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHubConexa.Models
{
    public class HistoricModel
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Timezone { get; set; }
        public int Timezone_offset { get; set; }               
        public HistoricDailyModel[] Daily { get; set; }

        
    }
}
