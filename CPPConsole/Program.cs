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

            CPPInstance In = new CPPInstance();

            //                        In.LoadMIP1("c:\\primeri\\CPP\\MIP\\CPP data\\CPn25-3.txt");

            //CPPProblem Pr = new CPPProblem("c:\\primeri\\CPP\\MIP\\CPP data\\CPn35-3.txt", "CPn35 - 3.txt");

            //               Pr.Solve(100, 100);
                 string filename = "mm_kar_mod1.dat";
            //     string filename = "mm_lesmis.dat";
         //   string filename = "mm_netscience.dat";

//            string filename = "mm_A00main.dat";

        //    In.LoadMIP_MM("c:\\primeri\\CPP\\MIP\\mm\\"+ filename);
//            In.LoadMIP_Convert("c:\\primeri\\CPP\\MIP\\Table2\\UNO54.txt");
//            In.LoadMIP_Convert("c:\\primeri\\CPP\\MIP\\Table2\\convert_mcc.txt");
            In.LoadMIP_GT("c:\\primeri\\CPP\\MIP\\GT\\les.txt");

            CPPProblem Pr = new CPPProblem("c:\\primeri\\CPP\\MIP\\Table2\\convert_mcc.txt", "convert_mcc.txt", In);

                        Pr.SetID(2);
                        Pr.AllocateSolution();
            //                tProblem.SASelect = SASelectType.Single;

                        Pr.SASelect = SASelectType.Dual;
            //Pr.Calibrate(1000);
            //                           Pr.SolveGRASP(10000, 10000);
            //                        Pr.Solve(10000, 1000);

            //            Pr.SolveGreedy();
            /*  */
            //                                      tExperiments.SolveAllParallelCompare(10, 0);
            //                        tExperiments.SolveAllParallelCompare(10, 10);


            //            for (int i=0; i< 4; i++)
            //                      tExperiments.SolveAllParallelCompare(5, i*4);
            //            tExperiments.SolveAllTable1();
                        tExperiments.SolveAllTableGT();

            //            tExperiments.SolveSingle();




            //         tExperiments.CreateCompareTable(20, ".\\Compare16\\", "16");
            //                      tExperiments.CreateCompareTable(10, ".\\ParallelCompare\\", "32" );
            //            tExperiments.CreateStatisticTable(10, ".\\ParallelCompare\\", "32");
            //      tExperiments.CreateTimeTable(10, ".\\ParallelCompare\\", "32");
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
