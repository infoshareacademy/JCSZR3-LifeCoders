using BusFinderAppCore.Control;
using BusFinderAppCore.Models;
using BusFinderAppCore.ViewModels;
using BusFinderAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusFinderAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string sortColumn, string sortDirection = "")
        {
            //var list = new List<ScheduleForStation>();
            var list=JSON.LoadJsonFiles<ScheduleForStation>("Data");
         
           // list.Add(new ScheduleForStation() { station = new Station { address = "test 1", Name = "test name" } });
           // list.Add(new ScheduleForStation() { station = new Station { address = "test 2", Name = "test name 2" } });
            switch (sortColumn)
            {
                case "Name":
                    list = list.OrderBy(x => x.station.Name).ToList();
                    break;
                case "Address":
                    list = list.OrderBy(x => x.station.full_address).ToList();
                    break;
                case "Message":
                    list = list.OrderBy(x => x.schedule.message).ToList();
                    break;
                case "Time":
                    list = list.OrderBy(x => x.schedule.Datetime).ToList();
                    break;
                default:
                    list = list.OrderByDescending(x => x.station.Name).ToList();
                    break;
            }



            var model = new SchedulesViewModel {Schedules = list, SortColumn = sortColumn, SortDirection = sortDirection};

            return View(model);
            
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
