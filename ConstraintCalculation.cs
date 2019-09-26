using System;
using System.Collections.Generic;

namespace SimulatedAnnealingNSP
{
    public class ConstraintCalculation
    {   
        public static decimal calculate(Instance instance,  Dictionary<Nurse,List<Preference>> prefers, Dictionary<Nurse, List<Solution>> solution)
        {

            decimal softConstraintCost = calculateSoftConstraint(instance, prefers, solution);
            decimal hardConstraintCost = calculateHardConstraint(instance, solution);
            decimal totalCost = softConstraintCost + hardConstraintCost;

            return totalCost;
        }

        public static Decimal calculateSoftConstraint(Instance instance, Dictionary<Nurse,List<Preference>> prefers, Dictionary<Nurse, List<Solution>> solution)
        {
            Constraint constraint = new SoftConstraint(instance, prefers, solution);
            return constraint.calcular();
        }

        public static Decimal calculateHardConstraint(Instance instance, Dictionary<Nurse, List<Solution>> solution)
        {
            Constraint constraint = new HardConstraint(solution, instance);
            return constraint.calcular();
        }
    }
}