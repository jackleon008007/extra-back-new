
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Shared.Domain.Services.Communication;

namespace ExtraBonus.API.Security.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    } 
}