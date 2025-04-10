using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Locations
{
    public class LocationForResultDto
    {
        public long Id { get; set; }
        public double LoLatitude { get; set; }
        public double Longitude { get; set; }
    }
}
