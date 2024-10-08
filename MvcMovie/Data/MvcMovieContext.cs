﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;
        public DbSet<MvcMovie.Models.Actor> Actor { get; set; } = default!;
        public DbSet<MvcMovie.Models.Director> Director { get; set; } = default!;
        public DbSet<MvcMovie.Models.Photo> Photo { get; set; } = default!;
    }
}
