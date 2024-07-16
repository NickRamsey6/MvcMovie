using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    //
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        // Call the controller's View method
        return View();
        // Uses a view template to generate an HTML response
    }
    //
    // GET: /HelloWorld/Welcome/
    // Requires using System.Text.Encodings.Web;
    public string Welcome(string name, int ID = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
    }
}
