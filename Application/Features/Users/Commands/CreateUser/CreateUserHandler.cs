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
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper,
        JWTService jwtService)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            LastName = request.LastName,
            Email = request.Email,
            FirstName = request.FirstName,
            PhoneNumber = request.PhoneNumber
        };
        var result = await _userManager.CreateAsync(newUser, request.Password);

        if (result.Succeeded)
        {
            var token = _jwtService.GenrateJWTToken(newUser.Id, newUser.UserName);
            newUser.Token = token;
        }

        var user = _mapper.Map<User>(result);
        await _userRepository.CreateUser(user);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateUserResponse>(user);
    }
}