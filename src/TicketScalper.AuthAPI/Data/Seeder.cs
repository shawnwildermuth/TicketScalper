using BountyApp.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.Core.Identity;

namespace TicketScalperApp.Identity.Data
{
  public static class Seeder
  {
    private static IServiceScope GenerateServiceScope()
    {
      var coll = new ServiceCollection();

      // ICollection
      var bldr = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile("appsettings.Development.json", true);

      var config = bldr.Build();
      coll.AddSingleton<IConfiguration>(config);

      // DbContext
      coll.AddDbContext<TicketScalperIdentityContext>(cfg =>
      {
        var connString = config.GetConnectionString("AuthDb");
        if (String.IsNullOrEmpty(connString))
        {
          Console.WriteLine("ConnectionString Missing!");
          throw new InvalidProgramException("Missing Connection String");
        }
        cfg.UseSqlServer(connString);
      });

      // Identity
      coll.AddIdentityCore<TicketScalperIdentityUser>()
          .AddEntityFrameworkStores<TicketScalperIdentityContext>();

      return coll.BuildServiceProvider().CreateScope();
    }

    public static async Task Seed()
    {

      using (var scope = GenerateServiceScope())
      {
        var svcs = scope.ServiceProvider;
        var db = svcs.GetService<TicketScalperIdentityContext>();
        db.Database.EnsureCreated();

        Console.WriteLine("Database Created");


        var userManager = svcs.GetService<UserManager<TicketScalperIdentityUser>>();

        var first = await userManager.FindByEmailAsync("shawn@wildermuth.com");
        if (first == null)
        {
          first = new TicketScalperIdentityUser()
          {
            UserName = "shawnwildermuth",
            Email = "shawn@wildermuth.com",
            EmailConfirmed = true
          };

          if ((await userManager.CreateAsync(first, "P@ssw0rd!")) == IdentityResult.Success)
          {
            // Add claim
            await userManager.AddClaimsAsync(first, new Claim[]
            {
              new Claim(JwtRegisteredClaimNames.GivenName, "Shawn"),
              new Claim(JwtRegisteredClaimNames.FamilyName, "Wildermuth"),
              new Claim("role", "user"),
              new Claim("role", "admin")
            });
            Console.WriteLine($"User ({first.UserName}) created.");
          }
          else
          {
            Console.WriteLine("Failed to create user");
          }
        }

        var second = await userManager.FindByEmailAsync("resa@wildermuth.com");
        if (second == null)
        {
          second = new TicketScalperIdentityUser()
          {
            UserName = "resatrain",
            Email = "resa@wildermuth.com",
            EmailConfirmed = true
          };

          if ((await userManager.CreateAsync(second, "P@ssw0rd!")) == IdentityResult.Success)
          {
            // Add claims
            await userManager.AddClaimsAsync(second, new Claim[]
            {
              new Claim(JwtRegisteredClaimNames.GivenName, "Resa"),
              new Claim(JwtRegisteredClaimNames.FamilyName, "Wildermuth"),
              new Claim("role", "user")
            });
            Console.WriteLine($"User ({second.UserName}) created.");
          }
          else
          {
            Console.WriteLine("Failed to create user");
          }
        }
      };
      Console.WriteLine("Database seeded...");
    }

    public static async Task Drop()
    {
      using (var scope = GenerateServiceScope())
      {
        var svcs = scope.ServiceProvider;
        var db = svcs.GetService<TicketScalperIdentityContext>();
        await db.Database.EnsureDeletedAsync();
      }
      Console.WriteLine("Database dropped...");
    }
  }
}
