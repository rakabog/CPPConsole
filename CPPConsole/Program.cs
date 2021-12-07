using CPP;
using System;

namespace CPPConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CPPExperiments tExperiments = new CPPExperiments();
            tExperiments.SolveSingle();

                        tExperiments.CreateTable( 10, ".\\AllRezNew\\");
//            tExperiments.SolveSingleParallel(10);
//            tExperiments.SolveAllParallel(10);
            //            tExperiments.SolveSingle();

        }
    }
}
