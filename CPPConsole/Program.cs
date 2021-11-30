using System;
using CPP;

namespace CPPConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CPPExperiments tExperiments = new CPPExperiments();

//            tExperiments.SolveSingleParallel();
            tExperiments.SolveSingle();

        }
    }
}
