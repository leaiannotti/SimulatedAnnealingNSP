using System;
using System.Collections.Generic;

namespace SimulatedAnnealingNSP
{
    class SimulatedAnnealing
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.UtcNow;

            SimulatedAnnealing sa = new SimulatedAnnealing();
            ManagerConfig mConfig = new ManagerConfig();

            Instance instance = mConfig.getInstance("1.gen");
            Dictionary<Nurse,List<Preference>> prefers = mConfig.getPreferences();

            Dictionary<Nurse, List<Solution>> bestSolution = new Dictionary<Nurse, List<Solution>>();
            Int32 bestSolutionCost = 10000000;

            Console.WriteLine("======================================================");
            Console.WriteLine("Starting instance resolution: " + instance.getFileName());

            Dictionary<Nurse, List<Solution>> solution = instance.generateSolution();
            Int32 totalCost = ConstraintCalculation.calculate(instance, prefers, solution);

            bestSolution = solution;
            bestSolutionCost = totalCost;

            Console.WriteLine("Initial solution cost: " + totalCost);
            Console.WriteLine("======================================================");

            double initialTemperature = NSPConfig.getInitialTemperature();
            double minTemperature = NSPConfig.getMinimumTemperature();
            double coolingRate = NSPConfig.getCoolingRate();

            while (initialTemperature > minTemperature)
            {
                int iterations = NSPConfig.getIterations();
                while (iterations >= 1)
                {

                    Dictionary<Nurse, List<Solution>> newSolution = instance.generateSolution();
                    Int32 newSolutionTotalCost = ConstraintCalculation.calculate(instance, prefers, newSolution);
                    Random rd = new Random();

                    if (sa.acceptanceProbability(totalCost, newSolutionTotalCost, initialTemperature) > (rd.Next(1,10)/10))
                    {
                        totalCost = newSolutionTotalCost;
                        solution = newSolution;
                    }

                    if (totalCost < bestSolutionCost)
                    {
                        Console.WriteLine("Remove: " + (bestSolutionCost - totalCost) + " penaltys");
                        bestSolutionCost = totalCost;
                        bestSolution = solution;
                        initialTemperature = NSPConfig.getInitialTemperature();
                        iterations = NSPConfig.getIterations();
                    }
                    iterations--;
                }
                initialTemperature *= initialTemperature * coolingRate;
            }

            DateTime end = DateTime.UtcNow;
            Console.WriteLine("======================================================");
            Console.WriteLine("Total Penalties= " + bestSolutionCost);
            Console.WriteLine("Spended time in seconds:" + (end.Subtract(start)).Seconds);
            Console.WriteLine("======================================================");

            NSPUtil.printToConsole(bestSolution);
        }

        private double acceptanceProbability(Int32 currentCost, Int32 newSolutionCost, double temperature)
        {
            if (currentCost < newSolutionCost)
            {
                return 1;
            }

            return Math.Exp((currentCost - newSolutionCost) / temperature);
        }

    }
}
