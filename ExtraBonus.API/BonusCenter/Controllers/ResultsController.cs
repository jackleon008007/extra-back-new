using AutoMapper;
using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Resources;
using ExtraBonus.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExtraBonus.API.BonusCenter.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class ResultsController  : ControllerBase
{
    private readonly IResultService _resultService;
    private readonly IMapper _mapper;

    public ResultsController(IMapper mapper, IResultService resultService)
    {
        _mapper = mapper;
        _resultService = resultService;
    }
   
    [HttpGet]
    public async Task<IEnumerable<ResultResource>> GetAllAsync()
    {
        var results = await _resultService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Result>, IEnumerable<ResultResource>>(results);

        return resources;

    }
    
    [HttpGet("{id}")]
    public async Task<ResultResource> GetByIdAsync(int id)
    {
        var result = await _resultService.FindByIdAsync(id);
        var resource = _mapper.Map<Result,ResultResource>(result);
        return resource;

    }
    
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveResultResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var _result = _mapper.Map<SaveResultResource, Result>(resource);

        var result = await _resultService.SaveAsync(_result);

        if (!result.Success)
            return BadRequest(result.Message);

        var resultResource = _mapper.Map<Result, ResultResource>(result.Resource);

        return Ok(resultResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveResultResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var _result= _mapper.Map<SaveResultResource, Result>(resource);

        var result = await _resultService.UpdateAsync(id, _result);

        if (!result.Success)
            return BadRequest(result.Message);

        var resultResource = _mapper.Map<Result, ResultResource>(result.Resource);

        return Ok(resultResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _resultService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var resultResource = _mapper.Map<Result, ResultResource>(result.Resource);

        return Ok(resultResource);
    }
}