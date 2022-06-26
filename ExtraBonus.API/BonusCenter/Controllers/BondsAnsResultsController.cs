using AutoMapper;
using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Resources;
using Microsoft.AspNetCore.Mvc;

namespace ExtraBonus.API.BonusCenter.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class BondsAnsResultsController   : ControllerBase
{
    private readonly IResultService _resultService;
    private readonly IMapper _mapper;

    public BondsAnsResultsController(IResultService resultService, IMapper mapper)
    {
        _resultService = resultService;
        _mapper = mapper;
    }
    [HttpGet("{bondId}/results")]
    public async Task<IEnumerable<ResultResource>> GetAllByBondIdAsync(int bondId)
    {
        var results = await _resultService.ListByBondIdAsync(bondId);
        var resources = _mapper.Map<IEnumerable<Result>, IEnumerable<ResultResource>>(results);
        return resources;
    }
}