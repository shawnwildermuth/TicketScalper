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
using TicketScalper.Core.Tokens;

namespace TicketScalper.AuthAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ConnectController : ControllerBase
  {
    private readonly ILogger<ConnectController> _logger;
    private readonly TicketScalperTokenFactory _tokenFactory;
    private readonly UserManager<TicketScalperIdentityUser> _userManager;

    public ConnectController(ILogger<ConnectController> logger,
      TicketScalperTokenFactory tokenFactory,
      UserManager<TicketScalperIdentityUser> userManager)
    {
      _logger = logger;
      _tokenFactory = tokenFactory;
      _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult<TicketScalperToken>> Post([FromBody] TokenRequestViewModel model)
    {
      // Allow by username or email
      var user = await _userManager.FindByNameAsync(model.Username);
      if (user == null) user = await _userManager.FindByEmailAsync(model.Username);

      if (user == null) return BadRequest("Invalid User");

      var token = await _tokenFactory.GenerateForUser(user);

      return Created("", token);
    }
  }
}
