using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Services
{
  /// <summary>
  /// Service for providing the gRPC channel
  /// </summary>
  /// <seealso cref="TicketScalper.SalesAPI.Services.ITicketChannelProvider" />
  public class TicketChannelProvider : ITicketChannelProvider
  {
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="TicketChannelProvider" /> class.
    /// </summary>
    /// <param name="environment">The environment.</param>
    /// <param name="config">The configuration.</param>
    public TicketChannelProvider(IWebHostEnvironment environment, IConfiguration config)
    {
      _environment = environment;
      _config = config;
    }

    /// <summary>
    /// Provides the channel.
    /// </summary>
    /// <returns></returns>
    public GrpcChannel ProvideChannel()
    {
      GrpcChannel channel;
      if (_environment.IsDevelopment())
      {
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        channel = GrpcChannel.ForAddress(_config["Grpc.BaseUrl"], new GrpcChannelOptions
        {
          HttpHandler = httpHandler
        }); 
      }
      else
      {
        channel = GrpcChannel.ForAddress(_config["Grpc.BaseUrl"]); 
      }

      return channel;
    }
  }
}
