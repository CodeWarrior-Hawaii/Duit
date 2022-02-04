using Duit.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Duit.DAL;
using Duit.DAL.Entities;

namespace Duit.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DuitContext context) : base(context)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Context.SeedData();

            var toDoTasks = Context.Tasks.ToList();
            return View(toDoTasks);
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
    }
}