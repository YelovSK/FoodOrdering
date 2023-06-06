using Microsoft.AspNetCore.Identity;

namespace FoodOrdering.Mock;

public class MockIdentityUser : IdentityUser
{
    public override string Id { get; set; } = "1";
}