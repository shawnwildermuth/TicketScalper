﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data.Entities;
using TicketScalper.SalesAPI.Models;
using TicketScalper.ShowsAPI.Services;

namespace TicketScalper.SalesAPI.Services
{
  /// <summary>
  /// Service for returning Tickets
  /// </summary>
  /// <seealso cref="TicketScalper.SalesAPI.Services.ITicketService" />
  public class TicketService : ITicketService
  {
    private readonly ITicketChannelProvider _channelProvider;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="TicketService"/> class.
    /// </summary>
    /// <param name="channelProvider">The channel provider.</param>
    /// <param name="mapper">The mapper.</param>
    public TicketService(ITicketChannelProvider channelProvider, IMapper mapper)
    {
      _channelProvider = channelProvider;
      _mapper = mapper;
    }

    /// <summary>
    /// Reserves the tickets.
    /// </summary>
    /// <param name="tickets">The tickets.</param>
    /// <returns></returns>
    public async Task<bool> ReserveTickets(int[] tickets)
    {
      var client = new TicketMessageService.TicketMessageServiceClient(_channelProvider.ProvideChannel());
      var request = new TicketRequest();
      request.TicketIds.Add(tickets);
      var response = await client.ReserveTicketsAsync(request);
      return response.Success;
    }

    /// <summary>
    /// Finalizes the tickets.
    /// </summary>
    /// <param name="tickets">The tickets.</param>
    /// <returns></returns>
    public async Task<FinalizedTicketResponse> FinalizeTickets(int[] tickets)
    {
      var client = new TicketMessageService.TicketMessageServiceClient(_channelProvider.ProvideChannel());
      var request = new TicketRequest();
      request.TicketIds.Add(tickets);
      var response = await client.FinalizeTicketsAsync(request);
      var ticketResponse = new FinalizedTicketResponse()
      {
        Success = response.Success,
        Tickets = _mapper.Map<IEnumerable<TicketInfo>>(response.Tickets.ToArray())
      };
      return ticketResponse;
    }

  }
}
