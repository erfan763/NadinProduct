using Application.Repository;
using Domin.Entities.User;
using InferStructure.Context;

namespace InferStructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<User> GetUserById(string userId)
    {
        var user = _appDbContext.Users.FirstOrDefault(x => x.Id == userId);
        return user;
    }

    public async Task<User> GetUserByUserName(string userName)
    {
        var user = _appDbContext.Users.FirstOrDefault(x => x.UserName == userName);
        return user;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = _appDbContext.Users.ToList();
        return users;
    }
}