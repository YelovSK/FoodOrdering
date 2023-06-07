using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    void UpdateEmail(int userId, string email);
}
