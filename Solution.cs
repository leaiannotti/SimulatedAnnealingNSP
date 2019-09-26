namespace SimulatedAnnealingNSP
{
    public class Solution
    {

        private Nurse nurse;

        private Day day;

        private Shift shift;

        private Alocation alocation;

        public Solution(Nurse nurse, Day day, Shift shift, Alocation alocation)
        {
            this.nurse = nurse;
            this.day = day;
            this.shift = shift;
            this.alocation = alocation;
        }

        public Nurse GetNurse()
        {
            return nurse;
        }

        public Day GetDay()
        {
            return day;
        }

        public Shift GetShift()
        {
            return shift;
        }

        public Alocation GetAlocation()
        {
            return alocation;
        }

        public void setShift(Shift turno)
        {
            this.shift = turno;
        }

        public override string ToString()
        {
            return "Day=" + day + ", shift=" + shift;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((day == null) ? 0 : day.GetHashCode());
            result = prime * result + ((nurse == null) ? 0 : nurse.GetHashCode());
            result = prime * result + ((shift == null) ? 0 : shift.GetHashCode());
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Solution other = (Solution)obj;
            if (day != other.day)
                return false;
            if (nurse == null)
            {
                if (other.nurse != null)
                    return false;
            }
            else if (!nurse.Equals(other.nurse))
                return false;
            if (shift != other.shift)
                return false;
            return true;
        }
    }
}