using AstroPharm.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Domain.Entities.Delivery;

    public class Courier : Location
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string VehicleType { get; set; }
    }

