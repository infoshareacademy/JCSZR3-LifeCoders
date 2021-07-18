using BusFinderAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusFinderAppCore.ViewModels
{
    public class SchedulesViewModel
    {
        public List<ScheduleForStation> Schedules { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
    }
}
