using Application.Common;
using Application.Repository;
using AutoMapper;
using Domin.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly JWTService _jwtService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper,
        JWTService jwtService, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtService = jwtService;
        _userManager = userManager;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            LastName = request.LastName,
            Email = request.Email,
            FirstName = request.FirstName,
            PhoneNumber = request.PhoneNumber,
            UserName = request.UserName,
            RefreshToken = _jwtService.GenerateRefreshToken()
        };
        var result = await _userManager.CreateAsync(newUser, request.Password);

        if (result.Succeeded)
        {
            var token = _jwtService.GenrateJWTToken(newUser.Id, newUser.UserName);
            newUser.Token = token;
        }
        else
        {
            throw new BadRequestException(result.Errors.First().Description);
        }


        var user = _mapper.Map<User>(newUser);
        await _unitOfWork.Save(cancellationToken);
        return _mapper.Map<CreateUserResponse>(user);
    }
}