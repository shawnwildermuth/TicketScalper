using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.AuthAPI.Models;
using TicketScalper.Core.Identity;

namespace TicketScalper.AuthAPI.Controllers
{
  [ApiController]
  [Route("auth/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly ILogger<UsersController> _logger;
    private readonly UserManager<TicketScalperIdentityUser> _userManager;
    private readonly IMapper _mapper;

    public UsersController(ILogger<UsersController> logger,
      UserManager<TicketScalperIdentityUser> userManager,
      IMapper mapper)
    {
      _logger = logger;
      _userManager = userManager;
      _mapper = mapper;
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<TicketScalperIdentityModel>> Get(string username)
    {
      try
      {
        var user = await _userManager.FindByNameAsync(username);

        if (user != null)
        {
          return _mapper.Map<TicketScalperIdentityModel>(user);
        }
        else
        {
          return NotFound();
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Error during GET for user: ", ex);
        return BadRequest($"Error during GET for user: {ex.Message}");
      }
    }

    [HttpPost]
    public async Task<ActionResult<TicketScalperIdentityModel>> Post([FromBody] TicketScalperIdentityRequestModel model)
    {
      try
      {
        var user = new TicketScalperIdentityUser()
        {
          UserName = model.Username,
          Email = model.Username,
          EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
          return CreatedAtRoute(new { username = user.UserName }, _mapper.Map<TicketScalperIdentityModel>(user));
        }
        else {
          return BadRequest(result.Errors.FirstOrDefault()?.Description);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to create new login: ", ex);
        return BadRequest($"Failed to create user: {ex.Message}");
      }

    }

    [HttpDelete("{username}")]
    public async Task<IActionResult> Delete(string username)
    {
      try
      {
        var user = await _userManager.FindByEmailAsync(username);
        if (user == null) return NotFound();

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
          return Ok();
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete new login: ", ex);
      }

      return BadRequest("Failed to delete user");
    }
  }
}
