using Application.Common;
using Application.Repository;
using AutoMapper;
using Domin.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands.Login;

public sealed class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _userRepository;

    public LoginHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper,
        UserManager<User> userManager
    )
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetUserByUserName(request.UserName);
        if (user.Result is null)
            throw new NotFoundException("user not found");


        if (
            CheckPassword(user.Result.Id, request.Password).Result) return _mapper.Map<LoginResponse>(user.Result);
        throw new NotFoundException("user not found :((");
    }


    public async Task<bool> CheckPassword(string userId, string userInputPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null) throw new NotFoundException("user not found");


        var passwordIsValid = await _userManager.CheckPasswordAsync(user, userInputPassword);

        if (passwordIsValid)
            return true;
        throw new BadRequestException("Invalid password!");
    }
}