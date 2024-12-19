using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetExcel([FromHeader] DateOnly month)
    {
        byte[] file = new byte[1];

        var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        var fileName = $"{timeStamp} - report.xlsx";

        if(file.Length > 0) 
            return File(file, MediaTypeNames.Application.Octet, fileName);

        return NoContent();
    }
}
