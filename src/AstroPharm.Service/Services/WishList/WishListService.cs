using System.Collections;
using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Wishlists;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Interfaces.Users;
using AstroPharm.Service.Interfaces.Wishlists;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Wishlist;

public class WishListService : IWishlistService
{
    private readonly IMapper _mapper;
    private readonly IRepository<WishList> _repository;
    private readonly IUserInterface _userInterface;
    private readonly IMedicationInterface _medicationInterface;
    
    
    public async Task<IEnumerable<WishlistForResultDto>> RetrieveAllAsync()
    {
        var WishList =  _repository.SelectAll();

        if (WishList is null || !WishList.Any())
            throw new AstroPharmException(404, "Wish list not found");
        
        return _mapper.Map<IEnumerable<WishlistForResultDto>>(WishList);
    }

    public async Task<WishlistForResultDto> AddAsync(WishlistForCreationDto dto)
    {
        var user = await _userInterface.RetrieveByIdAsync(dto.UserId);
        var medication = await _medicationInterface.GetByIdAsync(dto.MedicationId);
        
        if(user == null || medication == null)
            throw new AstroPharmException(404, "Medication or User not found");

        var mapped = _mapper.Map<WishList>(dto);
        await _repository.InsertAsync(mapped);
        
        return _mapper.Map<WishlistForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var WishList = await _repository.SelectAll().FirstOrDefaultAsync(x=>x.Id == id);
        
        if(WishList == null)
            throw new AstroPharmException(404, "Wishlist not found");

        await _repository.DeleteAsync(id);
        
        return true;
    }

    public async Task<WishlistForResultDto> RetrieveByIdAsync(long id)
    {
        var WishList = await _repository.SelectByIdAsync(id);
        
        if(WishList == null)
            throw new AstroPharmException(404, "Wishlist not found");
        
        return _mapper.Map<WishlistForResultDto>(WishList);
    }

    public async Task<WishlistForResultDto> ModifyAsync(long id, WishlistForUpdateDto dto)
    {
        var WishList = await _repository.SelectByIdAsync(id);
        
        if(WishList == null)
            throw new AstroPharmException(404, "Wishlist not found");
        
        var user = await _userInterface.RetrieveByIdAsync(dto.UserId);
        var medication = await _medicationInterface.GetByIdAsync(dto.MedicationId);

        var mapped = _mapper.Map(dto, WishList);
        await _repository.UpdateAsync(mapped);

        return _mapper.Map<WishlistForResultDto>(mapped);       
    }
}