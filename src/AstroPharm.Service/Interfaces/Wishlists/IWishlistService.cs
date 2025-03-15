using AstroPharm.Service.DTOs.Wishlists;

namespace AstroPharm.Service.Interfaces.Wishlists;

public interface IWishlistService
{
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<WishlistForResultDto>> RetrieveAllAsync();
    Task<WishlistForResultDto> AddAsync(WishlistForCreationDto dto);
}
