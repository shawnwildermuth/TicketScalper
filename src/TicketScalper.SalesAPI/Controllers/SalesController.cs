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
    private readonly IWebHostEnvironment _environment;

    public SalesController(ILogger<SalesController> logger, 
      IMapper mapper, 
      ISalesRepository repository,
      IWebHostEnvironment environment)
    {
      _logger = logger;
      _mapper = mapper;
      _repository = repository;
      _environment = environment;
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
        var client = new TicketMessageService.TicketMessageServiceClient(channel);
        var request = new TicketRequest();
        request.TicketIds.Add(model.TicketIds);
        var response = await client.ReserveTicketsAsync(request);
        if (response.Success)
        {
          // Process Creditcard (no/op in example)

          // Finalize Tickets
          var confirmedResponse = await client.FinalizeTicketsAsync(request);

          if (confirmedResponse.Success)
          {
            // Create the Sales Record

            var ticketSale = new TicketSale()
            {
              CustomerId = customerId,
              Completed = true,
              ApprovalCode = "FOOBAR",
              TransactionNumber = "123456",
              PaymentType = "Credit Card",
              TransactionTotal = confirmedResponse.Tickets.Sum(t => (decimal)t.Price),
              Tickets = _mapper.Map<TicketInfo[]>(confirmedResponse.Tickets.ToArray())       
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
