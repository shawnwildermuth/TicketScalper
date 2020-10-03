using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Models
{
  /// <summary>
  /// Model for Customer data
  /// </summary>
  public class CustomerModel
  {
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the full name.
    /// </summary>
    /// <value>
    /// The full name.
    /// </value>
    [Ignore]
    public string FullName { get; set; }
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    /// <value>
    /// The phone number.
    /// </value>
    public string PhoneNumber { get; set; }
    /// <summary>
    /// Gets or sets the name of the company.
    /// </summary>
    /// <value>
    /// The name of the company.
    /// </value>
    public string CompanyName { get; set; }
    /// <summary>
    /// Gets or sets the address line1.
    /// </summary>
    /// <value>
    /// The address line1.
    /// </value>
    [Required]
    [MaxLength(100)]
    public string AddressLine1 { get; set; }
    /// <summary>
    /// Gets or sets the address line2.
    /// </summary>
    /// <value>
    /// The address line2.
    /// </value>
    [MaxLength(100)]
    public string AddressLine2 { get; set; }
    /// <summary>
    /// Gets or sets the address line3.
    /// </summary>
    /// <value>
    /// The address line3.
    /// </value>
    [MaxLength(100)]
    public string AddressLine3 { get; set; }
    /// <summary>
    /// Gets or sets the city town.
    /// </summary>
    /// <value>
    /// The city town.
    /// </value>
    [Required]
    [MaxLength(100)]
    public string CityTown { get; set; }
    /// <summary>
    /// Gets or sets the state province.
    /// </summary>
    /// <value>
    /// The state province.
    /// </value>
    [Required]
    [MaxLength(50)]
    public string StateProvince { get; set; }
    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>
    /// The postal code.
    /// </value>
    [Required]
    [MaxLength(20)]
    public string PostalCode { get; set; }
    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>
    /// The country.
    /// </value>
    [MaxLength(100)]
    public string Country { get; set; }
  }
}
