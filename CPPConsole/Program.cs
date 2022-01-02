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
            //                        tExperiments.SolveAllParallelCompare(10, 0);
            //                        tExperiments.SolveAllParallelCompare(10, 10);
            //          tExperiments.SolveAllParallelCompare(10, 10);


            //                tExperiments.SolveSingle();



            //         tExperiments.CreateCompareTable(20, ".\\Compare16\\", "16");
            //            tExperiments.CreateCompareTable(10, ".\\Compare32\\", "32" );
            //                        tExperiments.CreateTable(10, ".\\NewResSlide_16_095\\");
            //                        tExperiments.CreateTable(20, ".\\RezSA8_95FSS_I10_S20_B_10_S50\\", "FSS_Single");

//                                    tExperiments.CreateTable(10, ".\\4\\", "FSS_Dual");
            //         tExperiments.CreateTable(10, ".\\ResSlide_16_095\\");
            //                     tExperiments.CreateTable(10, ".\\ResSlide_New\\");

            //                        tExperiments.CreateTable( 10, ".\\AllRezNew\\");
//                                                  tExperiments.SolveSingleParallel(10);
            tExperiments.SolveAllParallel(10,CPPProblem.CPPMetaheuristic.FSS, SASelectType.Dual, 0);
//                        tExperiments.SolveAllParallel(10, CPPProblem.CPPMetaheuristic.FSS, SASelectType.Single, 10);
//                        tExperiments.SolveSingle();

        }
    }
}
