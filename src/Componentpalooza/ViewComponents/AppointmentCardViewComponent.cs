using Componentpalooza.Models;
using Componentpalooza.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Componentpalooza.ViewComponents
{
    public class AppointmentCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Appointment appointment)
        {
            var model = new AppointmentCardViewModel(appointment);
            return View(model);
        }
    }
}
