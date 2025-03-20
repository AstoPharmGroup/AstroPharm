﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Couriers
{
    public class CourierForUpdateDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string VehicleType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
