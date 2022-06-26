using AutoMapper;
using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Resources;
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Security.Resources;


namespace ExtraBonus.API.Shared.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<Bond, BondResource>();
        CreateMap<Due, DueResource>();
        CreateMap<Result, ResultResource>();
        
        
    }
}