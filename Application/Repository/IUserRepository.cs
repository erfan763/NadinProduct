using Domin.Entities.User;

namespace Application.Repository;

public interface IUserRepository
{
    Task<User> GetUserById(string userId);
}