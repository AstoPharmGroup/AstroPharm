using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Categories;

public class CategoryForUpdateDto
{
    public long CatalogId { get; set; }
    public string CategoryName { get; set; }
}
