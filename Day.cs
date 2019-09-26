using System;

namespace SimulatedAnnealingNSP
{
    public class Day
    {
        public enum DayNames
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        private String description;

        Day(String description)
        {
            this.description = description;
        }

        public override String ToString()
        {
            return description;
        }
    }
}