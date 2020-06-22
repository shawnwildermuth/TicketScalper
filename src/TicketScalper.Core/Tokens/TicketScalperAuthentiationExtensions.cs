using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.Core.Tokens
{
  public static class TicketScalperAuthentiationExtensions
  {
    public static AuthenticationBuilder AddTicketScalperAuthentication(this IServiceCollection coll, string key = "TokenOptions")
    {

      coll.AddAuthorization(cfg =>
      {
        var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
        defaultAuthorizationPolicyBuilder =
            defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
        cfg.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
      });

      return coll.AddAuthentication(cfg => {
        cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
                 .AddTicketScalperBearerToken();
    }


    public static AuthenticationBuilder AddTicketScalperBearerToken(this AuthenticationBuilder bldr, string key = "TokenOptions")
    {
      var config = bldr.Services.BuildServiceProvider().GetService<IConfiguration>();


      var options = new TicketScalperTokenOptions();
      config.Bind(key, options);

      return bldr.AddJwtBearer(cfg =>
      {
        cfg.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidIssuer = options.Issuer,
          ValidAudience = options.Audience,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey)), 
        };

      });
    }

    public static AuthenticationBuilder AddTicketScalperToken(this AuthenticationBuilder bldr, Action<JwtBearerOptions> config)
    {
      return bldr.AddJwtBearer(config);
    }
  }
}
