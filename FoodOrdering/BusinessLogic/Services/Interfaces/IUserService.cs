using FoodOrdering.Dto;

namespace FoodOrdering.Services;

public interface IUserService
{
    FullUserDto GetUser(int userId);

    void UpdateEmail(int userId, string email);
}