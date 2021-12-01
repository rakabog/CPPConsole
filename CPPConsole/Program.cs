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

            tExperiments.CreateTable( 10, ".\\Rez121\\");
//            tExperiments.SolveSingleParallel();
//            tExperiments.SolveAllParallel(10);
            //            tExperiments.SolveSingle();

        }
    }
}
