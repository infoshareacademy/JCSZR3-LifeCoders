using BusFinderAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusFinderAppCore.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BusFinderAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[HttpPost]
        public IActionResult Index(string login, string pass)
        {
          /*  var user = new User();
            using (var db = new LoggedContext())
            {
                user = db.users.FirstOrDefault();


            }*/
          return View();

          // return View(new usersViewModel { Name = user.Login });

        }
        [HttpPost]
        public IActionResult Logged(string Name, string passwd)
        {
            var user = new User();
            using (var db = new LoggedContext())
            {
                user = db.users.Where(x => x.Login == Name).FirstOrDefault();
                if (user != null)
                {
                    if (user.password == passwd)
                        return View(new usersViewModel {Name = user.Login});
                    else
                    {
                        // return RedirectToAction("Index");
                        ModelState.AddModelError("Error", "Niepoprawne hasło");
                        return View("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Nie ma takiego użytkownika");
                    return View("Index");
                }
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}