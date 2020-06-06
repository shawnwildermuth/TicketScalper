using Grpc.Net.Client;

namespace TicketScalper.SalesAPI.Services
{
  public interface ITicketChannelProvider
  {
    GrpcChannel ProvideChannel();
  }
}