using Microsoft.EntityFrameworkCore;
using MyPubBeerService.Api.Models;

namespace MyPubBeerService.Api.Data;

public sealed class BeerServiceDbContext : DbContext
{
  public BeerServiceDbContext(DbContextOptions<BeerServiceDbContext> opt) : base(opt) { }

  public DbSet<Beer> Beers { get; set; }
  
}