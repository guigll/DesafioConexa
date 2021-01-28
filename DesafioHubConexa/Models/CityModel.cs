using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHubConexa.Models
{
    public class CityModel
    {
        [NotMapped]
        public float Lat { get; set; }
        [NotMapped]
        public float Lon { get; set; }
        public string Name { get; set; }
        public float Temp { get; set; }
        public DateTimeOffset? Data { get; set; }       
        public int Id { get; set; }

    }
}
