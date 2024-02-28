using System.Text.Json.Serialization;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserRequest(string Email, string FirstName, string LastName, string PhoneNumber,
    string UserName) : IRequest<UpdateUserResponse>
{
    [JsonIgnore] public string UserId;
}