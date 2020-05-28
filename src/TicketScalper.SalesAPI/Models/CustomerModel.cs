using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketScalper.SalesAPI.Models
{
  public class CustomerModel
  {
    public int Id { get; set; }
    [Ignore]
    public string FullName { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string CompanyName { get; set; }
    [Required]
    [MaxLength(100)]
    public string AddressLine1 { get; set; }
    [MaxLength(100)]
    public string AddressLine2 { get; set; }
    [MaxLength(100)]
    public string AddressLine3 { get; set; }
    [Required]
    [MaxLength(100)]
    public string CityTown { get; set; }
    [Required]
    [MaxLength(50)]
    public string StateProvince { get; set; }
    [Required]
    [MaxLength(20)]
    public string PostalCode { get; set; }
    [MaxLength(100)]
    public string Country { get; set; }
  }
}
