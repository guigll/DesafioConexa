using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHubConexa.Models
{
    public class RootModel
    {
        public CoordModel Coord { get; set; }
        public List<WeatherModel> Weather { get; set; }
        public string Base { get; set; }
        public MainModel Main { get; set; }
        public int Visibility { get; set; }
        public WindModel Wind { get; set; }
        public CloudsModel Clouds { get; set; }
        public int Dt { get; set; }
        public SysModel Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
        
    }
}
