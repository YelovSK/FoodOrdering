using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FoodOrdering.Dto;
using FoodOrdering.Exceptions;
using FoodOrdering.Repositories;

namespace FoodOrdering.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public UserDto GetUser(int userId)
    {
        var user = _userRepository.GetUser(userId);
        if (user == null)
        {
            throw new FoodOrderingException("User not found");
        }
        
        return _mapper.Map<UserDto>(user);
    }

    public void UpdateEmail(int userId, string email)
    {
        var user = _userRepository.GetUser(userId);
        if (user == null)
        {
            throw new FoodOrderingException("User not found");
        }
        
        // Validate email
        var emailAttribute = new EmailAddressAttribute();
        var valid = emailAttribute.IsValid(email);
        if (valid == false)
        {
            throw new FoodOrderingException("Invalid email address");
        }
        
        _userRepository.UpdateEmail(userId, email);
        _userRepository.Save();
    }
}