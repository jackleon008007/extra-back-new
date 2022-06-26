using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.Shared.Domain.Services.Communication;

namespace ExtraBonus.API.BonusCenter.Domain.Services.Comunication;

public class ResultResponse: BaseResponse<Result>
{
    public ResultResponse(string message) : base(message)
    {
    }
    public ResultResponse(Result resource) : base(resource)
    {
    }
}