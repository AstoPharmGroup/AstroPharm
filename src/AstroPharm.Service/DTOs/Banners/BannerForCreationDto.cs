using AstroPharm.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Banners;

public class BannerForCreationDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
    public long CategoryId { get; set; }
    public long MedicationId { get; set; }
}
