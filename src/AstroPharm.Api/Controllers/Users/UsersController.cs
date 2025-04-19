using AstroPharm.Api.Helpers;
using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Enums;
using AstroPharm.Service.DTOs.UserRoles;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.Interfaces.Emails;
using AstroPharm.Service.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace AstroPharm.Api.Controllers.Users;

public class UsersController : BaseController
{
    private readonly IUserInterface _userService;
    private readonly IEmailService emailService;
    private readonly IRepository<RefreshToken> _refreshTokenRepository;

    public UsersController(IUserInterface userService, IEmailService emailService, IRepository<RefreshToken> refreshTokenRepository)
    {
        _userService = userService;
        this.emailService = emailService;
        _refreshTokenRepository = refreshTokenRepository;
    }

    [HttpGet("get-user-password/{email}")]
    public async Task<IActionResult> GetUserPassword(string email)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _userService.ForgotPassword(email),
        });
    }

    [HttpGet]
    //[Authorize]
    public async Task<IActionResult> GetAllAsync()
    {

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.RetrieveAllAsync()
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        var user = await _userService.RetrieveByIdAsync(id);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.RemoveAsync(id)
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] UserForCreationDto user)
    {

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.AddAsync(user)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UserForUpdateDto user, [FromRoute] long id)
    {

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.ModifyAsync(id, user)
        });
    }


    [HttpPost("assign-role")]
    //[Authorize]
    public async Task<IActionResult> AssignRole([FromBody] UserRoleForCreationDto dto)
    {

        var result = await _userService.AssignRoleToUser(dto);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Role assigned successfully",
            Data = result
        });
    }
}
