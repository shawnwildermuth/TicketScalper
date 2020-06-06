using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Services
{
  public class TicketChannelProvider : ITicketChannelProvider
  {
    private readonly IWebHostEnvironment _environment;

    public TicketChannelProvider(IWebHostEnvironment environment)
    {
      _environment = environment;
    }

    public GrpcChannel ProvideChannel()
    {
      GrpcChannel channel;
      if (_environment.IsDevelopment())
      {
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
        {
          HttpHandler = httpHandler
        }); // TODO Move to configuration/Kube
      }
      else
      {
        channel = GrpcChannel.ForAddress("https://localhost:5001"); // TODO Move to configuration/Kube
      }

      return channel;
    }
  }
}
