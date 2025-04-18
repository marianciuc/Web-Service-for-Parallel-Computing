using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebServiceProgRozpr.Services;

namespace WebServiceProgRozpr.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class MandelbrotSetController(
    ILogger<MandelbrotSetController> logger,
    IMandelbrotSetService mandelbrotSetService) : ControllerBase
{
    
    [HttpGet(Name = "Generate Factorial")]
    [Produces(MediaTypeNames.Image.Png)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Generate(int height, int weight, int threads)
    {
        if (height <= 0 || weight <= 0 || threads <= 0)
            return BadRequest("Height, weight and threads must be positive integers");
        try
        {
            Console.WriteLine("Trying to generate factorial");
            using MemoryStream ms = new MemoryStream();
            mandelbrotSetService
                .Generate(width: height, height: weight, threads)
                .Save(ms, ImageFormat.Png);
            return File(ms.ToArray(), MediaTypeNames.Image.Png);
        }
        catch (InvalidOperationException e)
        {
            logger.LogError(e, "Error generating factorial");
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}