using System.Text.Json.Serialization;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public string Email;
    public string FirstName;
    public string LastName;
    public string PhoneNumber;
    [JsonIgnore] public string UserId;
    public string UserName;
}