using Domin.Entities.User;

namespace Application.Repository;

public interface IUserRepository
{
    Task<User> GetUserById(int userId);

    Task<User> CreateUser(User user);
}