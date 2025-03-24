using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Deliveries;
using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Enums;
namespace AstroPharm.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long LocationId { get; set; }
    public string PhoneNumber { get; set; }
    public Role Role { get; set; }
    public long LanguageId { get; set; }

    // Realation
    public Location Location { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public virtual ICollection<WishList> WishList { get; set; }
    public virtual ICollection<CartItem> CartItemList { get; set; }
}
