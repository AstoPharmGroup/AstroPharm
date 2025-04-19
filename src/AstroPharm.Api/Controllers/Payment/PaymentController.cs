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
        var payments = await _paymentService.GetAllAsync();
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "All Payments Retrieved Successfully",
            Data = payments
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        var payment = await _paymentService.GetByIdAsync(id);
        if (payment == null)
        {
            return NotFound(new Response
            {
                StatusCode = 404,
                Message = "Payment Not Found",
                Data = null
            });
        }

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Payment Retrieved Successfully",
            Data = payment
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        var result = await _paymentService.RemoveAsync(id);
        if (!result)
        {
            return NotFound(new Response
            {
                StatusCode = 404,
                Message = "Payment Not Found for Deletion",
                Data = null
            });
        }

        return NoContent(); // 204 No Content
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] PaymentCreationDto payment)
    {
        var createdPayment = await _paymentService.AddAsync(payment);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = createdPayment.Id }, new Response
        {
            StatusCode = 201,
            Message = "Payment Added Successfully",
            Data = createdPayment
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] PaymentUpdateDto payment, [FromRoute] long id)
    {
        var updatedPayment = await _paymentService.ModifyAsync(id, payment);
        if (updatedPayment == null)
        {
            return NotFound(new Response
            {
                StatusCode = 404,
                Message = "Payment Not Found for Update",
                Data = null
            });
        }

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Payment Updated Successfully",
            Data = updatedPayment
        });
    }
}
