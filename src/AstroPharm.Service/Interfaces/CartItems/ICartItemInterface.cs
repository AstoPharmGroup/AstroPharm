using AstroPharm.Service.DTOs.CartItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.CartItems;

public interface ICartItemInterface
{
    Task<bool> DeleteAsync(long Id);
    Task<CartItemForResultDto> GetCartItem(long Id);
    Task<CartItemForResultDto> AddAsync(CartItemForCreationDto dto);
    Task<CartItemForResultDto> UpdateAsync(long Id, CartItemForUpdateDto dto);
}
