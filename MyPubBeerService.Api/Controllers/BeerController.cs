using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using MyPubBeerService.Api.Models;
using MyPubBeerService.Api.Services;

namespace MyPubBeerService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class BeerController : ControllerBase
{
  private readonly IBeerService _service;
  private readonly ILogger<BeerController> _logger;

  public BeerController(ILogger<BeerController> logger, IBeerService service)
  {
    _service = service;
    _logger = logger;
  }

  [HttpPost]
  public async Task<IActionResult> CreateBeerAsync([FromBody] Beer Beer)
  {
    var res = await _service.CreateBeerAsync(Beer);
    return CreatedAtRoute(nameof(GetBeer), new { Id = res.Id }, res);
  }

  [HttpGet]
  [EnableQuery]
  public async Task<IActionResult> GetBeers()
  {
    return Ok(await _service.GetBeersAsync());
  }

  [HttpGet]
  [EnableQuery]
  [Route("{id}", Name = "GetBeer")]
  public async Task<IActionResult> GetBeer([FromRoute] int? id)
  {
    try
    {
      if (id == null)
        throw new ArgumentNullException($"{nameof(id)} de la ressouce est null");
      if (id <= 0)
        throw new ArgumentException($"{nameof(id)} : {id} est inferieur égale à 0");
      var Beer = await _service.GetBeerAsync((int)id);
      if (Beer == null)
        throw new NullReferenceException($"{nameof(id)} : {id} n'existe pas dans la base");
      _logger.LogInformation(1, $"{Beer.ToString()}, a été retourner");
      return Ok(Beer);
    }
    catch (ArgumentException exception)
    {
      _logger.LogError(exception, exception.Message);
      return BadRequest();
    }
    catch (NullReferenceException exception)
    {
      _logger.LogWarning(exception, exception.Message);
      return NotFound();
    }
  }

  [HttpPut]
  [Route("{id}")]
  public async Task<IActionResult> Update([FromRoute] int? id, [FromBody] Beer beer)
  {
    try
    {
      if (id == null)
        throw new ArgumentNullException($"{nameof(id)} de la ressouce est null");
      if (id <= 0)
        throw new ArgumentException($"{nameof(id)} : {id} est inferieur égale à 0");
      if(beer is null)
        throw new ArgumentNullException($"{nameof(beer)} de la ressouce est null");
      var Beer = await _service.UpdateAsync((int)id, beer);
      return Ok(Beer);
    }
    catch (ArgumentException exception)
    {
      _logger.LogError(exception, exception.Message);
      return BadRequest();
    }
    catch (NullReferenceException exception)
    {
      _logger.LogWarning(exception, exception.Message);
      return NotFound();
    }
  }

  [HttpDelete]
  [Route("{id}")]
  public async Task<IActionResult> Delete([FromRoute] int? id) 
  {
        try
    {
      if (id == null)
        throw new ArgumentNullException($"{nameof(id)} de la ressouce est null");
      if (id <= 0)
        throw new ArgumentException($"{nameof(id)} : {id} est inferieur égale à 0");
      await _service.DeleteAsync((int)id);
      return Ok();
    }
    catch (ArgumentException exception)
    {
      _logger.LogError(exception, exception.Message);
      return BadRequest();
    }
    catch (NullReferenceException exception)
    {
      _logger.LogWarning(exception, exception.Message);
      return NotFound();
    }
  }
}