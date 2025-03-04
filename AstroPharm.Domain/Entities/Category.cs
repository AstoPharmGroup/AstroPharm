﻿using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities;

public class Category : Auditable
{
    public long CatalogId { get; set; }
    public virtual Catalog Catalog { get; set; }
    public string CategoryName { get; set; }
}
