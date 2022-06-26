using AutoMapper;
using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Resources;
using Microsoft.AspNetCore.Mvc;
namespace ExtraBonus.API.BonusCenter.Controllers;



[ApiController]
[Route("/api/v1/[controller]")]
public class BondsAndDuesController  : ControllerBase
{
    private readonly IDueService _dueService;
    private readonly IMapper _mapper;

    public BondsAndDuesController(IDueService bondService, IMapper mapper)
    {
        _dueService = bondService;
        _mapper = mapper;
    }
    
       
    [HttpGet("{bondId}/dues")]
    public async Task<IEnumerable<DueResource>> GetAllByBondIdAsync(int bondId)
    {
        var dues = await _dueService.ListByBondIdAsync(bondId);
        var resources = _mapper.Map<IEnumerable<Due>, IEnumerable<DueResource>>(dues);
        return resources;
    }
    

}