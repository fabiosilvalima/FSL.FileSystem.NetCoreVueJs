using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FSL.FileSystem.Core.Models;

namespace FSL.FileSystem.Core.Controllers
{
    public sealed class HomeController :
        Controller
    {
        public IActionResult Index(
            string node = null)
        {
            return View();
        }

        public IActionResult Vue(
            string node = null)
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
