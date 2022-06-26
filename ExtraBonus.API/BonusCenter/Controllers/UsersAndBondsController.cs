using AutoMapper;
using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Resources;
using Microsoft.AspNetCore.Mvc;

namespace ExtraBonus.API.BonusCenter.Controllers;



[ApiController]
[Route("/api/v1/[controller]")]
public class UsersAndBondsController  : ControllerBase
{
    
    private readonly IBondService _bondService;
    private readonly IMapper _mapper;

    public UsersAndBondsController(IBondService bondService, IMapper mapper)
    {
        _bondService = bondService;
        _mapper = mapper;
    }
    [HttpGet("{userId}/bonds")]
    public async Task<IEnumerable<BondResource>> GetAllByBondIdAsync(int userId)
    {
        var bonds = await _bondService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<Bond>, IEnumerable<BondResource>>(bonds);
        return resources;
    }

    
}