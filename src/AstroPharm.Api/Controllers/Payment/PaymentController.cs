using AstroPharm.Api.Controllers;
using AstroPharm.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

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
            Message = "All Payment",
            Data = await _paymentService.GetAllAsync()
        });
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Payment",
            Data = await _paymentService.GetByIdAsync(id)
        });
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(PaymentCreationDto dto)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Added",
            Data = await _paymentService.AddAsync(dto)
        });
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long id){
         
        await _paymentService.RemoveAsync(id);
            
        return NoContent();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(PaymentUpdateDto dto, long id){
        return Ok(new Response{
            StatusCode = 200,
            Message = "Payment Update",
            Data = await _paymentService.ModifyAsync( id, dto)
        });
    }
}