using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RLHerrera.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}