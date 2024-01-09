using ActorsManagerService.Models;
using HtmlAgilityPack;

namespace ActorsManagerService.Data
{
    public static class PreparationDb
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                PopulateData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        public static void PopulateData(AppDbContext? context)
        {
            if (context == null || context.Actors == null || context.Actors.Any())
            {
                return;
            }

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.imdb.com/list/ls000004615/");

            HtmlNodeCollection actorItems = doc.DocumentNode.SelectNodes("//div[@class='lister-item-content']");

            foreach (HtmlNode actorItem in actorItems)
            {
                string name = actorItem.SelectSingleNode(".//h3/a").InnerText.Trim();

                string details = actorItem.SelectSingleNode(".//p[last()]").InnerText.Trim();

                int rank = int.Parse(actorItem.SelectSingleNode(".//span[@class='lister-item-index unbold text-primary']").InnerText.TrimEnd(new char[] { '.', ' ' }));

                var actor = new Actor
                {
                    Name = name,
                    Details = details,
                    Rank = rank
                };
                context.Actors.Add(actor);
            }

            context.SaveChanges();
        }

    }
}
