﻿using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Enums;
using System.Security.Principal;

namespace AstroPharm.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public Role Role { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
    public ICollection<WishList> WishList { get; set; }
    public ICollection<CartItem> CartItemList { get; set; }
}
