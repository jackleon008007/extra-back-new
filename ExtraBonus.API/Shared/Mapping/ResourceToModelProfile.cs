using AutoMapper;
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Security.Resources;


namespace ExtraBonus.API.Shared.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
    
    }
    
}