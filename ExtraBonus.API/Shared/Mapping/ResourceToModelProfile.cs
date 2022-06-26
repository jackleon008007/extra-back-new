using AutoMapper;
using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Resources;
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Security.Resources;


namespace ExtraBonus.API.Shared.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
        CreateMap<SaveBondResource, Bond>();
        CreateMap<SaveDueResource, Due>();
        CreateMap<SaveResultResource, Result>();
    
    }

}