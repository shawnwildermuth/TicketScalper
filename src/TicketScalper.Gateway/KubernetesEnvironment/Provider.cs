using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.Configuration;
using Ocelot.Logging;
using Ocelot.ServiceDiscovery;
using Ocelot.ServiceDiscovery.Providers;
using Ocelot.Values;

namespace TicketScalper.Gateway.KubernetesEnvironment
{
  public class KubernetesEnvironmentServiceDiscoveryProvider : IServiceDiscoveryProvider
  {
    private readonly IOcelotLogger _logger;
    private readonly DownstreamRoute _route;

    public static ServiceDiscoveryFinderDelegate GetFinder = (provider, config, route) =>
    {
      var factory = provider.GetService<IOcelotLoggerFactory>();

      return new KubernetesEnvironmentServiceDiscoveryProvider(factory, route);
    };

    public KubernetesEnvironmentServiceDiscoveryProvider(IOcelotLoggerFactory loggerFactory, DownstreamRoute routes)
    {
      _logger = loggerFactory.CreateLogger<KubernetesEnvironmentServiceDiscoveryProvider>();
      _route = routes;
    }

    public Task<List<Service>> Get()
    {
      var svcs = new List<Service>();

      if (!string.IsNullOrWhiteSpace(_route.ServiceName))
      {
        var envServiceName = _route.ServiceName.ToUpperInvariant().Replace('-', '_');
        var host = Environment.GetEnvironmentVariable($"{envServiceName}_HOST");
        if (!string.IsNullOrWhiteSpace(host))
        {
          int port;
          if (int.TryParse(Environment.GetEnvironmentVariable($"{envServiceName}_PORT"), out port))
          {
            _logger.LogInformation($"Found Service: {_route.ServiceName}");
            svcs.Add(new Service(_route.ServiceName,
              new ServiceHostAndPort(host, port),
              Guid.NewGuid().ToString(),
              string.Empty,
              Enumerable.Empty<string>()));

          }
        }
      }

      return Task.FromResult(svcs);
    }
  }
}
