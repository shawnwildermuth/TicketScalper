using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.Core.Data;
using TicketScalper.ShowsAPI.Data;

namespace TicketScalper.ShowsAPI.Services
{
  public class TicketService : TicketMessageService.TicketMessageServiceBase
  {
    private readonly ILogger<TicketService> _logger;
    private readonly IShowRepository _repository;
    private readonly IMapper _mapper;

    public TicketService(ILogger<TicketService> logger, IShowRepository repository, IMapper mapper)
    {
      _logger = logger;
      _repository = repository;
      _mapper = mapper;
    }

    public override async Task<ConfirmedTicketResponse> FinalizeTickets(TicketRequest request, ServerCallContext context)
    {
      var response = new ConfirmedTicketResponse()
      {
        Success = false
      };

      try
      {
        var tickets = await _repository.GetTicketsAsync(request.TicketIds.ToArray());

        if (tickets.Count() == request.TicketIds.Count())
        {
          // TODO actually remove, I'm just deleting it for demo
          foreach (var ticket in tickets)
          {
            var ticketMessage = _mapper.Map<TicketMessage>(ticket);
            response.Tickets.Add(ticketMessage);
            _repository.Delete(ticket);
          }

          if (await _repository.SaveAllAsync())
          {
            response.Success = true;
          }
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to finalize tickets.", ex);
        response.UserMessage = "Failed to finalize your tickets. Error occurred.";
      }

      return response;
    }

    public override async Task<TicketResponse> ReserveTickets(TicketRequest request, ServerCallContext context)
    {
      var response = new TicketResponse()
      {
        Success = false
      };

      try
      {
        var tickets = await _repository.GetTicketsAsync(request.TicketIds.ToArray());
        if (tickets.Count() == request.TicketIds.Count())
        {
          // TODO actually reserve, but for demo not necessary
          response.Success = true;
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to reserve tickets.", ex);
        response.UserMessage = "Failed to reserve your tickets. Error occurred.";
      }

      return response;
      
    }
  }
}
