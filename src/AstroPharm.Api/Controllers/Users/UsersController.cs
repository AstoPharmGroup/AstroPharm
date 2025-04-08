using AstroPharm.Api.Helpers;
using AstroPharm.Domain.Enums;
using AstroPharm.Service.DTOs.UserRoles;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AstroPharm.Api.Controllers.Users;

public class UsersController : BaseController
{
    private readonly IUserInterface _userService;

    public UsersController(IUserInterface userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
        {

            return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
        }

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
        //var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        //if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
        //{

        //    return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
        //}

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
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
        {

            return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
        }

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
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
        {

            return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
        }

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _userService.ModifyAsync(id, user)
        });
    }


    [HttpPost("assign-role")]
    [Authorize]
    public async Task<IActionResult> AssignRole([FromBody] UserRoleForCreationDto dto)
    {

        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
        {

            return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
        }

        if ((dto.Role == Domain.Enums.Role.Admin || dto.Role == Domain.Enums.Role.SuperAdmin) && userRole != "SuperAdmin")
        {
            return Unauthorized(new { message = $"User with role '{userRole}' is not allowed to do this action. Only SuperAdmins can do this action." });
        }


        var result = await _userService.AssignRoleToUser(dto);
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Role assigned successfully",
            Data = result
        });
    }
}
