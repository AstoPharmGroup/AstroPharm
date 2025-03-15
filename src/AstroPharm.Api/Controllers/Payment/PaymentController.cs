using AstroPharm.Api.Helpers;
using AstroPharm.Service.Interfaces.Payments;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.Payment;

public class PaymentController : BaseController
{
    private readonly IPaymentInterface _paymentService;

    public PaymentController(IPaymentInterface paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _paymentService.GetAllAsync()
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _paymentService.GetByIdAsync(id)
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _paymentService.RemoveAsync(id)
        });
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] PaymentCreationDto payment)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _paymentService.AddAsync(payment)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] PaymentUpdateDto payment, [FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _paymentService.ModifyAsync(id, payment)
        });
    }
}
