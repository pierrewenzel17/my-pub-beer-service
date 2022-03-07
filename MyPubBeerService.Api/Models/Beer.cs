using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPubBeerService.Api.Models;

[Table("beer")]
public class Beer
{
  [Key, Required, Column("id")]
  public int Id { get; set; }

  [Required, Column("name")]
  public string Name { get; set; }

  [Required, Column("country")]
  public string Country { get; set; }

  [Required, Column("type")]
  public string Type { get; set; }

  [Required, Column("categories")]
  public string Categories { get; set; }

  [Required, Column("degree")]
  public double Degree { get; set; }

  [Required, Column("bottle")]
  public double Bottle { get; set; }

  [Required, Column("description")]
  public string Description { get; set; }
}