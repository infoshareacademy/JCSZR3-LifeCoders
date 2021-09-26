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
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace BusFinderAppWeb.Controllers
{
    public class ItineraryController : Controller
    {
        private readonly IHttpClientFactory clientFactory;
        public ItineraryController(IHttpClientFactory client)
        {
             clientFactory=client;
        }
        public IActionResult Index(string searchStationName, string sortColumn, string sortDirection = "")
        {

            HttpRequestMessage request =
                new HttpRequestMessage(HttpMethod.Get, "https://localhost:44363/api/Station/1");

            var client=clientFactory.CreateClient();
            var response=client.Send(request);
            if (response.IsSuccessStatusCode)
            {
               var result =response.Content.ReadFromJsonAsync<StationModelClient>();
            }

            var list = JSON.LoadJsonFiles<ScheduleForStation>("Data");

            if (!string.IsNullOrWhiteSpace(searchStationName))
            {
                list = list.Where(x => x.station.Name.Contains(searchStationName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            switch (sortColumn)
            {
                case "Name":
                    list = list.OrderBy(x => x.station.Name).ToList();
                    break;
                case "Address":
                    list = list.OrderBy(x => x.station.FullAddress).ToList();
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
