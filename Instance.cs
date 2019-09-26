using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulatedAnnealingNSP
{
    public class Instance
    {
        private String fileName;

        private Problem problem;
        private WorkedSequence workedSequence;
        private AttributionSequence attributionSequence;
        private MannagerConfig mConfig;
        private MorningShift morningShift;
        private AfternoonShift afternoonShift;
        private NightShift nightShift;
        private DayOff dayOff;

        public Instance(FileGenLayout layout, MannagerConfig mConfig)
        {
            this.mConfig = mConfig;
            this.fileName = layout.getFileName();
            this.problem = layout.getProblem();
            this.workedSequence = layout.getWorkedSequence();
            this.attributionSequence = layout.getAttributionSequence();
            this.morningShift = layout.getMorningShift();
            this.afternoonShift = layout.getAfternoonShift();
            this.nightShift = layout.getNightShift();
            this.dayOff = layout.getDayOff();
        }

        public Dictionary<Nurse, List<Solution>> generateSolution()
        {
            Dictionary<Day, Dictionary<Shift, List<Alocation>>> workDays = designateWorkDays();
            Dictionary<Nurse, List<Solution>> solution = buildWorkSchedule(workDays);
            return solution;
        }

        private Dictionary<Nurse, List<Solution>> buildWorkSchedule(Dictionary<Day, Dictionary<Shift, List<Alocation>>> workDays)
        {
            Dictionary<Shift, List<Alocation>> workSchedulePerDay;
            List<Alocation> allocationsPerShift;
            List<Solution> solutions = new List<Solution>();
            Alocation alocationPerNurse = null;
            foreach (Nurse nurse in mConfig.getNurses())
            {
                foreach (Day day in workDays.Keys)
                {
                    workSchedulePerDay = workDays[day];
                    foreach (Shift shift in workSchedulePerDay.Keys)
                    {
                        allocationsPerShift = workSchedulePerDay[shift];

                        alocationPerNurse = allocationsPerShift.Where(a => a.GetNurse().Equals(nurse)).FirstOrDefault();

                        if (allocationsPerShift != null)
                        {
                            solutions.Add(new Solution(nurse, day, shift, alocationPerNurse));
                        }
                    }
                }
            }

            solutions.GroupBy(s => s.GetNurse());
        }

        private Dictionary<Day, Dictionary<Shift, List<Alocation>>> designateWorkDays()
        {
            Dictionary<Day, Dictionary<Shift, List<Alocation>>> mDays = new Dictionary<Day, Dictionary<Shift, List<Alocation>>>();

            Array shifts = Enum.GetValues(typeof(Shift.ShiftTypes));
            Array days = Enum.GetValues(typeof(Day.DayNames));

            foreach (Day day in days)
            {
                Dictionary<Shift, List<Alocation>> shiftPerDay = assignShiftPerDay(day,shifts);
                mDays.Add(day, shiftPerDay);
            }
            return mDays;
        }

        //private Dictionary<Shift, List<Alocation>> assignShiftPerDay(Day day, List<Shift> shifts)
        //{
        //    Dictionary<Shift, List<Alocation>> map = new Dictionary<Shift, List<Alocation>>();
        //    List<Nurse> nurses = new List<Nurse>(mConfig.GetNurses());

        //    int qtyExtraShifts = calculateQtyOfExtraShifts(day);
        //    int qtyDemands = mConfig.getSumQtyDemands(day);
        //    bool isExtraShift = false;
        //    while (nurses.Count > qtyDemands && (qtyExtraShifts > 0 || map.Count == 0))
        //    {
        //        TypeAlocation.Type type = isExtraShift ? TypeAlocation.Type.Extra : TypeAlocation.Type.Demand;

        //        foreach (Shift shift in shifts)
        //        {
        //            List<Nurse> selectedNurses = selectNursesByDemand(day, nurses, shift);
        //            nurses.Except(selectedNurses).ToList();
        //            List<Alocation> listAlocations = map[shift];
        //            if (listAlocations == null)
        //            {
        //                listAlocations = new List<Alocation>();
        //            }
        //            List<Alocation> selectedAlocations = selectedNurses.Select(m => new Alocation(m, type)).ToList();

        //            listAlocations.AddRange(selectedAlocations);
        //            map.Add(shift, listAlocations);
        //        }


        //        qtyExtraShifts--;
        //        isExtraShift = true;
        //    }

        //    List<Alocation> alocations = nurses.Select(enf => new Alocation(enf, TypeAlocation.Type.Extra)).ToList()collect(toList());
        //    map.put(Shift.F, alocations);

        //    return map;
        //}

        ///**
        // * Seleciona enfermeiros de forma aleatória de acordo com a demanda do dia.
        // * 
        // * @param dia
        // * @param enfermeiros
        // * @param turno
        // * @return
        // */
        //private List<Nurse> selecionarEnfermeirosPorDemanda(Day dia, List<Nurse> enfermeiros, Shift turno)
        //{
        //    Collections.shuffle(enfermeiros);
        //    return enfermeiros.parallelStream()
        //            .limit(mConfig.getQtdDemandaPorTurno(dia, turno))
        //            .collect(toList());
        //}

        ///**
        // * Calcula quantos turnos extras serão gerados. 
        // * 
        // * @param dia
        // * @return
        // */
        //private int calcularQtdTurnosExtras(Day dia)
        //{
        //    int qtdTotalDemandaDia = mConfig.sumQtdDemanda(dia);
        //    int qtdEnfermeiros = Config.getQtdEnfermeiros();
        //    return (qtdEnfermeiros / qtdTotalDemandaDia) - 1;
        //}

        //public String getFileName()
        //{
        //    return fileName;
        //}

        //public WorkedSequence getWorkedSequence()
        //{
        //    return workedSequence;
        //}

        //public Problem getProblem()
        //{
        //    return problem;
        //}

        //public AttributionSequence getAttributionSequence()
        //{
        //    return attributionSequence;
        //}

        //public MorningShift getMorningShift()
        //{
        //    return morningShift;
        //}

        //public AfternoonShift getAfternoonShift()
        //{
        //    return afternoonShift;
        //}

        //public NightShift getNightShift()
        //{
        //    return nightShift;
        //}

        //public DayOff getDayOff()
        //{
        //    return dayOff;
        //}

    }
}