using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Delivery;
using AstroPharm.Domain.Enums;
using System.Security.Principal;

namespace AstroPharm.Domain.Entities;

public class User : Location
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public Role Role { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public virtual ICollection<WishList> WishList { get; set; }
    public virtual ICollection<CartItem> CartItemList { get; set; }
}
