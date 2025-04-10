using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Languages;

public interface ILanguageInterface
{
    Task<Language> AddAsync(LanguageForCreationDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<Language>> GetAllAsync();
    Task<Language> GetByIdAsync(long id);
    Task<Language> ModifyAsync(long id, LanguageForUpdateDto dto);
}
