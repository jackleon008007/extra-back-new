using AutoMapper;
using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Resources;
using ExtraBonus.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExtraBonus.API.BonusCenter.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class DuesController : ControllerBase
{
    private readonly IDueService _dueService;
    private readonly IMapper _mapper;

    public DuesController(IMapper mapper, IDueService dueService)
    {
        _mapper = mapper;
        _dueService = dueService;
    }
   
    [HttpGet]
    public async Task<IEnumerable<DueResource>> GetAllAsync()
    {
        var dues = await _dueService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Due>, IEnumerable<DueResource>>(dues);

        return resources;

    }
    
    [HttpGet("{id}")]
    public async Task<DueResource> GetByIdAsync(int id)
    {
        var due = await _dueService.FindByIdAsync(id);
        var resource = _mapper.Map<Due,DueResource>(due);
        return resource;

    }
    
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDueResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var due = _mapper.Map<SaveDueResource, Due>(resource);

        var result = await _dueService.SaveAsync(due);

        if (!result.Success)
            return BadRequest(result.Message);

        var dueResource = _mapper.Map<Due, DueResource>(result.Resource);

        return Ok(dueResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDueResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var due= _mapper.Map<SaveDueResource, Due>(resource);

        var result = await _dueService.UpdateAsync(id, due);

        if (!result.Success)
            return BadRequest(result.Message);

        var dueResource = _mapper.Map<Due, DueResource>(result.Resource);

        return Ok(dueResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _dueService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var dueResource = _mapper.Map<Due, DueResource>(result.Resource);

        return Ok(dueResource);
    }
    
}