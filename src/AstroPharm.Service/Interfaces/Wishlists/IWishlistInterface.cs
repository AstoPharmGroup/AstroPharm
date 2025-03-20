using AstroPharm.Service.DTOs.Banners;
using AstroPharm.Service.DTOs.WhishLists;

namespace AstroPharm.Service.Interfaces.Wishlists;

public interface IWishlistInterface
{
    Task<bool> DeleteAsync(long id);
    Task<WishListForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<WishListForResultDto>> GetAllAsync();
    Task<WishListForResultDto> AddAsync(WishListForCreationDto dto);
    Task<WishListForResultDto> ModifyAsync(long id, WishListForUpdateDto dto);
}
