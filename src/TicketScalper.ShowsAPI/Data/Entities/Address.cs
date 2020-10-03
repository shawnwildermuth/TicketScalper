namespace TicketScalper.ShowsAPI.Data.Entities
{
  /// <summary>
  /// Entity for an Address
  /// </summary>
  public class Address
  {
    /// <summary>
    /// Gets or sets the address1.
    /// </summary>
    /// <value>
    /// The address1.
    /// </value>
    public string Address1 { get; set; }
    /// <summary>
    /// Gets or sets the address2.
    /// </summary>
    /// <value>
    /// The address2.
    /// </value>
    public string Address2 { get; set; }
    /// <summary>
    /// Gets or sets the address3.
    /// </summary>
    /// <value>
    /// The address3.
    /// </value>
    public string Address3 { get; set; }
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
    /// Gets the venue identifier.
    /// </summary>
    /// <value>
    /// The venue identifier.
    /// </value>
    public int VenueId { get; internal set; }
  }
}