using Grpc.Net.Client;

namespace TicketScalper.SalesAPI.Services
{
  /// <summary>
  /// Interface for providing a gRPC channel
  /// </summary>
  public interface ITicketChannelProvider
  {
    /// <summary>
    /// Provides the channel.
    /// </summary>
    /// <returns></returns>
    GrpcChannel ProvideChannel();
  }
}