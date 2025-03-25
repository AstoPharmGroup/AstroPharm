using AstroPharm.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Domain.Entities;

public class Location : Auditable
{
    public double LoLatitude { get; set; }
    public double Longitude { get; set; }
}
