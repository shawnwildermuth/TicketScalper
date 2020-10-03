using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketScalper.Core.Controllers;
using TicketScalper.SalesAPI.Data;
using TicketScalper.SalesAPI.Data.Entities;
using TicketScalper.SalesAPI.Models;

namespace TicketScalper.SalesAPI.Controllers
{
  /// <summary>
  /// The controller for Customers
  /// </summary>
  /// <seealso cref="TicketScalper.Core.Controllers.UserController" />
  [Route("[controller]")]
  [ApiVersion("1.0")]
  [ApiController]
  [Authorize]
  public class CustomersController : UserController
  {
    private readonly ILogger<CustomersController> _logger;
    private readonly IMapper _mapper;
    private readonly ISalesRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomersController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="repository">The repository.</param>
    public CustomersController(ILogger<CustomersController> logger, IMapper mapper, ISalesRepository repository)
    {
      _logger = logger;
      _mapper = mapper;
      _repository = repository;
    }

    /// <summary>
    /// Gets the customers asynchronous.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<CustomerModel>> GetCustomersAsync()
    {
      return _mapper.Map<CustomerModel>(await _repository.GetCustomerByUserAsync(UserName));
    }

    /// <summary>
    /// Posts the asynchronous.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CustomerModel>> PostAsync([FromBody] CustomerModel model)
    {
      try
      {
        var entity = _mapper.Map<Customer>(model);

        if (await _repository.HasCustomerAsync(UserName))
        {
          return BadRequest("Duplicate Customer");
        }

        entity.UserName = UserName;

        _repository.Add(entity);

        if (await _repository.SaveAllAsync())
        {
          return CreatedAtRoute(new { }, _mapper.Map<CustomerModel>(entity));
        }
      }
      catch (Exception ex)
      {
        _logger.LogWarning("Failed to save customer", ex);
      }

      return BadRequest("Could not create new Customer");
    }

    /// <summary>
    /// Puts the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CustomerModel>> Put(int id, [FromBody] CustomerModel model)
    {
      try
      {
        var existing = await _repository.GetCustomerAsync(id);

        if (existing == null) return NotFound();

        _mapper.Map(model, existing);

        if (await _repository.SaveAllAsync())
        {
          return Ok(_mapper.Map<CustomerModel>(existing));
        }
      }
      catch (Exception ex)
      {
        _logger.LogWarning("Failed to update customer", ex);
      }

      return BadRequest("Could not update Customer");
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var customer = await _repository.GetCustomerAsync(id);
        if (customer == null) return NotFound();
        if (await _repository.HasSalesAsync(id)) return BadRequest("Cannot delete customers with Sales");

        _repository.Delete(customer);
        if (await _repository.SaveAllAsync())
        {
          return Ok();
        }

      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete customer", ex);
      }

      return BadRequest("Failed to delete customer, unknown reason");
    }
  }
}
