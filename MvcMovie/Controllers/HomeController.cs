using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Diagnostics;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<ProductViewModel> products = new List<ProductViewModel> {
            new ProductViewModel { ProductID = 1, ProductName = "Chai", UnitPrice = 18, UnitsInStock = 39, Discontinued = false },
            new ProductViewModel { ProductID = 2, ProductName = "Chang", UnitPrice = 19, UnitsInStock = 17, Discontinued = false },
            new ProductViewModel { ProductID = 3, ProductName = "Aniseed Syrup", UnitPrice = 10, UnitsInStock = 13, Discontinued = false },
            new ProductViewModel { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", UnitPrice = 21, UnitsInStock = 53, Discontinued = false },
            new ProductViewModel { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", UnitPrice = 18, UnitsInStock = 0, Discontinued = true },
            new ProductViewModel { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", UnitPrice = 25, UnitsInStock = 120, Discontinued = false },
            new ProductViewModel { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", UnitPrice = 30, UnitsInStock = 15, Discontinued = false },
            new ProductViewModel { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", UnitPrice = 40, UnitsInStock = 6, Discontinued = false },
            new ProductViewModel { ProductID = 9, ProductName = "Mishi Kobe Niku", UnitPrice = 97, UnitsInStock = 29, Discontinued = true },
            new ProductViewModel { ProductID = 10, ProductName = "Ikura", UnitPrice = 31, UnitsInStock = 31, Discontinued = false },
            new ProductViewModel { ProductID = 11, ProductName = "Queso Cabrales", UnitPrice = 21, UnitsInStock = 22, Discontinued = false },
            new ProductViewModel { ProductID = 12, ProductName = "Queso Manchego La Pastora", UnitPrice = 38, UnitsInStock = 86, Discontinued = false },
        };

        public JsonResult Grid_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(products.ToDataSourceResult(request));
        }

        public virtual JsonResult Grid_Destroy([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                products.Remove(products.Where(x => x.ProductID == product.ProductID).FirstOrDefault());
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Grid_Create([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                product.ProductID = ++products.LastOrDefault().ProductID;
                products.Add(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Grid_Update([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productToUpdate = products.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
                if (productToUpdate != null)
                {
                    productToUpdate = product;
                }
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
    }
}
