using AstroPharm.Domain.Entities;

public interface IPaymentInterface
{
    Task<bool> RemoveAsync(long id);
    Task<PaymentResultDto> GetByIdAsync(long id);
    Task<IEnumerable<PaymentResultDto>> GetAllAsync();
    Task<PaymentResultDto> AddAsync(PaymentCreationDto dto);
    Task<PaymentResultDto> ModifyAsync(long id, PaymentUpdateDto dto);
}