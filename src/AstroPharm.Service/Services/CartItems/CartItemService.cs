using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities.Users;
using AstroPharm.Service.DTOs.CartItems;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.CartItems;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Interfaces.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.CartItems;

public class CartItemService : ICartItemInterface
{
    private readonly IRepository<CartItem> repository;
    private readonly IMapper mapper;
    private readonly IUserInterface userService;
    private readonly IMedicationInterface medicationService;

    public CartItemService(IMedicationInterface medicationService, IUserInterface userService, IMapper mapper, IRepository<CartItem> repository)
    {
        this.medicationService = medicationService;
        this.userService = userService;
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<CartItemForResultDto> AddAsync(CartItemForCreationDto dto)
    {
        var user = await userService.RetrieveByIdAsync(dto.UserId);
        var medication = await medicationService.GetByIdAsync(dto.MedicationId);

        if (user == null || medication == null)
            throw new AstroPharmException(404, "User or Medication not found");

        var existingCartItem = await repository.SelectAll()
            .Where(c => c.UserId == dto.UserId && c.MedicationId == dto.MedicationId)
            .FirstOrDefaultAsync();

        if (existingCartItem != null)
            throw new AstroPharmException(409, "This cart already exists");
        

        var mapped = mapper.Map<CartItem>(dto);
        await repository.InsertAsync(mapped);

        return mapper.Map<CartItemForResultDto>(mapped);
    }

    public async Task<bool> DeleteAsync(long cartItemId)
    {
        var cartItem = await repository.SelectByIdAsync(cartItemId);
        if (cartItem == null)
            throw new AstroPharmException(404, "Cart item not found!");

        await repository.DeleteAsync(cartItem.Id);
        return true;
    }

    public async Task<CartItemForResultDto> GetCartItem(long cartItemId)
    {
        var cartItem = await repository.SelectByIdAsync(cartItemId);
        if (cartItem == null)
            throw new AstroPharmException(404, "Cart item not found!");

        return mapper.Map<CartItemForResultDto>(cartItem);
    }

    public async Task<CartItemForResultDto> UpdateAsync(long cartItemId, CartItemForUpdateDto dto)
    {
        var cartItem = await repository.SelectByIdAsync(cartItemId);
        if (cartItem == null)
            throw new AstroPharmException(404, "Cart item not found!");

        
        cartItem.Count = dto.Count; 

        await repository.UpdateAsync(cartItem);
        return mapper.Map<CartItemForResultDto>(cartItem);
    }
}
