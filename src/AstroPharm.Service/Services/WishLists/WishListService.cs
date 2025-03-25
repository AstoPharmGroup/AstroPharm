using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.WhishLists;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Interfaces.Users;
using AstroPharm.Service.Interfaces.Wishlists;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.WishLists
{
    public class WishListService : IWishlistInterface
    {
        private readonly IMapper mapper;
        private readonly IRepository<WishList> repository;
        private readonly IUserInterface userInterface;
        private readonly IMedicationInterface medicationInterface;

        public WishListService(IRepository<WishList> repository, IMapper mapper, IMedicationInterface medicationInterface, IUserInterface userInterface)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.medicationInterface = medicationInterface;
            this.userInterface = userInterface;
        }

        public async Task<WishListForResultDto> AddAsync(WishListForCreationDto dto)
        {
            var user = await userInterface.RetrieveByIdAsync(dto.UserId);
            var medication = await medicationInterface.GetByIdAsync(dto.MedicationId);

            if (user == null || medication == null)
                throw new AstroPharmException(404, "User or Medication do not exist");

            var mapped = mapper.Map<WishList>(dto);
            await repository.InsertAsync(mapped);

            return mapper.Map<WishListForResultDto>(mapped);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var WishList = await repository.SelectAll().FirstOrDefaultAsync(x => x.Id == id);
            if (WishList == null)
                throw new AstroPharmException(404, "WishList not found!");

            await repository.DeleteAsync(id);
            return true;

        }

        public async Task<IEnumerable<WishListForResultDto>> GetAllAsync()
        {
            var categories = await repository.SelectAll()
                .AsNoTracking()
                .ToListAsync();
            return mapper.Map<IEnumerable<WishListForResultDto>>(categories);
        }

        public async Task<WishListForResultDto> GetByIdAsync(long id)
        {
            var WishList = await repository.SelectByIdAsync(id);
            if (WishList == null)
                throw new AstroPharmException(404, "WishList not found!");

            return mapper.Map<WishListForResultDto>(WishList);
        }

        public async Task<WishListForResultDto> ModifyAsync(long id, WishListForUpdateDto dto)
        {
            var WishList = await repository.SelectByIdAsync(id);
            if (WishList == null)
                throw new AstroPharmException(404, "WishList not found!");

            var user = await userInterface.RetrieveByIdAsync(dto.UserId);
            var medication = await medicationInterface.GetByIdAsync(dto.MedicationId);

            if (user == null || medication == null)
                throw new AstroPharmException(404, "User or Medication do not exist");

            var mapped = mapper.Map(dto, WishList);
            await repository.UpdateAsync(mapped);

            return mapper.Map<WishListForResultDto>(mapped);
        }
    }
}