using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for movies.
            if (context.Movie.Any())
            {
                return; // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "PG-13",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "G",
                    Price = 3.99M
                }
            );
            context.SaveChanges();


            // Look for Actors.
            if (context.Actor.Any())
            {
                return; // DB has been seeded
            }
            context.Actor.AddRange(
                new Actor
                {
                    FName = "Billy",
                    LName = "Crystal",
                    MovieId = 61,
                },
                new Actor
                {
                    FName = "Bill",
                    LName = "Murray",
                    MovieId = 62,
                },
                new Actor
                {
                    FName = "Harold",
                    LName = "Ramis",
                    MovieId = 63,
                },
                new Actor
                {
                    FName = "John",
                    LName = "Wayne",
                    MovieId = 64,
                }
            );
            context.SaveChanges();
        }
    }
}
