using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Componentpalooza.Models;

namespace Componentpalooza.ViewModels
{
    public class AppointmentDayCardViewModel : IEnumerable<Appointment>
    {
        public AppointmentDayCardViewModel(IGrouping<DateTime, Appointment> grouping)
        {
            _grouping = grouping;
        }
        
        public string Time
        {
            get { return _grouping.Key.ToString("d"); }
        }

        public IEnumerator<Appointment> GetEnumerator()
        {
            return ((IEnumerable<Appointment>)_grouping).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Appointment>)_grouping).GetEnumerator();
        }
        
        private readonly IGrouping<DateTime, Appointment> _grouping;
    }
}
