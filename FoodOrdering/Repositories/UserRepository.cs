using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(MyDbContext context) : base(context)
    {
    }

    public User? GetUser(int userId)
    {
        return _context.Users.Find(userId);
    }

    public void UpdateEmail(int userId, string email)
    {
        var user = _context.Users.Find(userId);
        if (user is not null)
        {
            user.Email = email;
        }
    }
}