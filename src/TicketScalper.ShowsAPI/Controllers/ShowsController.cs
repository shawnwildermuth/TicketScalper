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
  /// <summary>
  /// Controller to return data about Shows
  /// </summary>
  /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
  [Route("[controller]")]
  [ApiVersion("1.0")]
  [ApiController]
  public class ShowsController : ControllerBase
  {
    private readonly IShowRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShowsController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="mapper">The mapper.</param>
    public ShowsController(IShowRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    /// <summary>
    /// Gets the latest.
    /// </summary>
    /// <returns>Shows</returns>
    [HttpGet("latest")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<ShowModel[]>> GetLatest()
    {
      try
      {
        var result = await _repository.GetLatestShowsAsync();
        return _mapper.Map<IEnumerable<Show>, ShowModel[]>(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }


    /// <summary>
    /// Gets the specified Show.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<ShowModel>> Get(int id)
    {
      var result = await _repository.GetShowAsync(id);
      return _mapper.Map<Show, ShowModel>(result);
    }

    /// <summary>
    /// Gets the tickets.
    /// </summary>
    /// <param name="id">The id of the show.</param>
    /// <returns></returns>
    [HttpGet("{id:int}/tickets")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TicketModel[]>> GetTickets(int id)
    {
      var result = await _repository.GetTicketsForShowAsync(id);
      if (result == null || !result.Any())
      {
        return NotFound();
      }

      return _mapper.Map<IEnumerable<Ticket>, TicketModel[]>(result);
    }
    
  }
}
