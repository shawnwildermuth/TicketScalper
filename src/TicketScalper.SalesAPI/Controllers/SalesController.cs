using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data;
using TicketScalper.SalesAPI.Models;

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

    public SalesController(ILogger<SalesController> logger, IMapper mapper, ISalesRepository repository)
    {
      _logger = logger;
      _mapper = mapper;
      _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TicketSaleModel[]>> Get(int customerId)
    {
      var result = await _repository.GetSalesAsync(customerId);
      return _mapper.Map<TicketSaleModel[]>(result);
    }

  }
}
