
using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;

using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Payments;
using AutoMapper;

namespace AstroPharm.Service.Services.Payments;
public class PaymentService : IPaymentInterface
{
    private readonly IMapper _mapper;
    private readonly IRepository<Payment> _paymentRepository;

    public PaymentService(IMapper mapper, IRepository<Payment> paymentRepository)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentResultDto> AddAsync(PaymentCreationDto dto)
    {
        var payment = _mapper.Map<Payment>(dto);

        payment.CreatedAt = DateTime.UtcNow;

        return _mapper.Map<PaymentResultDto>(await _paymentRepository.InsertAsync(payment));
    }

    public async Task<IEnumerable<PaymentResultDto>> GetAllAsync()
    {
        var payments = _paymentRepository.SelectAll();
        return _mapper.Map<IEnumerable<PaymentResultDto>>(payments);
    }

    public async Task<PaymentResultDto> GetByIdAsync(long id)
    {
        var payment = await _paymentRepository.SelectByIdAsync(id);

        if (payment == null)
            throw new AstroPharmException(404, "Payment not found");

        return _mapper.Map<PaymentResultDto>(payment);
    }

    public async Task<PaymentResultDto> ModifyAsync(long id, PaymentUpdateDto dto)
    {
        var payment = await _paymentRepository.SelectByIdAsync(id);
        if (payment == null)
            throw new AstroPharmException(404, "Payment not found");

        _mapper.Map(dto, payment);
        payment.UpdatedAt = DateTime.UtcNow;

        return _mapper.Map<PaymentResultDto>(await _paymentRepository.UpdateAsync(payment));
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var payment = await _paymentRepository.SelectByIdAsync(id);

        if (payment == null)
        {
            throw new AstroPharmException(404, "Payment not found");
        }
        return await _paymentRepository.DeleteAsync(id);
    }
}