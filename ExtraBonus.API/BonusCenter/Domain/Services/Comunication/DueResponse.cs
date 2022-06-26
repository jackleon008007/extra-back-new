using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.Shared.Domain.Services.Communication;

namespace ExtraBonus.API.BonusCenter.Domain.Services.Comunication;

public class DueResponse : BaseResponse<Due>
{
    public DueResponse(string message) : base(message)
    {
    }
    public DueResponse(Due resource) : base(resource)
    {
    }
}