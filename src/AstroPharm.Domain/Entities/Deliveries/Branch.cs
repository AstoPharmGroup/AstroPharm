using AstroPharm.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Domain.Entities
{
    public class Branch : Auditable
    {
       public string BranchName { get; set; }
       public long LocationId { get; set; }

        //referance
       public virtual Location Location { get; set; }
    }
}
