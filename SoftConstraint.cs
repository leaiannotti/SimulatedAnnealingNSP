using System.Collections.Generic;

namespace SimulatedAnnealingNSP
{
    internal class SoftConstraint : Constraint
    {
        private object instancia;
        private Dictionary<Nurse, List<Preference>> prefers;
        private object solucao;

        public SoftConstraint(object instancia, Dictionary<Nurse, List<Preference>> prefers, object solucao)
        {
            this.instancia = instancia;
            this.prefers = prefers;
            this.solucao = solucao;
        }
    }
}