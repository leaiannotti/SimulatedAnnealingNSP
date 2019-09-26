namespace SimulatedAnnealingNSP
{
    public class Alocation
    {
        public Nurse nurse;

        public TypeAlocation.Type typeAlocation;

        public Alocation(Nurse nurse, TypeAlocation.Type typeAlocation)
        {
            this.nurse = nurse;
            this.typeAlocation = typeAlocation;
        }

        public Nurse GetNurse()
        {
            return nurse;
        }

        public TypeAlocation.Type GetTypeAllocation()
        {
            return typeAlocation;
        }


        public override int GetHashCode()
        {
            const int prime = 37;
            int result = 1;
            result = prime * result + ((nurse == null) ? 0 : nurse.GetHashCode());
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (!GetType().Equals(obj.GetType()))
                return false;
            Alocation other = (Alocation)obj;
            if (nurse == null)
            {
                if (other.nurse != null)
                    return false;
            }
            else if (!nurse.Equals(other.nurse))
                return false;
            if (typeAlocation != other.typeAlocation)
                return false;
            return true;
        }

        public override string ToString()
        {
            return "Nurse = " + nurse + " Shift type = " + typeAlocation;
            
        }
    }
}