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

				public IEnumerable<IGrouping<DateTime, Appointment>> Past
				{
						get
						{
								return _appointments
										.OrderByDescending(appt => appt.StartsAt.Date)
										.ThenBy(appt => appt.StartsAt.TimeOfDay)
										.Where(appt => appt.StartsAt <= DateTime.Now)
										.GroupBy(appt => appt.StartsAt.Date, appt => appt);
						}
				}

				public IEnumerable<IGrouping<DateTime, Appointment>> Future
				{
						get
						{
								return _appointments
										.OrderBy(appt => appt.StartsAt)
										.Where(appt => appt.StartsAt > DateTime.Now)
										.GroupBy(appt => appt.StartsAt.Date, appt => appt);
						}
				}

				public string FormatDate(DateTime dt)
				{
						return dt.ToString("d");
				}

				public string FormatTime(DateTime dt)
				{
						return dt.ToString("t");
				}

				public string FormatLength(int num)
				{
						switch(num)
						{
								case 1:
										return "15 mins";
								case 2:
										return "30 mins";
								case 3:
										return "45 mins";
								case 4:
										return "1 hour";
								case 5:
										return "1.25 hours";
								case 6:
										return "1.5 hours";
								case 7:
										return "1.75 hours";
								case 8:
										return "2 hours";
						}
						return "Forever!";
				}

				private readonly IEnumerable<Appointment> _appointments;
		}
}
