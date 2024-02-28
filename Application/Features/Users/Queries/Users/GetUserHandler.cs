using Application.Common;
using Application.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries.Users;

public sealed class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;


    public GetUserHandler(IUserRepository userRepository, IMapper mapper
    )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetUserById(request.userId);
        if (user == null)
            throw new NotFoundException("user not found");

        return _mapper.Map<GetUserResponse>(user.Result);
    }
}