using System;
using System.Linq;
using Componentpalooza.Models;
using Componentpalooza.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Componentpalooza.ViewComponents
{
    public class AppointmentDayCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IGrouping<DateTime, Appointment> grouping)
        {
            return View(new AppointmentDayCardViewModel(grouping));
        }
    }
}
