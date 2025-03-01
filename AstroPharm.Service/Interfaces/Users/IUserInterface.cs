using AstroPharm.Service.DTOs.Users;

namespace AstroPharm.Service.Interfaces.Users;

public interface IUserInterface
{
    Task<bool> DeleteAsync(long id);
    Task<UserForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> GetAllAsync();
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);

}
