using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Data.Entities
{
  /// <summary>
  /// Entity for Customer
  /// </summary>
  public class Customer
  {
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    public string FirstName { get; set; }
    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
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
    public string AddressLine1 { get; set; }
    /// <summary>
    /// Gets or sets the address line2.
    /// </summary>
    /// <value>
    /// The address line2.
    /// </value>
    public string AddressLine2 { get; set; }
    /// <summary>
    /// Gets or sets the address line3.
    /// </summary>
    /// <value>
    /// The address line3.
    /// </value>
    public string AddressLine3 { get; set; }
    /// <summary>
    /// Gets or sets the city town.
    /// </summary>
    /// <value>
    /// The city town.
    /// </value>
    public string CityTown { get; set; }
    /// <summary>
    /// Gets or sets the state province.
    /// </summary>
    /// <value>
    /// The state province.
    /// </value>
    public string StateProvince { get; set; }
    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>
    /// The postal code.
    /// </value>
    public string PostalCode { get; set; }
    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>
    /// The country.
    /// </value>
    public string Country { get; set; }
    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    /// <value>
    /// The name of the user.
    /// </value>
    public string UserName { set; get; }

    /// <summary>
    /// Gets or sets the sales.
    /// </summary>
    /// <value>
    /// The sales.
    /// </value>
    public ICollection<TicketSale> Sales { get; set; }

  }
}
