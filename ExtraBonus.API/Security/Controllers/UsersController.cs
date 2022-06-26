using AutoMapper;
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Security.Domain.Services;
using ExtraBonus.API.Security.Resources;
using ExtraBonus.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExtraBonus.API.Security.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _mapper = mapper;
        _userService = userService;
    }
    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

        return resources;

    }
    
    [HttpGet("{email}And{password}")]
    public async Task<UserResource> GetByEmailAndPasswordAsync(string email, string password)
    {
        var user = await _userService.FindByEmailAndPasswordAsync(email,password);
        var resource = _mapper.Map<User,UserResource>(user);
        return resource;

    }
    
     [HttpGet("={email}")]
        public async Task<UserResource> GetByEmailAsync(string email)
        {
            var user = await _userService.FindByEmailAsync(email);
            var resource = _mapper.Map<User,UserResource>(user);
            return resource;
    
        }
        
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<SaveUserResource, User>(resource);

        var result = await _userService.SaveAsync(user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user= _mapper.Map<SaveUserResource, User>(resource);

        var result = await _userService.UpdateAsync(id, user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }
    
    [HttpGet("{id}")]
    public async Task<UserResource> GetByIdAsync(int id)
    {
     
        var user = await _userService.FindByIdAsync(id);
 
        var resource = _mapper.Map<User, UserResource>(user);
        
        return resource;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var forumResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(forumResource);
    }
}