using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;

namespace AstroPharm.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public Role Role { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long LanguageId { get; set; }
    //public long LocationId { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    //public virtual Location Location { get; set; }
    //public virtual ICollection<WishList> WishList { get; set; }
    //public virtual ICollection<CartItem> CartItemList { get; set; }
    //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    //public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
}
