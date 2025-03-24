using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Entities.SubCategories;
using AstroPharm.Domain.Entities.Users;
using AstroPharm.Domain.Enums;

namespace AstroPharm.Domain.Entities.Products;

public class Medication : Auditable
{
    public string Image { get; set; }
    public decimal Price { get; set; }
    public  Status Status { get; set; }
    public long CategoryId { get; set; }
    public string Description { get; set; }
    public DateTime ExpiredDate { get; set; }
    public string MedicationName { get; set; }
    public virtual Category Category { get; set; }

    // Relation
    public virtual ICollection<WishList> WishLists { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
    public  virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
