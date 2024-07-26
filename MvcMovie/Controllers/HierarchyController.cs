//using System.Web.Mvc;
using System.Linq;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;

namespace MvcMovie.Controllers
{
    public partial class GridController : Controller
    {
        private readonly MvcMovieContext _context;
        // Dependency Injection injects the dataabase context into this controller
        // That context is used in each of the CRUD methods
        public GridController(MvcMovieContext context)
        {
            _context = context;
        }
        //[Demo]
        public ActionResult Hierarchy()
        {
            return View();
        }

        public ActionResult HierarchyBindingMovies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_context.Movie.ToDataSourceResult(request));
        }

        public ActionResult HierarchyBinding_Actors(int movieId, [DataSourceRequest] DataSourceRequest request)
        {
            return Json(_context.Actor
                .Where(actor => actor.MovieId == movieId)
                .ToDataSourceResult(request));
        }
    }
}