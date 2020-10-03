using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;

namespace TicketScalper.Gateway.KubernetesEnvironment
{
  public static class KubernetesEnvironmentExtensions
  {
    public static IOcelotBuilder AddKubernetesEnvironmentServices(this IOcelotBuilder builder)
    {
      builder.Services.AddSingleton(KubernetesEnvironmentServiceDiscoveryProvider.GetFinder);
      return builder;
    }
  }
}
