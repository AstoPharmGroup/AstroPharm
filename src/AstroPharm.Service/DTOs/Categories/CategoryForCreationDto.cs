using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Categories;

public class CategoryForCreationDto
{
    public long CatalogId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
