using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;
using AstroPharm.Service.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Medications
{
    public class MedicationForResultDto
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string MedicationName { get; set; }
    //  public virtual ICollection<WishList> WishLists { get; set; }
    //  public virtual ICollection<CartItem> CartItems { get; set; }
    //  public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
