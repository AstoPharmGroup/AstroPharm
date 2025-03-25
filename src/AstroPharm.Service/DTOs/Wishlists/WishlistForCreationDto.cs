using AstroPharm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.WhishLists
{
    public class WishListForCreationDto
    {
        public long UserId { get; set; }
        public long MedicationId { get; set; }
    }
}
