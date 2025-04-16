using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Entities.Users;
using AstroPharm.Service.DTOs.OrderDetails;
using AstroPharm.Service.DTOs.UserRoles;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Users;
using AstroPharm.Service.Validators;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Users;

public class UserService : IUserInterface
{
    private readonly IRepository<User> repository;
    private readonly IRepository<Order> orderRepository;
    private readonly IMapper mapper;
    private readonly UserValidator validator;
    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
        validator = new UserValidator();
    }
    public async Task<UserRoleForResultDto> AssignRoleToUser(UserRoleForCreationDto dto)
    {
        var user = await repository.SelectByIdAsync(dto.UserId);
        if (user == null)
            throw new AstroPharmException(404, "User not found");

        user.Role = dto.Role;

        await repository.UpdateAsync(user);

        return new UserRoleForResultDto
        {
            UserId = user.Id,
            User = mapper.Map<UserForResultDto>(user),
            Role = user.Role
        }; 
    }


    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await repository.SelectAll()
            .Where(x => x.Email == dto.Email)
            .FirstOrDefaultAsync();

        validator.ValidateUser(dto);
        var newUser = mapper.Map<User>(dto);
        newUser.CreatedAt = DateTime.UtcNow;
        await repository.InsertAsync(newUser);

        return mapper.Map<UserForResultDto>(newUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await repository.SelectByIdAsync(id);
        if (user == null)
            throw new AstroPharmException(404, "User not found!");

        await repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync()
    {
        var users = await repository.SelectAll()
            .ToListAsync();

        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }


    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await repository.SelectByIdAsync(id);
        if (user == null)
            throw new AstroPharmException(404, "User not found!");

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await repository.SelectByIdAsync(id);
        if (user == null)
            throw new AstroPharmException(404, "User not found!");

        //validator.ValidateUser(mapper.Map<UserForUpdateDto>(dto));
        var modifiedUser = mapper.Map(dto, user);
        modifiedUser.UpdatedAt = DateTime.UtcNow;
        await repository.UpdateAsync(modifiedUser);

        return mapper.Map<UserForResultDto>(modifiedUser);
    }

    public async Task<string> ForgotPassword(string email)
    {
        var user = await repository.SelectAll().FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            throw new AstroPharmException(404,"No user found with this email.");
        }

        return user.Password;
    }

}
