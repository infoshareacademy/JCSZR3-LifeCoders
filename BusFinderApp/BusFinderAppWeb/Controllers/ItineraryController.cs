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
    public class ItineraryController : Controller
    {
        public IActionResult Index(string sortColumn, string sortDirection = "")
        {
            var list = JSON.LoadJsonFiles<ScheduleForStation>("Data");
         
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
