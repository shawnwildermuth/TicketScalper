using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Data.Entities
{
  /// <summary>
  /// Entity for TicketInfo
  /// </summary>
  public class TicketInfo
  {
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the show.
    /// </summary>
    /// <value>
    /// The name of the show.
    /// </value>
    public string ShowName { get; set; }
    /// <summary>
    /// Gets or sets the acts.
    /// </summary>
    /// <value>
    /// The acts.
    /// </value>
    public string Acts { get; set; }
    /// <summary>
    /// Gets or sets the seat.
    /// </summary>
    /// <value>
    /// The seat.
    /// </value>
    public string Seat { get; set; }
    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>
    /// The price.
    /// </value>
    public decimal Price { get; set; }
    /// <summary>
    /// Gets or sets the show date.
    /// </summary>
    /// <value>
    /// The show date.
    /// </value>
    public DateTime ShowDate { get; set; }
    /// <summary>
    /// Gets or sets the name of the venue.
    /// </summary>
    /// <value>
    /// The name of the venue.
    /// </value>
    public string VenueName { get; set; }
    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    /// <value>
    /// The phone number.
    /// </value>
    public string PhoneNumber { get; set; }
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
    /// Gets or sets the sale.
    /// </summary>
    /// <value>
    /// The sale.
    /// </value>
    public TicketSale Sale { get; set; }
    /// <summary>
    /// Gets or sets the sale identifier.
    /// </summary>
    /// <value>
    /// The sale identifier.
    /// </value>
    public int SaleId { get; set; }
  }
}
