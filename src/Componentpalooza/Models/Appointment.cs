using System;

namespace Componentpalooza.Models
{
    public class Appointment
    {
        public long Id { get; set; }
        
        public DateTime StartsAt { get; set; }
        
        public string Title { get; set; }
        
        public short FifteenMinuteMultiplier { get; set; } 
    }
}
