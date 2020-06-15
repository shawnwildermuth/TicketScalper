using System;

namespace TicketScalper.Core.Tokens
{
  public class TicketScalperToken
  {
    public string Token { get; internal set; }
    public DateTime Expiration { get; internal set; }
  }
}