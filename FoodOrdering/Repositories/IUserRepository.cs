using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public interface IUserRepository
{
    User? GetUser(int userId);
    
    void UpdateEmail(int userId, string email);

    void Save();
}
