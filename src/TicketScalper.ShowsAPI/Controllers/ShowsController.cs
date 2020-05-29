using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.ShowsAPI.Data;
using TicketScalper.ShowsAPI.Data.Entities;
using TicketScalper.ShowsAPI.Models;

namespace TicketScalper.ShowsAPI.Controllers
{
  [Route("[controller]")]
  [ApiVersion("1.0")]
  [ApiController]
  public class ShowsController : ControllerBase
  {
    private readonly IShowRepository _repository;
    private readonly IMapper _mapper;

    public ShowsController(IShowRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet("latest")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<ShowModel[]>> GetLatest()
    {
      var result = await _repository.GetLatestShowsAsync();
      return _mapper.Map<IEnumerable<Show>, ShowModel[]>(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<ShowModel>> Get(int id)
    {
      var result = await _repository.GetShowAsync(id);
      return _mapper.Map<Show, ShowModel>(result);
    }

    [HttpGet("{id:int}/tickets")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TicketModel[]>> GetTickets(int id)
    {
      var result = await _repository.GetTicketsAsync(id);
      if (result == null || !result.Any())
      {
        return NotFound();
      }

      return _mapper.Map<IEnumerable<Ticket>, TicketModel[]>(result);
    }
    
  }
}
