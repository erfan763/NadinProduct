using Application.Common;
using Application.Repository;
using AutoMapper;
using Domin.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper,
        UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;

        _userManager = userManager;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = await _userManager.FindByIdAsync(request.UserId);

        if (currentUser is null) throw new NotFoundException("user not found");

        if (_userManager.Users.Any(x => x.UserName == request.UserName && request.UserId != x.Id))
            throw new BadRequestException("user with this userName is already exist");

        currentUser.ModifiedDate = new DateTime();
        currentUser.UserName = request.UserName;
        currentUser.Email = request.Email;
        currentUser.FirstName = request.FirstName;
        currentUser.LastName = request.LastName;
        currentUser.PhoneNumber = request.PhoneNumber;


        await _userManager.UpdateAsync(currentUser);
        _mapper.Map<User>(currentUser);
        await _unitOfWork.Save(cancellationToken);
        return _mapper.Map<UpdateUserResponse>(currentUser);
    }
}