using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TicketScalper.Web.Pages
{
  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public class ErrorModel : PageModel
  {
    public string RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    public string ExceptionMessage { get; set; }

    public void OnGet()
    {
      RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

      var exceptionHandlerPathFeature =
          HttpContext.Features.Get<IExceptionHandlerPathFeature>();
      if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
      {
        ExceptionMessage = "File error thrown";
      }
      else
      {
        ExceptionMessage = $"{exceptionHandlerPathFeature.Error}";
      }
    }
  }
}
