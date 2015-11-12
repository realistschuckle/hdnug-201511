using Componentpalooza.Models;

namespace Componentpalooza.ViewModels
{
    public class AppointmentCardViewModel
	{
		public AppointmentCardViewModel(Appointment appointment)
		{
			_appointment = appointment;
		}
		
		public long Id
		{
			get { return _appointment.Id; }
		}
		
		public string Title
		{
			get { return _appointment.Title; }
		}
		
		public string StartsAt
		{
			get { return _appointment.StartsAt.ToString("t"); }
		}
		
		public string Length
		{
			get
			{
				switch(_appointment.FifteenMinuteMultiplier)
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
		}
		
		private readonly Appointment _appointment;
	}
}
