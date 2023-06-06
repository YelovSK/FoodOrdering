using FoodOrdering.Dto;

namespace FoodOrdering.Services;

public interface IUserService
{
    UserDto GetUser(int userId);

    void UpdateEmail(int userId, string email);
}