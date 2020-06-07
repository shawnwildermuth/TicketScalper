using AutoMapper;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data;
using TicketScalper.SalesAPI.Data.Entities;
using TicketScalper.SalesAPI.Models;
using TicketScalper.SalesAPI.Services;
using TicketScalper.ShowsAPI.Services;

namespace TicketScalper.SalesAPI.Controllers
{
  [Route("customers/{customerId:int}/[controller]")]
  [ApiVersion("1.0")]
  [ApiController]
  public class SalesController : ControllerBase
  {
    private readonly ILogger<SalesController> _logger;
    private readonly IMapper _mapper;
    private readonly ISalesRepository _repository;
    private readonly ITicketService _ticketService;

    public SalesController(ILogger<SalesController> logger, 
      IMapper mapper, 
      ISalesRepository repository,
      ITicketService ticketService)
    {
      _logger = logger;
      _mapper = mapper;
      _repository = repository;
      _ticketService = ticketService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TicketSaleModel[]>> Get(int customerId)
    {
      var result = await _repository.GetSalesAsync(customerId);
      return _mapper.Map<TicketSaleModel[]>(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TicketSaleModel>> Get(int customerId, int id)
    {
      var result = await _repository.GetSaleAsync(customerId, id);
      return _mapper.Map<TicketSaleModel>(result);
    }

    [HttpPost("ticketrequest")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TicketSaleModel>> Post(int customerId, [FromBody]TicketRequestModel model)
    {
      try
      {
        var customer = await _repository.GetCustomerAsync(customerId);
        if (customer == null) return NotFound();

        // Check Ticket Availability
        var result = await _ticketService.ReserveTickets(model.TicketIds);
        if (result)
        {
          // Process Creditcard (no/op in example)
          
          // Finalize Tickets
          var finalizedTickets = await _ticketService.FinalizeTickets(model.TicketIds);
          if (finalizedTickets.Success)
          {
            // Create the Sales Record

            var ticketSale = new TicketSale()
            {
              Customer = customer,
              Completed = true,
              ApprovalCode = "FOOBAR",
              TransactionNumber = "123456",
              PaymentType = "Credit Card",
              TransactionTotal = finalizedTickets.Tickets.Sum(t => (decimal)t.Price),
              Tickets = finalizedTickets.Tickets.ToArray()       
            };

            _repository.Add(ticketSale);

            if (await _repository.SaveAllAsync())
            {
              return CreatedAtRoute(new { customerId = customerId, id = ticketSale.Id }, _mapper.Map<TicketSaleModel>(ticketSale));
            }
          }
        }

      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to create TicketRequest", ex);
      }

      return BadRequest();
    }
  }
}
