using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace CPP
{

    class TestInstance
    {

        public string mFileName;
        public string mFolder;
        public int    mCalcTime;


        public TestInstance(int iCalcTime, string iFileName, string iFolder) {
            mCalcTime = iCalcTime;
            mFileName = iFileName;
            mFolder = iFolder;   
        }

    }
    class CPPExperiments
    {
        List<TestInstance> mInstances;

        void InitInstances() {

            string SmallFolder = "c:\\primeri\\CPP\\small\\";
            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";


            mInstances = new List<TestInstance>();

            /*
            mInstances.Add(new TestInstance(200, "rand100-100.txt", SmallFolder));
            mInstances.Add(new TestInstance(200, "rand100-5.txt", SmallFolder));
            mInstances.Add(new TestInstance(200, "rand200-100.txt", SmallFolder));
            mInstances.Add(new TestInstance(200, "rand200-5.txt", SmallFolder));
            mInstances.Add(new TestInstance(200, "rand300-100.txt", SmallFolder));
            mInstances.Add(new TestInstance(200, "rand300-5.txt", SmallFolder));
            mInstances.Add(new TestInstance(200, "sym300-50.txt", SmallFolder));
            mInstances.Add(new TestInstance(200, "regnier300-50.txt", SmallFolder));
            mInstances.Add(new TestInstance(200, "zahn300.txt", SmallFolder));


            mInstances.Add(new TestInstance(500, "rand400-100.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "rand400-5.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "rand500-100.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "rand500-5.txt", SmallFolder));
            

            mInstances.Add(new TestInstance(500, "p500-5-1.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-5-2.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-5-3.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-5-4.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-5-5.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-5-6.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-5-7.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-5-8.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-5-9.txt", SmallFolder));



            mInstances.Add(new TestInstance(500, "p500-100-1.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-2.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-3.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-4.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-5.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-6.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-7.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-8.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-9.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "p500-100-10.txt", SmallFolder));



            mInstances.Add(new TestInstance(500, "gauss500-100-1.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "gauss500-100-2.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "gauss500-100-3.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "gauss500-100-4.txt", SmallFolder));
            mInstances.Add(new TestInstance(500, "gauss500-100-5.txt", SmallFolder));
            */


            mInstances.Add(new TestInstance(1000, "unif700-100-1.txt", MediumFolder));
            mInstances.Add(new TestInstance(1000, "unif700-100-2.txt", MediumFolder));
            mInstances.Add(new TestInstance(1000, "unif700-100-3.txt", MediumFolder));
            mInstances.Add(new TestInstance(1000, "unif700-100-4.txt", MediumFolder));
            mInstances.Add(new TestInstance(1000, "unif700-100-5.txt", MediumFolder));

            mInstances.Add(new TestInstance(1000, "unif800-100-1.txt", MediumFolder));
            mInstances.Add(new TestInstance(1000, "unif800-100-2.txt", MediumFolder));
            mInstances.Add(new TestInstance(1000, "unif800-100-3.txt", MediumFolder));
            mInstances.Add(new TestInstance(1000, "unif800-100-4.txt", MediumFolder));
            mInstances.Add(new TestInstance(1000, "unif800-100-5.txt", MediumFolder));


            mInstances.Add(new TestInstance(2000, "p1000-1.txt", MediumFolder));
            mInstances.Add(new TestInstance(2000, "p1000-2.txt", MediumFolder));
            mInstances.Add(new TestInstance(2000, "p1000-3.txt", MediumFolder));
            mInstances.Add(new TestInstance(2000, "p1000-4.txt", MediumFolder));
            mInstances.Add(new TestInstance(2000, "p1000-5.txt", MediumFolder));

            mInstances.Add(new TestInstance(4000, "p1500-1.txt", MediumFolder));
            mInstances.Add(new TestInstance(4000, "p1500-2.txt", MediumFolder));
            mInstances.Add(new TestInstance(4000, "p1500-3.txt", MediumFolder));
            mInstances.Add(new TestInstance(4000, "p1500-4.txt", MediumFolder));
            mInstances.Add(new TestInstance(4000, "p1500-5.txt", MediumFolder));


            mInstances.Add(new TestInstance(10000, "p2000-1.txt", MediumFolder));
            mInstances.Add(new TestInstance(10000, "p2000-2.txt", MediumFolder));
            mInstances.Add(new TestInstance(10000, "p2000-3.txt", MediumFolder));
            mInstances.Add(new TestInstance(10000, "p2000-4.txt", MediumFolder));
            mInstances.Add(new TestInstance(10000, "p2000-5.txt", MediumFolder));



            mInstances.Add(new TestInstance(10000, "new_b2500.1.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.2.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.3.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.4.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.5.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.6.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.7.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.8.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.9.txt", LargeFolder));
            mInstances.Add(new TestInstance(10000, "new_b2500.10.txt", LargeFolder));


            mInstances.Add(new TestInstance(20000, "new_p3000.1.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p3000.2.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p3000.3.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p3000.4.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p3000.5.txt", LargeFolder));


            mInstances.Add(new TestInstance(20000, "new_p4000.1.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p4000.2.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p4000.3.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p4000.4.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p4000.5.txt", LargeFolder));

            mInstances.Add(new TestInstance(20000, "new_p5000.1.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p5000.2.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p5000.3.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p5000.4.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p5000.5.txt", LargeFolder));


            mInstances.Add(new TestInstance(20000, "new_p6000.1.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p6000.2.txt", LargeFolder));
            mInstances.Add(new TestInstance(20000, "new_p6000.3.txt", LargeFolder));

            mInstances.Add(new TestInstance(20000, "new_p6000.1.txt", LargeFolder));

        }

        public void SolveSingle() {


            string SmallFolder = "c:\\primeri\\CPP\\small\\";
            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";

            CPPProblem tProblem;
            InitInstances();

            mInstances.Clear();

//                        mInstances.Add(new TestInstance(2000, "p1000-1.txt", MediumFolder));
//                        mInstances.Add(new TestInstance(10000, "rand100-100.txt", SmallFolder));

//            mInstances.Add(new TestInstance(4000, "p1500-5.txt", MediumFolder));
            mInstances.Add(new TestInstance(4000, "new_b2500.5.txt", LargeFolder));


            foreach (TestInstance t in mInstances)
            {

                tProblem = new CPPProblem(t.mFolder + t.mFileName, t.mFileName);
                tProblem.SetID(2);
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(t.mCalcTime);
//                tProblem.SolveGRASP(10000, t.mCalcTime);
                tProblem.SolveFixSetSearch(t.mCalcTime, 100000);
            }


        }

        public void SolveSingleParallel()
        {


            string SmallFolder = "c:\\primeri\\CPP\\small\\";
            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";

            CPPProblem tProblem;
            InitInstances();
            int tNumParallel = 2;
            List<CPPProblem> tProblems = new List<CPPProblem>();
            mInstances.Clear();

                                    mInstances.Add(new TestInstance(10000, "rand100-100.txt", SmallFolder));

            //            mInstances.Add(new TestInstance(4000, "p1500-5.txt", MediumFolder));
//            mInstances.Add(new TestInstance(4000, "new_b2500.5.txt", LargeFolder));

            /**/
            for (int i = 0; i < tNumParallel; i++) { 
                
    
                tProblem = new CPPProblem(mInstances[0].mFolder + mInstances[0].mFileName, mInstances[0].mFileName);
                tProblem.SetID(i);
                tProblem.AllocateSolution();
                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(mInstances[0].mCalcTime);
                tProblems.Add(tProblem);

            }
            
            int c;

            StreamWriter A = new StreamWriter("t1.txt");
            StreamWriter B = new StreamWriter("t2.txt");



            Parallel.ForEach(tProblems, Prob =>
            {
                for (int i = 0; i < 100; i++)
                {

                    if (Prob.ID == 0) {
                        A.WriteLine("Thread :" + Thread.CurrentThread.ManagedThreadId);
                    }

                    if (Prob.ID == 0)
                    {
                        B.WriteLine("Thread :" + Thread.CurrentThread.ManagedThreadId);
                    }
                }
            }





            );


            A.Close();
            B.Close();


/*
                ); ; ; ; ;

            foreach (TestInstance t in mInstances)
            {

                tProblem = new CPPProblem(t.mFolder + t.mFileName, t.mFileName);
                tProblem.SetID(2);
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(t.mCalcTime);
                //                tProblem.SolveGRASP(10000, t.mCalcTime);
                tProblem.SolveFixSetSearch(t.mCalcTime, 100000);
            }
*/

        }


        public void SolveAll() {

            CPPProblem tProblem;
            StreamWriter S = new StreamWriter("ResAll.txt");

            InitInstances();

            foreach (TestInstance t in mInstances) {

                tProblem = new CPPProblem(t.mFolder + t.mFileName, t.mFileName);
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(6);
                tProblem.SolveFixSetSearch(t.mCalcTime, 100000);

                S = new StreamWriter("ResAll.txt", true);
                S.WriteLine(t.mFileName + " " + tProblem.BestSolution);
                S.Close();
            }
            
        }

        void LoadResults(string Filename) {

            string[] Lines = File.ReadAllLines(Filename);
            char[] sep = { ' ' };
            string[] words;

            words = Lines[Lines.Length - 1].Split(sep);
            


        }

        public void CreateTable()
        {

            CPPProblem tProblem;
            

            InitInstances();

            foreach (TestInstance t in mInstances)
            {

                tProblem = new CPPProblem(t.mFolder + t.mFileName, t.mFileName);
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(t.mCalcTime);
                tProblem.SolveFixSetSearch(t.mCalcTime, 100000);
            }

        }

    }
}

