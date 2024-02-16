using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public sealed record CreateUserRequest(string FirstName, string LastName, string Password, string Email,
    string PhoneNumber, string UserName) : IRequest<CreateUserResponse>;