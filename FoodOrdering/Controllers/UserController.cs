using AutoMapper;
using FoodOrdering.Dto;
using FoodOrdering.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    // Can't get mock identity user to work
    private const int USER_ID = 1;
    
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public UserInfoDto Get()
    {
        var user = _userService.GetUser(USER_ID);
        return _mapper.Map<UserInfoDto>(user);
    }

    [HttpGet]
    public UserDto GetWithOrders()
    {
        return _userService.GetUser(USER_ID);
    }
    
    [HttpPost]
    public UserDto UpdateEmail(string email)
    {
        _userService.UpdateEmail(USER_ID, email);
        return _userService.GetUser(USER_ID);
    }
}