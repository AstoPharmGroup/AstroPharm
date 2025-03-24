using AstroPharm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Branches
{
    public class BranchForUpdateDto
    {
        public string BranchName { get; set; }
        public long LocationId { get; set; }
    }
}
