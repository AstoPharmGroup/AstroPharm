using AstroPharm.Service.DTOs.OrderDetails;
using AstroPharm.Service.DTOs.UserRoles;
using AstroPharm.Service.DTOs.Users;

namespace AstroPharm.Service.Interfaces.Users;

public interface IUserInterface
{
    Task<bool> RemoveAsync(long id);
    Task<UserRoleForResultDto> AssignRoleToUser(UserRoleForCreationDto dto);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync();
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);

}
