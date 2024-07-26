using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Linq;


namespace MvcMovie.Controllers
{
    public class MoviesExpandedController : Controller
    {

        private readonly MvcMovieContext _context;
        // Dependency Injection injects the dataabase context into this controller
        // That context is used in each of the CRUD methods
        public MoviesExpandedController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MoviesRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_context.Movie.ToDataSourceResult(request));
        }

        public ActionResult MovieCreate([DataSourceRequest] DataSourceRequest request, [Bind("MovieId,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();

            }
            return Json(new[] { movie }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult MovieEdit([DataSourceRequest] DataSourceRequest request, [Bind("MovieId,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (movie != null && ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();
            }
            return Json(new[] { movie }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult MovieDelete([DataSourceRequest] DataSourceRequest request, [Bind("MovieId,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Remove(movie);
                _context.SaveChanges();
            }
            return Json(new[] { movie }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult DetailTemplate_HierarchyBinding_Actors(int movieId, [DataSourceRequest] DataSourceRequest request)
        {
            return Json(_context.Actor
                .Where(actor => actor.MovieId == movieId)
                .ToDataSourceResult(request));
        }
    }
}