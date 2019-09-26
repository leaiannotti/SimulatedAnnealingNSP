using System;

namespace SimulatedAnnealingNSP
{
    public class Shift
    {
        public enum ShiftTypes
        {
           Morning,
           Afternoon,
           Night,
           DayOff
        } 

        private String description;

        Shift(String description)
        {
            this.description = description;
        }

        public override String ToString()
        {
            return description;
        }

    }
}