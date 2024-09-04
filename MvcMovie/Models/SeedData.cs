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

            context.Photo.AddRange(
                new Photo
                {
                    Name = "When Harry Met Sally Poster",
                    Path = "C:\\Users\\nramsey-az\\Desktop\\MvcMovie\\MvcMovie\\wwwroot\\Photos\\whms.jpg",
                    Description = "The movie poster for When Harry Met Sally",
                    MovieId = 85
                },
                new Photo
                {
                    Name = "Ghostbusters Poster",
                    Path = "C:\\Users\\nramsey-az\\Desktop\\MvcMovie\\MvcMovie\\wwwroot\\Photos\\gb.jpg",
                    Description = "The movie poster for Ghostbusters",
                    MovieId = 86
                },
                new Photo
                {
                    Name = "Ghostbusters II Poster",
                    Path = "C:\\Users\\nramsey-az\\Desktop\\MvcMovie\\MvcMovie\\wwwroot\\Photos\\gb2.jpg",
                    Description = "The movie poster for Ghostbusters II",
                    MovieId = 87
                },
                new Photo
                {
                    Name = "Rio Bravo Poster",
                    Path = "C:\\Users\\nramsey-az\\Desktop\\MvcMovie\\MvcMovie\\wwwroot\\Photos\\rb.jpg",
                    Description = "The movie poster for Rio Bravo",
                    MovieId = 88
                }
            );
            context.SaveChanges();
        }
    }
}
