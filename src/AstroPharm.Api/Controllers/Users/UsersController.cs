﻿using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.Users;

<<<<<<< HEAD

=======
>>>>>>> 74b95a1ef7b0530fd50629725f818910c07d5482
public class UsersController : BaseController
{
    private readonly IUserInterface _userService;

    public UsersController(IUserInterface userService)
    {
        _userService = userService;
    }

    [HttpGet]
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
}
