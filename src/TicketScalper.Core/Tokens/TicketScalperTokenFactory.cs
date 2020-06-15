using TicketScalper.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.Core.Tokens
{
  public class TicketScalperTokenFactory
  {
    private readonly IConfiguration _config;
    private readonly UserManager<TicketScalperIdentityUser> _userManager;
    private TicketScalperTokenOptions _tokenOptions = new TicketScalperTokenOptions();

    public TicketScalperTokenFactory(IConfiguration config, UserManager<TicketScalperIdentityUser> userManager)
    {
      _config = config;
      _userManager = userManager;
    }

    public async Task<TicketScalperToken> GenerateForUser(TicketScalperIdentityUser user, string optionsKey = "TokenOptions")
    {
      _config.Bind(optionsKey, _tokenOptions);

      // Create the token
      var claims = new List<Claim>()
      {
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
      };

      var userClaims = await _userManager.GetClaimsAsync(user);

      claims.AddRange(userClaims);

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SigningKey));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

      var token = new JwtSecurityToken(
        _tokenOptions.Issuer,
        _tokenOptions.Audience,
        claims,
        expires: DateTime.Now.AddMinutes(_tokenOptions.ExpirationLength),
        signingCredentials: creds);

      return new TicketScalperToken()
      {
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Expiration = token.ValidTo
      };
    }
  }
}
