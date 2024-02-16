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

    public async Task<User> GetUserById(int userId)
    {
        return await _appDbContext.Users.FindAsync(userId);
    }

    public async Task<User> CreateUser(User user)
    {
        var addedUser = await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();

        return addedUser.Entity;
    }
}