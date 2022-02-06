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
//                                      tExperiments.SolveAllParallelCompare(10, 0);
            //                        tExperiments.SolveAllParallelCompare(10, 10);


//            for (int i=0; i< 4; i++)
//                      tExperiments.SolveAllParallelCompare(5, i*4);


            //                tExperiments.SolveSingle();



            //         tExperiments.CreateCompareTable(20, ".\\Compare16\\", "16");
  //                      tExperiments.CreateCompareTable(10, ".\\ParallelCompare\\", "32" );
//            tExperiments.CreateStatisticTable(10, ".\\ParallelCompare\\", "32");
              tExperiments.CreateTimeTable(10, ".\\ParallelCompare\\", "32");
            //                        tExperiments.CreateTable(10, ".\\NewResSlide_16_095\\");
            //                        tExperiments.CreateTable(20, ".\\RezSA8_95FSS_I10_S20_B_10_S50\\", "FSS_Single");

            //                                tExperiments.CreateTable(10, ".\\RezRADFSS_I10_S20_B_50_S50\\", "FSS_Single");
            //         tExperiments.CreateTable(10, ".\\ResSlide_16_095\\");
            //                     tExperiments.CreateTable(10, ".\\ResSlide_New\\");

            //                                    tExperiments.CreateTable( 10, ".\\AllRezNew\\");
            //                                                  tExperiments.SolveSingleParallel(10);

            //                      tExperiments.CreateTable(10, ".\\GraspSingle\\", "GRASP_Single");
            //                                    tExperiments.CreateTable(10, ".\\T\\", "FSS_Single");
            //   tExperiments.CreateTable(10, ".\\FinalRezRADFSS_I10_S20_B_10_S50\\", "FSS_Dual_");
            //                                    tExperiments.CreateTable(10, ".\\T\\", "FSS_Dual");

            //            tExperiments.SolveAllParallel(10,CPPProblem.CPPMetaheuristic.FSS, SASelectType.Dual, 0);
            //                                        tExperiments.SolveAllParallel(5, CPPProblem.CPPMetaheuristic.FSS, SASelectType.Single, 10);
            //                        tExperiments.SolveSingle();

        }
    }
}
