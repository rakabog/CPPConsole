using CPP;
using System;
using System.Numerics;
using System.Runtime.InteropServices;

using System.Diagnostics;
namespace CPPConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CPPExperiments tExperiments = new CPPExperiments();
            //                tExperiments.SolveSingle();



            //            tExperiments.CreateTable(10, ".\\NewResSlide_16_095\\");
            //         tExperiments.CreateTable(10, ".\\ResSlide_16_095\\");
                     tExperiments.CreateTable(10, ".\\ResSlide_New\\");

            //                        tExperiments.CreateTable( 10, ".\\AllRezNew\\");
//                                      tExperiments.SolveSingleParallel(10);
//            tExperiments.SolveAllParallel(10);
            //            tExperiments.SolveSingle();

        }
    }
}
