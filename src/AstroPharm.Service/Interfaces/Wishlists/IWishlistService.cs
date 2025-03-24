using AstroPharm.Service.DTOs.Wishlists;

namespace AstroPharm.Service.Interfaces.Wishlists;

public interface IWishlistService
{ 
    Task<IEnumerable<WishlistForResultDto>> RetrieveAllAsync();
    Task<WishlistForResultDto> AddAsync(WishlistForCreationDto dto);
    Task<bool> RemoveAsync(long id);
    Task<WishlistForResultDto> RetrieveByIdAsync(long id);
    Task<WishlistForResultDto> ModifyAsync(long id,WishlistForUpdateDto dto);
}
