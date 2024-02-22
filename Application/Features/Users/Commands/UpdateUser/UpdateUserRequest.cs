using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserRequest(string FirstName, string LastName, string Email,
    string PhoneNumber, string UserName, string UserId) : IRequest<UpdateUserResponse>;

public sealed record UpdateUserRequestInput(string FirstName, string LastName, string Email,
    string PhoneNumber, string UserName) : IRequest<UpdateUserResponse>;