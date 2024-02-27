﻿using System.Security.Claims;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.Login;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NadinProduct.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("update")]
    [Authorize]
    public async Task<ActionResult<UpdateUserResponse>> Update(UpdateUserRequest requestInput,
        CancellationToken cancellationToken)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var request = new UpdateUserRequest
        {
            FirstName = requestInput.FirstName,
            LastName = requestInput.LastName,
            Email = requestInput.Email,
            PhoneNumber = requestInput.PhoneNumber,
            UserName = requestInput.UserName,
            UserId = userId
        };

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpGet("getUser")]
    [Authorize]
    public async Task<ActionResult<GetUserResponse>> GetUser(CancellationToken cancellationToken)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var response = await _mediator.Send(new GetUserRequest(userId), cancellationToken);
        return Ok(response);
    }
}