using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.SalesAPI.Data;

namespace TicketScalper.SalesAPI.Controllers
{
  [Route("[controller]")]
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
  }
}
