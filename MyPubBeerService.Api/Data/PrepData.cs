using MyPubBeerService.Api.Models;

namespace MyPubBeerService.Api.Data;

public static class PrepData
{

  public static void AddData(BeerServiceDbContext context)
  {
    var list = new List<Beer>() {
      new Beer() { Id = 01, Name = "Chouffe Houblon", Country = "Belgique", Type = "Ale", Categories = "IPA",  Degree = 9, Bottle = 33, Description = "La Houblon Chouffe Dobbelen IPA Tripel représente le mariage époustouflant d’une IPA et d’une triple Belge, pour former une Belgian IPA qui satisfera tout le monde. Dans son verre, cette bière orangée légèrement trouble propose un nez raffiné, subtil équilibre entre le houblon, les épices et le malt. La bouche est puissante, onctueuse et ample, pour des notes épicées avec un final houblonné et particulièrement amer." },
      new Beer() { Id = 02, Name = "New Sweden IPA", Country = "Suède", Type = "Ale", Categories = "NEAPI", Degree = 6.2, Bottle = 33, Description = "Oppigårds n'a plus rien à prouver dans le monde des bières artisanales, c'est certain. Il n'empêche que cette brasserie suédoise va encore et toujours chercher à nous étonner et nous rallier à la cause du 'craft'. Son dernier brassin porte le nom de New Sweden IPA, et se dévoile par une robe jaune pâle et lumineuse coiffée d'une petite mousse blanche. En terme d'aromes, il y a des parfums de fruits tropicaux, d'herbes, de houblon, de citron et de pamplemousse." },
      new Beer() { Id = 03, Name = "Vedett IPA", Country = "Belgique", Type = "Ale", Categories = "IPA", Degree = 55, Bottle = 33, Description = "Vedett IPA est brassée dans la brasserie Duvel Moortgat. La Vedett IPA est une bière premium avec une grande diversité de variétés de houblon et de rendements de houblon. Cela crée un mélange d'agrumes fruités subtropicaux et d'arômes floraux frais avec un caractère doux et amer." },
      new Beer() { Id = 04, Name = "Aecht Schlenkerla Rauchbier Weizen", Country = "Allemange", Type = "Wheat Beer", Categories = "Rauchbier", Degree = 5.2, Bottle = 50, Description = "Traditionnellement, les blanches bavaroises sont brassées à partir d’un mélange de malt d’orge et de froment. La particularité de cette Acht Schlenkerla Rauchbier Weizen réside plutôt dans le fait que le malt d’orge est d’abord fumé avant d’être utilisé. C’est de cette technique de maltage bien particulière qu’elle tire sa spécificité. Cette bière blanche présente paradoxalement une robe ambrée foncée qui déroute l’amateur de blanches traditionnelles. La mousse se fait imposante.  Le nez lui aussi est étonnant, on y retrouve naturellement les aspects fumés du malt mais aussi le profil fruité des levures avec de jolies notes de banane. En bouche, l’attaque est bien balancée, entre aspects fruités et fumés. La suite se fait plus douce, bien que le malt fumé soit présent tout au long de la dégustation. Cette bière allemande, l’une des plus réputées, fera le plaisir des amateurs de bières blanches souhaitant découvrir d’autres horizons." }
    };

    context.Beers.AddRange(list);
    context.SaveChanges();
  }

}