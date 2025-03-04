using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Users;

public class UserService : IUserInterface
{
    private readonly IRepository<User> repository;
    private readonly IMapper mapper;
    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await repository.SelectAll()
            .Where(x => x.Email == dto.Email)
            .FirstOrDefaultAsync();

        if (user != null)
            throw new AstroPharmException(409, "This User already exists!");

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
            .AsNoTracking()
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
        var modifiedUser = mapper.Map(dto, user);
        modifiedUser.UpdatedAt = DateTime.UtcNow;
        await repository.UpdateAsync(modifiedUser);

        return mapper.Map<UserForResultDto>(modifiedUser);
    }
}
