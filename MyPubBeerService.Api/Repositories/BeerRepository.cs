using Microsoft.EntityFrameworkCore;
using MyPubBeerService.Api.Data;
using MyPubBeerService.Api.Models;

namespace MyPubBeerService.Api.Repositories;

public interface IBeerRepository
{
  Task<bool> SaveChangesAsync();
  Task<IEnumerable<Beer>> GetBeersAsync();
  Task<Beer> GetBeerAsync(int id);
  Task<Beer> AddBeerAsync(Beer Beer);
  Beer Update(Beer beer);
  void Delete(Beer beer);
}

public sealed class BeerRepository : IBeerRepository
{
  private readonly BeerServiceDbContext _context;

  public BeerRepository(BeerServiceDbContext context) => _context = context;
  public async Task<Beer> AddBeerAsync(Beer beer)
  {
    if (beer == null)
    {
      throw new ArgumentNullException(nameof(Beer));
    }
    var b = await _context.Beers.AddAsync(beer);

    return b.Entity;
  }

  public Beer Update(Beer beer) 
  {
    var b = _context.Beers.Update(beer);
    return b.Entity;
  }

  public async Task<Beer> GetBeerAsync(int id) => await _context.Beers.FindAsync(id);

  public async Task<IEnumerable<Beer>> GetBeersAsync()
  {
    return await _context.Beers.ToListAsync();
  }

  public async Task<bool> SaveChangesAsync() => (await _context.SaveChangesAsync() >= 0);

  public void Delete(Beer beer) 
  {
    _context.Beers.Remove(beer);
  }
}