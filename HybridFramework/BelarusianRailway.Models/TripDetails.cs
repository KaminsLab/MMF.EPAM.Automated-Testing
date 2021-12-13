using System;

namespace BelarusianRailway.Models
{
    public class TripDetails
    {
        public TripDetails(string from, string to, DateTime departureDay)
        {
            From = from;
            To = to;
            DepartureDay = departureDay;
        }

        public string From { get; }
        
        public string To { get; }
        
        public DateTime DepartureDay { get; }
    }
}