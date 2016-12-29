namespace TvSeriesApp.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TvSeriesApp.Models.SerieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TvSeriesApp.Models.SerieDbContext";
        }

        protected override void Seed(TvSeriesApp.Models.SerieDbContext context)
        {
            context.Series.AddOrUpdate(s => s.Title,
                new Serie
                {
                    Title = "Lost",
                    ReleasedDate = DateTime.Parse("2-12-2005"),
                    NumberOfSeasons = 6,
                    Genre = "Mystery",
                    Rating = "A"
                },
                 new Serie
                 {
                     Title = "Breaking Bad",
                     ReleasedDate = DateTime.Parse("2-12-2016"),
                     NumberOfSeasons = 8,
                     Genre = "Mystery",
                     Rating = "B"
                 },
                  new Serie
                  {
                      Title = "Narcos",
                      ReleasedDate = DateTime.Parse("8-12-2017"),
                      NumberOfSeasons = 2,
                      Genre = "Drama",
                      Rating = "B"
                  },
                  new Serie
                   {
                       Title = "Lampsi",
                       ReleasedDate = DateTime.Parse("2-12-2005"),
                       NumberOfSeasons = 7,
                       Genre = "Mystery",
                       Rating = "C"
                   },
                  new Serie
                   {
                       Title = "Narcos",
                       ReleasedDate = DateTime.Parse("2-12-2021"),
                       NumberOfSeasons = 7,
                       Genre = "Drama",
                       Rating = "A"
                   },
                  new Serie
                   {
                       Title = "Wolf",
                       ReleasedDate = DateTime.Parse("2-12-2015"),
                       NumberOfSeasons = 7,
                       Genre = "Mystery",
                       Rating = "C"
                   }
                );
        }
    }
}
