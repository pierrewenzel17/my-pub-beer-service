
using MyPubBeerService.Api.Models;
using MyPubBeerService.Api.Repositories;

namespace MyPubBeerService.Api.Services;

public interface IBeerService
{
  Task<IEnumerable<Beer>> GetBeersAsync();
  Task<Beer> GetBeerAsync(int id);
  Task<Beer> CreateBeerAsync(Beer Beer);
  Task<Beer> UpdateAsync(int id, Beer beer);
  Task DeleteAsync(int id);
}

public sealed class BeerService : IBeerService
{
  private readonly IBeerRepository _repository;

  public BeerService(IBeerRepository repository)
  {
    _repository = repository;
  }
  public async Task<Beer> CreateBeerAsync(Beer beer)
  {
    var res = await _repository.AddBeerAsync(beer);
    await _repository.SaveChangesAsync();
    return res;
  }

  public async Task DeleteAsync(int id)
  {
    var b = await _repository.GetBeerAsync(id);
    if(b is null) 
      throw new NullReferenceException("Beer not existe");
    _repository.Delete(b);
   await _repository.SaveChangesAsync();
  }

  public async Task<Beer> GetBeerAsync(int id)
  {
    return await _repository.GetBeerAsync(id);
  }

  public async Task<IEnumerable<Beer>> GetBeersAsync()
  {
    return await _repository.GetBeersAsync();
  }

  public async Task<Beer> UpdateAsync(int id, Beer beer)
  {
    var b = await _repository.GetBeerAsync(id);
    if(b is null)
    {
      throw new NullReferenceException("Beer not existe");
    }
    b.Country = beer.Country is not null? beer.Country : b.Country;
    b.Name = beer.Name is not null? beer.Name : b.Name;
    b.Type = beer.Type is not null? beer.Type : b.Type;
    b.Description = beer.Description is not null? beer.Description : b.Description;
    b.Categories = beer.Categories is not null? beer.Categories : b.Categories;
    var res =  _repository.Update(b);
    await _repository.SaveChangesAsync();
    return res;
  }
}