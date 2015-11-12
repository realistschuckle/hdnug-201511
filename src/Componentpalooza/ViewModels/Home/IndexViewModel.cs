using System;
using System.Collections.Generic;
using System.Linq;
using Componentpalooza.Models;

namespace Componentpalooza.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel(IEnumerable<Appointment> appointments)
        {
						_appointments = appointments;
        }

				public IEnumerable<Appointment> Past
				{
						get
						{
								return _appointments
										.OrderByDescending(appt => appt.StartsAt)
										.Where(appt => appt.StartsAt <= DateTime.Now);
						}
				}

				public IEnumerable<Appointment> Future
				{
						get
						{
								return _appointments
										.OrderBy(appt => appt.StartsAt)
										.Where(appt => appt.StartsAt > DateTime.Now);
						}
				}

				private readonly IEnumerable<Appointment> _appointments;
		}
}
