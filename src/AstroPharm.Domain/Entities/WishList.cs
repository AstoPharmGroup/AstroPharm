﻿using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities;

public class WishList : Auditable
{
    public long UserId { get; set; }
    public virtual User User { get; set; }
    public long MedicationId { get; set; }
    public virtual Medication Medication { get; set; }
}
