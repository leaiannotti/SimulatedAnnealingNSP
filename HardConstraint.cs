using System.Collections.Generic;

namespace SimulatedAnnealingNSP
{
    internal class HardConstraint : Constraint
    {
        private Map<Nurse, System.Collections.Generic.List<Solluction>> solucao;
        private Instancy instancia;
        private Dictionary<Nurse, List<Solution>> solution;
        private Instance instance;

        public HardConstraint(Map<Nurse, System.Collections.Generic.List<Solluction>> solucao, Instancy instancia)
        {
            this.solucao = solucao;
            this.instancia = instancia;
        }

        public HardConstraint(Dictionary<Nurse, List<Solution>> solution, Instance instance)
        {
            this.solution = solution;
            this.instance = instance;
        }
    }
}