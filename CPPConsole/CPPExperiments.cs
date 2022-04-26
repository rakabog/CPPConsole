using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


using System;



using Extreme.Mathematics;
using Extreme.Statistics;
using Extreme.Statistics.Tests;

namespace CPP
{

    class TestInstance
    {

        public string mFileName;
        public string mFolder;
        public int mCalcTime;
        


        public TestInstance(int iCalcTime, string iFileName, string iFolder)
        {
            mCalcTime = iCalcTime;
            mFileName = iFileName;
            mFolder = iFolder;
        }

    }
    class CPPExperiments
    {
        List<TestInstance>          mInstances;
        List<ResultsInstance>       mMDMCP;
        List<ResultsInstance>       mTable1;
        List<ResultsInstance>       mTable2;
        List<ResultsInstance>       mTableGT;
        List<ResultsInstance>       mTableMM;

        List<TestInstance>          mInstancesTable1;

        public void InitInstancesTable2Res() {

            ResultsInstance cResult;

            mTable2 = new List<ResultsInstance>();

            cResult = new ResultsInstance();
            
            cResult.InstanceName = "wild cats & 30 &";
            cResult.BestObjective = 1304;
            cResult.AverageTime = 0;
            mTable2.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "cars & 33 &";
            cResult.BestObjective = 1501;
            cResult.AverageTime =0;
            mTable2.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "workers & 34 &";
            cResult.BestObjective = 964;
            cResult.AverageTime = 0;
            mTable2.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "UNO & 54 &";
            cResult.BestObjective = 778;
            cResult.AverageTime = 0;
            mTable2.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "UNO1a & 158 &";
            cResult.BestObjective = 12197;
            cResult.AverageTime = 0.48;
            mTable2.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "UNO2a & 158 &";
            cResult.BestObjective = 72820;
            cResult.AverageTime = 0.47;
            mTable2.Add(cResult);



        }

        public void InitInstancesTableGTRes()
        {

            ResultsInstance cResult;

            mTableGT = new List<ResultsInstance>();




            cResult = new ResultsInstance();

            cResult.InstanceName = "kumar & 24 &";
            cResult.BestObjective = 23;
            cResult.AverageTime = 0;
            mTableGT.Add(cResult);



            cResult = new ResultsInstance(); 
            cResult.InstanceName = "bur & 59 &";
            cResult.BestObjective = 67;
            cResult.AverageTime = 14;
            mTableGT.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "groover & 43 &";
            cResult.BestObjective = 55;
            cResult.AverageTime = 48;
            mTableGT.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "leskowsky & 38 &";
            cResult.BestObjective = 30;
            cResult.AverageTime = 1;
            mTableGT.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "mccormick & 39 &";
            cResult.BestObjective = 43;
            cResult.AverageTime = 1;
            mTableGT.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "seifoddini & 33 &";
            cResult.BestObjective = 54 ;
            cResult.AverageTime = 0;
            mTableGT.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "sule & 31 &";
            cResult.BestObjective = 46;
            cResult.AverageTime = 0;
            mTableGT.Add(cResult);



        }


        public void InitInstancesTable1Res()
        {

            ResultsInstance cResult;

            mTable1 = new List<ResultsInstance>();
            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn25-1.txt & 25 &";
            cResult.BestObjective = 4636;
            cResult.AverageTime = 8;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn25-2.txt & 25 &";
            cResult.BestObjective = 4023;
            cResult.AverageTime = 3;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn25-3.txt & 25 &";
            cResult.BestObjective = 5043;
            cResult.AverageTime = 10;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn25-4.txt & 25 &";
            cResult.BestObjective = 4564;
            cResult.AverageTime = 10;
            mTable1.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn35-1.txt & 35 &";
            cResult.BestObjective = 7837;
            cResult.AverageTime = 496;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn35-2.txt & 35 &";
            cResult.BestObjective = 7215;
            cResult.AverageTime = 403;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn35-3.txt & 35 &";
            cResult.BestObjective = 7633;
            cResult.AverageTime = 95;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn35-4.txt & 35 &";
            cResult.BestObjective = 7652;
            cResult.AverageTime = 292;
            mTable1.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn45-1.txt & 45 &";
            cResult.BestObjective = 11545;
            cResult.AverageTime = 1305;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn45-2.txt& 45 &";
            cResult.BestObjective = 12137;
            cResult.AverageTime = 2492;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn45-3.txt& 45 &";
            cResult.BestObjective = 11800;
            cResult.AverageTime = 7595;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn45-4.txt & 45 &";
            cResult.BestObjective = 10506;
            cResult.AverageTime = 4280;
            mTable1.Add(cResult);



            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn50-1.txt & 50 &";
            cResult.BestObjective = 13543;
            cResult.AverageTime = 46616;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn50-2.txt  & 50 &";
            cResult.BestObjective = 14080;
            cResult.AverageTime = 18831;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn50-3.txt  & 50 &";
            cResult.BestObjective = 13034;
            cResult.AverageTime = 50630;
            mTable1.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "CPn50-4.txt  & 50 &";
            cResult.BestObjective = 13728;
            cResult.AverageTime = 69040;
            mTable1.Add(cResult);





        }



        void InitMDMCPResults() {

            ResultsInstance cResult;

            mMDMCP = new List<ResultsInstance>();


            cResult = new ResultsInstance();




            cResult = new ResultsInstance();
            cResult.InstanceName = "rand100-5.txt";
            cResult.BestObjective = 1407;
            cResult.AverageObjective = 1407;
            cResult.AverageTime = 0.70;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "rand100-100.txt";
            cResult.BestObjective = 24296;
            cResult.AverageObjective = 24296;
            cResult.AverageTime = 1.82;
            cResult.Hits = 20;
            cResult.OutOf = 20;

            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "rand200-5.txt";
            cResult.BestObjective = 4079;
            cResult.AverageObjective = 4079;
            cResult.AverageTime = 26.14;
            cResult.Hits = 20;
            cResult.OutOf = 20;

            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "rand200-100.txt";
            cResult.BestObjective = 74924;
            cResult.AverageObjective = 74924;
            cResult.AverageTime = 56.62;
            cResult.Hits = 20;
            cResult.OutOf = 20;

            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "rand300-5.txt";
            cResult.BestObjective = 7732;
            cResult.AverageObjective = 7732;
            cResult.AverageTime = 201.68;
            cResult.Hits = 20;
            cResult.OutOf = 20;

            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "rand300-100.txt";
            cResult.BestObjective = 152709;
            cResult.AverageObjective = 152709;
            cResult.AverageTime = 2.54;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "sym300-50.txt";
            cResult.BestObjective = 17592;
            cResult.AverageObjective = 17592;
            cResult.AverageTime = 100.54;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "regnier300-50.txt";
            cResult.BestObjective = 32164;
            cResult.AverageObjective = 32164;
            cResult.AverageTime = 2.21;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "zahn300.txt";
            cResult.BestObjective = 2504;
            cResult.AverageObjective = 2504;
            cResult.AverageTime = 7.68;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "rand400-5.txt";
            cResult.BestObjective = 12133;
            cResult.AverageObjective = 12133;
            cResult.AverageTime = 142.52;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();



            cResult.InstanceName = "rand400-100.txt";
            cResult.BestObjective = 222757;
            cResult.AverageObjective = 222757;
            cResult.AverageTime = 88.53;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "rand500-5.txt";
            cResult.BestObjective = 17127;
            cResult.AverageObjective = 17125.45;
            cResult.AverageTime = 451.24;
            cResult.Hits = 14;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();



            cResult.InstanceName = "rand500-100.txt";
            cResult.BestObjective = 309125;
            cResult.AverageObjective = 308901.80;
            cResult.AverageTime = 953.10;
            cResult.Hits = 2;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "p500-5-1.txt";
            cResult.BestObjective = 17691;
            cResult.AverageObjective = 17691.00;
            cResult.AverageTime = 188.76;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-2.txt";
            cResult.BestObjective = 17169;
            cResult.AverageObjective = 17167.65;
            cResult.AverageTime = 476.10;
            cResult.Hits = 11;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-3.txt";
            cResult.BestObjective = 16816;
            cResult.AverageObjective = 16815.35;
            cResult.AverageTime = 447.93;
            cResult.Hits = 9;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-4.txt";
            cResult.BestObjective = 16808;
            cResult.AverageObjective = 16808;
            cResult.AverageTime = 192.45;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-5.txt";
            cResult.BestObjective = 16957;
            cResult.AverageObjective = 16957;
            cResult.AverageTime = 161.17;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-6.txt";
            cResult.BestObjective = 16615;
            cResult.AverageObjective = 16614.75;
            cResult.AverageTime = 289.60;
            cResult.Hits = 19;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-7.txt";
            cResult.BestObjective = 16649;
            cResult.AverageObjective = 16648.55;
            cResult.AverageTime = 447.10;
            cResult.Hits = 16;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-8.txt";
            cResult.BestObjective = 16756;
            cResult.AverageObjective = 16755.55;
            cResult.AverageTime = 326.41;
            cResult.Hits = 17;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-9.txt";
            cResult.BestObjective = 16629;
            cResult.AverageObjective = 16628.60;
            cResult.AverageTime = 322.48;
            cResult.Hits = 19;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-5-10.txt";
            cResult.BestObjective = 17360;
            cResult.AverageObjective = 17360;
            cResult.AverageTime = 25.75;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();




            cResult.InstanceName = "p500-100-1.txt";
            cResult.BestObjective = 308896;
            cResult.AverageObjective = 308892.40;
            cResult.AverageTime = 420.82;
            cResult.Hits = 12;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-2.txt";
            cResult.BestObjective = 310241;
            cResult.AverageObjective = 310174.70;
            cResult.AverageTime = 724.81;
            cResult.Hits = 3;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-3.txt";
            cResult.BestObjective = 310477;
            cResult.AverageObjective = 310465.20;
            cResult.AverageTime = 550.08;
            cResult.Hits = 16;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-4.txt";
            cResult.BestObjective = 309567;
            cResult.AverageObjective = 309555.50;
            cResult.AverageTime = 509.23;
            cResult.Hits = 16;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-5.txt";
            cResult.BestObjective = 309135;
            cResult.AverageObjective = 309135.00;
            cResult.AverageTime = 196.45;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-6.txt";
            cResult.BestObjective = 310280;
            cResult.AverageObjective = 310280;
            cResult.AverageTime = 83.06;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-7.txt";
            cResult.BestObjective = 310063;
            cResult.AverageObjective = 310057.20;
            cResult.AverageTime = 403.36;
            cResult.Hits = 18;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-8.txt";
            cResult.BestObjective = 303148;
            cResult.AverageObjective = 303148;
            cResult.AverageTime = 301.58;
            cResult.Hits = 20;
            cResult.OutOf = 20;

            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "p500-100-9.txt";
            cResult.BestObjective = 305305;
            cResult.AverageObjective = 305305;
            cResult.AverageTime = 35.52;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-10.txt";
            cResult.BestObjective = 314864;
            cResult.AverageObjective = 314864;
            cResult.AverageTime = 78.04;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();






            cResult.InstanceName = "gauss500-100-1.txt";
            cResult.BestObjective = 265070;
            cResult.AverageObjective = 265049.80;
            cResult.AverageTime = 429.43;
            cResult.Hits = 18;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "gauss500-100-2.txt";
            cResult.BestObjective = 269076;
            cResult.AverageObjective = 269076;
            cResult.AverageTime = 320.45;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "gauss500-100-3.txt";
            cResult.BestObjective = 257700;
            cResult.AverageObjective = 257590.25;
            cResult.AverageTime = 504.67;
            cResult.Hits = 12;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "gauss500-100-4.txt";
            cResult.BestObjective = 267683;
            cResult.AverageObjective = 267683;
            cResult.AverageTime = 114.68;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "gauss500-100-5.txt";
            cResult.BestObjective = 271567;
            cResult.AverageObjective = 271567;
            cResult.AverageTime = 38.68;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();



            cResult.InstanceName = "unif700-100-1.txt";
            cResult.BestObjective = 515016;
            cResult.AverageObjective = 514787.45;
            cResult.AverageTime = 550.73;
            cResult.Hits = 10;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "unif700-100-2.txt";
            cResult.BestObjective = 519441;
            cResult.AverageObjective = 519065.40;
            cResult.AverageTime = 344.76;
            cResult.Hits = 15;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "unif700-100-3.txt";
            cResult.BestObjective = 512351;
            cResult.AverageObjective = 511206.20;
            cResult.AverageTime = 575.41;
            cResult.Hits = 4;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "unif700-100-4.txt";
            cResult.BestObjective = 513582;
            cResult.AverageObjective = 512826.85;
            cResult.AverageTime = 677.96;
            cResult.Hits = 7;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "unif700-100-5.txt";
            cResult.BestObjective = 510585;
            cResult.AverageObjective = 510282.20;
            cResult.AverageTime = 395.83;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();



            cResult.InstanceName = "unif800-100-1.txt";
            cResult.BestObjective = 639675;
            cResult.AverageObjective = 639410.95;
            cResult.AverageTime = 423.72;
            cResult.Hits = 6;
            cResult.OutOf = 20;

            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "unif800-100-2.txt";
            cResult.BestObjective = 630704;
            cResult.AverageObjective = 630570.75;
            cResult.AverageTime = 400.22;
            cResult.Hits = 4;
            cResult.OutOf = 20;

            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "unif800-100-3.txt";
            cResult.BestObjective = 629108;
            cResult.AverageObjective = 628551.30;
            cResult.AverageTime = 776.37;
            cResult.Hits = 2;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "unif800-100-4.txt";
            cResult.BestObjective = 624728;
            cResult.AverageObjective = 624090.15;
            cResult.AverageTime = 826.25;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "unif800-100-5.txt";
            cResult.BestObjective = 625905;
            cResult.AverageObjective = 625664.15;
            cResult.AverageTime = 428.21;
            cResult.Hits =6;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();



            cResult.InstanceName = "p1000-1.txt";
            cResult.BestObjective = 884970;
            cResult.AverageObjective = 884403.60;
            cResult.AverageTime = 968.40;
            cResult.Hits = 2;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p1000-2.txt";
            cResult.BestObjective = 881751;
            cResult.AverageObjective = 880801.55;
            cResult.AverageTime = 1000.54;
            cResult.Hits = 5;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "p1000-3.txt";
            cResult.BestObjective = 866441;
            cResult.AverageObjective = 865869.25;
            cResult.AverageTime = 1454.97;
            cResult.Hits = 2;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p1000-4.txt";
            cResult.BestObjective = 869374;
            cResult.AverageObjective = 868684.25;
            cResult.AverageTime = 1287.82;
            cResult.Hits = 9;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p1000-5.txt";
            cResult.BestObjective = 888960;
            cResult.AverageObjective = 888383.15;
            cResult.AverageTime = 1356.64;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();



            cResult.InstanceName = "p1500-1.txt";
            cResult.BestObjective = 1619362;
            cResult.AverageObjective = 1618310.50;
            cResult.AverageTime = 3126.51;
            cResult.Hits = 4;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p1500-2.txt";
            cResult.BestObjective = 1649778;
            cResult.AverageObjective = 1647891.20;
            cResult.AverageTime = 2248.48;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "p1500-3.txt";
            cResult.BestObjective = 1611197;
            cResult.AverageObjective = 1608917.85;
            cResult.AverageTime = 3599.09;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p1500-4.txt";
            cResult.BestObjective = 1641933;
            cResult.AverageObjective = 1640887.35;
            cResult.AverageTime = 3067.75;
            cResult.Hits = 3;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p1500-5.txt";
            cResult.BestObjective = 1595627;
            cResult.AverageObjective = 1594238.60;
            cResult.AverageTime = 2897.65;
            cResult.Hits = 4;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();





            cResult.InstanceName = "p2000-1.txt";
            cResult.BestObjective = 2507892;
            cResult.AverageObjective = 2504899.15;
            cResult.AverageTime = 9054.82;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p2000-2.txt";
            cResult.BestObjective = 2494840;
            cResult.AverageObjective = 2493592.70;
            cResult.AverageTime = 7786.81;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "p2000-3.txt";
            cResult.BestObjective = 2544334;
            cResult.AverageObjective = 2541430.45;
            cResult.AverageTime = 8492.93;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p2000-4.txt";
            cResult.BestObjective = 2528684;
            cResult.AverageObjective = 2526603.55;
            cResult.AverageTime = 7119.96;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p2000-5.txt";
            cResult.BestObjective = 2513199;
            cResult.AverageObjective = 2509993.65;
            cResult.AverageTime = 7308.74;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();



            cResult.InstanceName = "newb2500.1.txt";
            cResult.BestObjective = 1063447;
            cResult.AverageObjective = 1061285.90;
            cResult.AverageTime = 9603.47;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "newb2500.2.txt";
            cResult.BestObjective = 1063517;
            cResult.AverageObjective = 1061926.35;
            cResult.AverageTime = 7465.33;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "newb2500.3.txt";
            cResult.BestObjective = 1082275;
            cResult.AverageObjective = 1080759.70;
            cResult.AverageTime = 7991.01;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "newb2500.4.txt";
            cResult.BestObjective = 1065977;
            cResult.AverageObjective = 1064729.95;
            cResult.AverageTime = 9871.94;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "newb2500.5.txt";
            cResult.BestObjective = 1066387;
            cResult.AverageObjective = 1063602.25;
            cResult.AverageTime = 6777.81;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "newb2500.6.txt";
            cResult.BestObjective = 1066847;
            cResult.AverageObjective = 1065194.10;
            cResult.AverageTime = 4908.76;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "newb2500.7.txt";
            cResult.BestObjective = 1068161;
            cResult.AverageObjective = 1066540.75;
            cResult.AverageTime = 4400.32;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "newb2500.8.txt";
            cResult.BestObjective = 1069934;
            cResult.AverageObjective = 1068766.85;
            cResult.AverageTime = 5681.42;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();


            cResult.InstanceName = "newb2500.9.txt";
            cResult.BestObjective = 1071272;
            cResult.AverageObjective = 1069488.00;
            cResult.AverageTime = 9088.52;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "newb2500.10.txt";
            cResult.BestObjective = 1066735;
            cResult.AverageObjective = 1065303.15;
            cResult.AverageTime = 8823.48;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);






            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p3000.1.txt";
            cResult.BestObjective = 3257061;
            cResult.AverageObjective = 3253637.60;
            cResult.AverageTime = 14031.83;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p3000.2.txt";
            cResult.BestObjective = 4099540;
            cResult.AverageObjective = 4095924.60;
            cResult.AverageTime = 10344.62;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p3000.3.txt";
            cResult.BestObjective = 4121651;
            cResult.AverageObjective = 4116510.05;
            cResult.AverageTime = 14861.91;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p3000.4.txt";
            cResult.BestObjective = 4586819;
            cResult.AverageObjective = 4582002.80;
            cResult.AverageTime = 19683.10;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p3000.5.txt";
            cResult.BestObjective = 4638416;
            cResult.AverageObjective = 4628915.50;
            cResult.AverageTime = 8037.94;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);




            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p4000.1.txt";
            cResult.BestObjective = 5013660;
            cResult.AverageObjective = 5008649.80;
            cResult.AverageTime = 19087.02;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p4000.2.txt";
            cResult.BestObjective = 6376823;
            cResult.AverageObjective = 6367326.50;
            cResult.AverageTime = 15685.50;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p4000.3.txt";
            cResult.BestObjective = 6386325;
            cResult.AverageObjective = 6373723.90;
            cResult.AverageTime = 18755.28;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p4000.4.txt";
            cResult.BestObjective = 7121377;
            cResult.AverageObjective = 7114980.55;
            cResult.AverageTime = 17620.49;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p4000.5.txt";
            cResult.BestObjective = 7045223;
            cResult.AverageObjective = 7033485.25;
            cResult.AverageTime = 11596.08;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);




            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p5000.1.txt";
            cResult.BestObjective = 7009948;
            cResult.AverageObjective = 6990929.85;
            cResult.AverageTime = 17047.25;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p5000.2.txt";
            cResult.BestObjective = 8827548;
            cResult.AverageObjective = 8817131.05;
            cResult.AverageTime = 17491.37;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p5000.3.txt";
            cResult.BestObjective = 8965743;
            cResult.AverageObjective = 8949408.10;
            cResult.AverageTime = 19998.82;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p5000.4.txt";
            cResult.BestObjective = 9936590;
            cResult.AverageObjective = 9925708.30;
            cResult.AverageTime = 13058.07;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p5000.5.txt";
            cResult.BestObjective = 9822306;
            cResult.AverageObjective = 9809770.55;
            cResult.AverageTime = 12928.89;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);



            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p6000.1.txt";
            cResult.BestObjective = 9188495;
            cResult.AverageObjective = 9172648.55;
            cResult.AverageTime = 13235.67;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p6000.2.txt";
            cResult.BestObjective = 11695305;
            cResult.AverageObjective = 11671648.95;
            cResult.AverageTime = 20385.28;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p6000.3.txt";
            cResult.BestObjective = 13021696;
            cResult.AverageObjective = 12992334.65;
            cResult.AverageTime = 18872.06;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);



            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p7000.1.txt";
            cResult.BestObjective = 11587271;
            cResult.AverageObjective = 11575532.90;
            cResult.AverageTime = 21024.23;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p7000.2.txt";
            cResult.BestObjective = 14630551;
            cResult.AverageObjective = 14612414.95;
            cResult.AverageTime = 16824.76;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();
            cResult.InstanceName = "new_p7000.3.txt";
            cResult.BestObjective = 16342018;
            cResult.AverageObjective = 16310296.40;
            cResult.AverageTime = 14620.71;
            cResult.Hits = 1;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);









        }

        void InitInstancesTable1()
        {

            string Folder = "c:\\primeri\\CPP\\MIP\\Table1\\";
            mInstancesTable1 = new List<TestInstance>();

            mInstancesTable1.Add(new TestInstance(20, "CPn25-1.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn25-2.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn25-3.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn25-4.txt", Folder));


            mInstancesTable1.Add(new TestInstance(20, "CPn35-1.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn35-2.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn35-3.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn35-4.txt", Folder));


            mInstancesTable1.Add(new TestInstance(20, "CPn45-1.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn45-2.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn45-3.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn45-4.txt", Folder));



            mInstancesTable1.Add(new TestInstance(20, "CPn50-1.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn50-2.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn50-3.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "CPn50-4.txt", Folder));




        }

        void InitInstancesTableMM()
        {

            string Folder = "c:\\primeri\\CPP\\MIP\\mm\\";
            mInstancesTable1 = new List<TestInstance>();

            mInstancesTable1.Add(new TestInstance(20, "mm_Kar_mod1.dat", Folder));
            mInstancesTable1.Add(new TestInstance(20, "mm_Dolphin_mod1.dat", Folder));
            mInstancesTable1.Add(new TestInstance(100, "mm_lesmis.dat", Folder));
            mInstancesTable1.Add(new TestInstance(20, "mm_books.dat", Folder));
            mInstancesTable1.Add(new TestInstance(500, "mm_football.dat", Folder));

        }

        public void InitInstancesMMRes()
        {

            ResultsInstance cResult;

            mTableMM = new List<ResultsInstance>();
            cResult = new ResultsInstance();
//            cResult.InstanceName = "Zachary’s karate club & 34 &";
            cResult.InstanceName = "Karate & 34 &";
            cResult.BestObjective = 4198;
            cResult.AverageTime = 0;
            mTableMM.Add(cResult);


            cResult = new ResultsInstance();
//            cResult.InstanceName = "Dolphins social network & 62 &";
            cResult.InstanceName = "Dolphins& 62 &";
            cResult.BestObjective = 5285;
            cResult.AverageTime = 14;
            mTableMM.Add(cResult);


            cResult = new ResultsInstance();
            cResult.InstanceName = "Les Misérables & 77 &";
            cResult.BestObjective = 5600;
            cResult.AverageTime = 5;
            mTableMM.Add(cResult);


            cResult = new ResultsInstance();
//            cResult.InstanceName = "Books about US politics & 105 &";
            cResult.InstanceName = "Books & 105 &";
            cResult.BestObjective = 5272;
            cResult.AverageTime = 191;
            mTableMM.Add(cResult);


            cResult = new ResultsInstance();
//            cResult.InstanceName = "American College Football & 115 &";
            cResult.InstanceName = "Football & 115 &";
            cResult.BestObjective = 6046;
            cResult.AverageTime = 53;
            mTableMM.Add(cResult);


        }



        void InitInstancesTable2()
        {

            string Folder = "c:\\primeri\\CPP\\MIP\\Table2\\";
            mInstancesTable1 = new List<TestInstance>();

            mInstancesTable1.Add(new TestInstance(20, "Wildcats.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "Cars.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "Workers.txt", Folder));


            mInstancesTable1.Add(new TestInstance(20, "UNO54.txt", Folder));
//            mInstancesTable1.Add(new TestInstance(20, "UNO84A2.txt", Folder));
//            mInstancesTable1.Add(new TestInstance(20, "UNO84B2.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "UNO1984B.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "UNO1984A.txt", Folder));


            //            mInstancesTable1.Add(new TestInstance(20, "Cetacea.txt", Folder));
            //            mInstancesTable1.Add(new TestInstance(20, "Company.txt", Folder));
            //            mInstancesTable1.Add(new TestInstance(20, "Micro.txt", Folder));


            //            mInstancesTable1.Add(new TestInstance(20, "Random1.txt", Folder));
            //            mInstancesTable1.Add(new TestInstance(20, "Random2.txt", Folder));
            //            mInstancesTable1.Add(new TestInstance(20, "Random3.txt", Folder));







        }


        void InitInstancesTableGT()
        {

            string Folder = "c:\\primeri\\CPP\\MIP\\GT\\";
            mInstancesTable1 = new List<TestInstance>();

            mInstancesTable1.Add(new TestInstance(20, "kkv.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "bur.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "gro.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "les.txt", Folder));


            mInstancesTable1.Add(new TestInstance(20, "mcc.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "sei.txt", Folder));
            mInstancesTable1.Add(new TestInstance(20, "sul.txt", Folder));




        }



        void InitInstances()
        {

            string SmallFolder = "c:\\primeri\\CPP\\small\\";
            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";


            mInstances = new List<TestInstance>();
            
                  mInstances.Add(new TestInstance(200, "rand100-5.txt", SmallFolder));
                  mInstances.Add(new TestInstance(200, "rand100-100.txt", SmallFolder));
                 mInstances.Add(new TestInstance(200, "rand200-5.txt", SmallFolder));
                 mInstances.Add(new TestInstance(200, "rand200-100.txt", SmallFolder));
                 mInstances.Add(new TestInstance(200, "rand300-5.txt", SmallFolder));
                 mInstances.Add(new TestInstance(200, "rand300-100.txt", SmallFolder));
                  mInstances.Add(new TestInstance(200, "sym300-50.txt", SmallFolder));
                  mInstances.Add(new TestInstance(200, "regnier300-50.txt", SmallFolder));
                  mInstances.Add(new TestInstance(200, "zahn300.txt", SmallFolder));


                 mInstances.Add(new TestInstance(500, "rand400-5.txt", SmallFolder));
                 mInstances.Add(new TestInstance(500, "rand400-100.txt", SmallFolder));
                 mInstances.Add(new TestInstance(500, "rand500-5.txt", SmallFolder));
                 mInstances.Add(new TestInstance(500, "rand500-100.txt", SmallFolder));


                  mInstances.Add(new TestInstance(500, "p500-5-1.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-2.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-3.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-4.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-5.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-6.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-7.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-8.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-9.txt", SmallFolder));
                  mInstances.Add(new TestInstance(500, "p500-5-10.txt", SmallFolder));



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

            mInstances.Add(new TestInstance(20000, "new_p7000.1.txt", LargeFolder));
             
            mInstances.Add(new TestInstance(20000, "new_p7000.2.txt", LargeFolder));
          
            mInstances.Add(new TestInstance(20000, "new_p7000.3.txt", LargeFolder));
            /**/
        }

        void InitInstancesExtendedCalculation()
        {

            string LargeFolder = "c:\\primeri\\CPP\\large\\";


            mInstances = new List<TestInstance>();


//            mInstances.Add(new TestInstance(20000, "new_p6000.1.txt", LargeFolder));
//            mInstances.Add(new TestInstance(20000, "new_p6000.2.txt", LargeFolder));
//            mInstances.Add(new TestInstance(20000, "new_p6000.3.txt", LargeFolder));

            mInstances.Add(new TestInstance(86400, "new_p7000.1.txt", LargeFolder));
            mInstances.Add(new TestInstance(86400, "new_p7000.2.txt", LargeFolder));
            mInstances.Add(new TestInstance(86400, "new_p7000.3.txt", LargeFolder));
            mInstances.Add(new TestInstance(86400, "new_p6000.3.txt", LargeFolder));
            /**/
        }



        void InitInstancesCompare16()
        {

            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";


            mInstances = new List<TestInstance>();
            
            mInstances.Add(new TestInstance(1000, "unif700-100-1.txt", MediumFolder));
            
            mInstances.Add(new TestInstance(1000, "unif800-100-1.txt", MediumFolder));

            mInstances.Add(new TestInstance(2000, "p1000-1.txt", MediumFolder));

            mInstances.Add(new TestInstance(4000, "p1500-1.txt", MediumFolder));


            mInstances.Add(new TestInstance(10000, "p2000-1.txt", MediumFolder));





            mInstances.Add(new TestInstance(10000, "new_b2500.1.txt", LargeFolder));
        }
        void InitInstancesCompare32()
        {

            string LargeFolder = "c:\\primeri\\CPP\\large\\";


            mInstances = new List<TestInstance>();

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

            mInstances.Add(new TestInstance(20000, "new_p7000.1.txt", LargeFolder));

            mInstances.Add(new TestInstance(20000, "new_p7000.2.txt", LargeFolder));

            mInstances.Add(new TestInstance(20000, "new_p7000.3.txt", LargeFolder));





            /**/
        }


        public void SolveSingle()
        {


            string SmallFolder = "c:\\primeri\\CPP\\small\\";
            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";

            CPPProblem tProblem;
            InitInstances();

            mInstances.Clear();

                                    mInstances.Add(new TestInstance(2000, "p1000-5.txt", MediumFolder));
//                                        mInstances.Add(new TestInstance(100, "rand100-100.txt", SmallFolder));

            //                        mInstances.Add(new TestInstance(10000, "rand100-100.txt", SmallFolder));

            //           mInstances.Add(new TestInstance(4000, "p1500-5.txt", MediumFolder));

            //            mInstances.Add(new TestInstance(20000, "new_p4000.3.txt", LargeFolder));
//                        mInstances.Add(new TestInstance(20000, "new_p6000.1.txt", LargeFolder));

      //      mInstances.Add(new TestInstance(4000, "new_b2500.5.txt", LargeFolder));


            foreach (TestInstance t in mInstances)
            {

                tProblem = new CPPProblem(t.mFolder + t.mFileName, t.mFileName);
                tProblem.SetID(2);
                tProblem.AllocateSolution();
//                tProblem.SASelect = SASelectType.Single;

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(t.mCalcTime);
                //                tProblem.SolveGRASP(10000, t.mCalcTime);
                tProblem.Solve( 100000, t.mCalcTime);
            }


        }

        public void SolveAllTable1()
        {

            CPPProblem tProblem;
            StreamWriter S = new StreamWriter("ResAllTable1.txt");
            CPPInstance In;
            //            InitInstances();

            S = new StreamWriter(".\\MIPRes\\ResAllTable1.txt");
            S.Close();

            InitInstancesTable1();
            InitInstancesTable1Res();
            string Folder = "c:\\primeri\\CPP\\MIP\\Table1\\";

            S.Close();
            int counter=0;
            double TimeBest;
            string STimeBest; 
            foreach (TestInstance t in mInstancesTable1)
            {

                In = new CPPInstance();
                In.LoadMIP1(Folder + t.mFileName);
                tProblem = new CPPProblem(Folder + t.mFileName, t.mFileName, In);
//                tProblem.InitTracking();
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(6);
                tProblem.Solve(100000, t.mCalcTime/10);

                TimeBest = tProblem.GetBestTime();
                if (TimeBest < 10)
                    STimeBest = "0.01 $>$ ";
                else
                    STimeBest = (TimeBest / 1000).ToString("0.00");
                
                S = new StreamWriter(".\\MIPRes\\ResAllTable1.txt", true);
                S.WriteLine( mTable1[counter].InstanceName 
                           + " &  " + mTable1[counter].BestObjective
                           + " & " + mTable1[counter].AverageTime 
                           +" & " + tProblem.BestSolution  
                           + " & " + STimeBest
                           + " & 10/10"
                            + "\\\\"
                            );
                S.Close();
                counter++;
            }

        }

        public void SolveAllTable2()
        {

            CPPProblem tProblem;
            StreamWriter S = new StreamWriter(".\\MIPRes\\ResAllTable2.txt");
            CPPInstance In;
            //            InitInstances();
            InitInstancesTable2();
            InitInstancesTable2Res();

            string Folder = "c:\\primeri\\CPP\\MIP\\Table2\\";

            S.Close();
            int counter = 0;
            long TimeBest;
            string STimeBest;
            foreach (TestInstance t in mInstancesTable1)
            {

                In = new CPPInstance();
                In.LoadMIP_Convert(Folder + t.mFileName);
                tProblem = new CPPProblem(Folder + t.mFileName, t.mFileName, In);
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(6);
                tProblem.Solve(100000, t.mCalcTime / 10);
                
                TimeBest = tProblem.GetBestTime();
                if (TimeBest < 10)
                    STimeBest = "0.01$>$ ";
                else
                    STimeBest = ((double)TimeBest / 1000).ToString("0.00");


                S = new StreamWriter(".\\MIPRes\\ResAllTable2.txt", true);
//                S.WriteLine(mTable2[counter].InstanceName
//                         + " &  " + mTable2[counter].BestObjective + " & " + tProblem.BestSolution
//                         + " & " + mTable2[counter].AverageTime + " & " + STimeBest + "\\\\");


                S.WriteLine(mTable2[counter].InstanceName
                        + " &  " + mTable2[counter].BestObjective
                        + " & " + mTable2[counter].AverageTime
                        + " & " + tProblem.BestSolution
                        + " & " + STimeBest
                        + " & 10/10"
                         + "\\\\"
                         );

                S.Close();
                counter++;
            }

        }


        public void SolveAllTableGT()
        {

            CPPProblem tProblem;
            StreamWriter S = new StreamWriter(".\\MIPRes\\ResAllTableGT.txt");
            CPPInstance In;
            //            InitInstances();
            InitInstancesTableGT();
            InitInstancesTableGTRes();
            string Folder = "c:\\primeri\\CPP\\MIP\\GT\\";
            int counter = 0;
            long TimeBest;
            string STimeBest;


            S.Close();
            foreach (TestInstance t in mInstancesTable1)
            {

                In = new CPPInstance();
                In.LoadMIP_GT(Folder + t.mFileName);
                tProblem = new CPPProblem(Folder + t.mFileName, t.mFileName, In);
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(6);
                tProblem.Solve(100000, t.mCalcTime / 10);

                TimeBest = tProblem.GetBestTime();
                if (TimeBest < 10)
                    STimeBest = "0.01$>$ ";
                else
                    STimeBest = ((double)TimeBest / 1000).ToString("0.00");

                S = new StreamWriter(".\\MIPRes\\ResAllTableGT.txt", true);
//                S.WriteLine(mTableGT[counter].InstanceName
//                       + " &  " + mTableGT[counter].BestObjective + " & " + tProblem.BestSolution
//                       + " & " + mTableGT[counter].AverageTime + " & " + STimeBest + "\\\\");


                S.WriteLine(mTableGT[counter].InstanceName
                       + " &  " + mTableGT[counter].BestObjective
                       + " & " + mTableGT[counter].AverageTime
                       + " & " + tProblem.BestSolution
                       + " & " + STimeBest
                       + " & 10/10"
                        + "\\\\"
                        );


                S.Close();
                counter++;
            }

        }


        public void SolveAllTableMM()
        {

            CPPProblem tProblem;
            StreamWriter S = new StreamWriter(".\\MIPRes\\ResAllTableMM.txt");
            CPPInstance In;
            //            InitInstances();
            InitInstancesTableMM();
            InitInstancesMMRes();
            string Folder = "c:\\primeri\\CPP\\MIP\\MM\\";
            int counter = 0;
            long TimeBest;
            string STimeBest;
            double C;
            double CorrectResMIP;
            double CorrectResFSS;

            S.Close();
            foreach (TestInstance t in mInstancesTable1)
            {

                In = new CPPInstance();
                C = In.LoadMIP_MM(Folder + t.mFileName);

                tProblem = new CPPProblem(Folder + t.mFileName, t.mFileName, In);
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(6);
                tProblem.Solve(100000, t.mCalcTime / 10);

                TimeBest = tProblem.GetBestTime();
                if (TimeBest < 10)
                    STimeBest = "0.01$>$ ";
                else
                    STimeBest = ((double)TimeBest / 1000).ToString("0.00");

                CorrectResMIP = (mTableMM[counter].BestObjective / (double)10000);
                CorrectResFSS = (tProblem.BestSolution - C * 1000000) / ((double)1000000);

                S = new StreamWriter(".\\MIPRes\\ResAllTableMM.txt", true);
//                S.WriteLine(mTableMM[counter].InstanceName
//                       + " &  " + mTableMM[counter].BestObjective + " & " + (tProblem.BestSolution + C * 100000)
//                       + " & " + mTableMM[counter].AverageTime + " & " + STimeBest + "\\\\");

//                S.WriteLine(mTableMM[counter].InstanceName
//                       + " &  " + CorrectResMIP.ToString("0.0000") + " & " + CorrectResFSS.ToString("0.0000")
//                       + " & " + mTableMM[counter].AverageTime + " & " + STimeBest + "\\\\");


                S.WriteLine(mTableMM[counter].InstanceName
                        + " &  " + CorrectResMIP.ToString("0.0000")
                        + " & " + mTableMM[counter].AverageTime
                        + " & " + CorrectResFSS.ToString("0.0000")
                        + " & " + STimeBest
                        + " & 10/10"
                        + "\\\\"
                        );



                S.Close();
                counter++;
            }

        }






        void SolveParallelInstance( TestInstance iInstance, int NumParallel, CPPProblem.CPPMetaheuristic iMetaHeuristic, SASelectType iSASelectType, int StartValue = 0) {

            List<CPPProblem> tProblems = new List<CPPProblem>();
            CPPProblem tProblem;

            CPPInstance tInstance;

            tInstance = new CPPInstance(iInstance.mFolder + iInstance.mFileName);



            for (int i = 0; i < NumParallel; i++)
            {


                tProblem = new CPPProblem(iInstance.mFolder + iInstance.mFileName, iInstance.mFileName, tInstance);
                tProblem.Metaheuristic = iMetaHeuristic;
                tProblem.SetID(i+StartValue);
                tProblem.AllocateSolution();
                tProblem.SASelect = iSASelectType;
                tProblem.InitLogFileName();
                tProblem.Calibrate(iInstance.mCalcTime/2);
                tProblems.Add(tProblem);

            }


            Parallel.ForEach(tProblems, Prob =>
            {

                Prob.Solve( 100000, iInstance.mCalcTime/2);
            }
            );


        }

        void SolveParallelInstanceExtendedCalculation(TestInstance iInstance, int NumParallel, CPPProblem.CPPMetaheuristic iMetaHeuristic, SASelectType iSASelectType, int StartValue = 0)
        {

            List<CPPProblem> tProblems = new List<CPPProblem>();
            CPPProblem tProblem;

            CPPInstance tInstance;

            tInstance = new CPPInstance(iInstance.mFolder + iInstance.mFileName);



            for (int i = 0; i < NumParallel; i++)
            {


                tProblem = new CPPProblem(iInstance.mFolder + iInstance.mFileName, iInstance.mFileName, tInstance);
                tProblem.Metaheuristic = iMetaHeuristic;
                tProblem.SetID(i + StartValue);
                tProblem.AllocateSolution();
                tProblem.SASelect = iSASelectType;
                tProblem.InitLogFileName();
                tProblem.Calibrate(iInstance.mCalcTime);
                tProblems.Add(tProblem);

            }


            Parallel.ForEach(tProblems, Prob =>
            {

                Prob.Solve(100000, iInstance.mCalcTime);
            }
            );


        }

        public void SolveSingleParallel(int tNumParallel, CPPProblem.CPPMetaheuristic iMetaHeuristic, SASelectType iSASelectType)
        {


            string SmallFolder = "c:\\primeri\\CPP\\small\\";
            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";

            CPPProblem tProblem;
            InitInstances();
//            int tNumParallel = 10;
            List<CPPProblem> tProblems = new List<CPPProblem>();
            mInstances.Clear();

            mInstances.Add(new TestInstance(2000, "p1000-5.txt", MediumFolder));
        
            CPPInstance tInstance;

            tInstance = new CPPInstance(mInstances[0].mFolder + mInstances[0].mFileName);
            for (int i = 0; i < tNumParallel; i++)
            {


                tProblem = new CPPProblem(mInstances[0].mFolder + mInstances[0].mFileName, mInstances[0].mFileName, tInstance);
                tProblem.SASelect = iSASelectType;
                tProblem.Metaheuristic = iMetaHeuristic;
                tProblem.SetID(i);
                tProblem.AllocateSolution();
                tProblem.SASelect = SASelectType.Dual;
                tProblems.Add(tProblem);

            }

            int c;

           

            Parallel.ForEach(tProblems, Prob =>
                                {
                                    Prob.Calibrate(mInstances[0].mCalcTime);
                                    Prob.Solve( 10000, mInstances[0].mCalcTime/4);
                                    //Prob.SolveGRASP(mInstances[0].mCalcTime, 10000);
                                }
            );
           

        }


        public void SolveAll()
        {

            CPPProblem tProblem;
            StreamWriter S = new StreamWriter("ResAll.txt");

            InitInstances();

            foreach (TestInstance t in mInstances)
            {

                tProblem = new CPPProblem(t.mFolder + t.mFileName, t.mFileName);
                tProblem.AllocateSolution();

                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(6);
                tProblem.Solve( 100000, t.mCalcTime);

                S = new StreamWriter("ResAll.txt", true);
                S.WriteLine(t.mFileName + " " + tProblem.BestSolution);
                S.Close();
            }

        }

        public void SolveAllParallel(int NumParallel, CPPProblem.CPPMetaheuristic iMetaHeuristic, SASelectType iSASelectType, int Start)
        {

            InitInstances();
            foreach (TestInstance t in mInstances)
            {
                    SolveParallelInstance(t, NumParallel, iMetaHeuristic, iSASelectType,Start);
            }

        }

        public void SolveAllParallelExtendedCalculation(int NumParallel, CPPProblem.CPPMetaheuristic iMetaHeuristic, SASelectType iSASelectType, int Start)
        {

            InitInstancesExtendedCalculation();
            foreach (TestInstance t in mInstances)
            {
                SolveParallelInstanceExtendedCalculation(t, NumParallel, iMetaHeuristic, iSASelectType, Start);
            }

        }



        public void SolveAllParallelCompare(int NumParallel, int StartValue)
        {
            SASelectType[]                     selectSAType = { SASelectType.Dual, SASelectType.Single};
            CPPProblem.CPPMetaheuristic[]      selectMetaheuristic = { CPPProblem.CPPMetaheuristic.FSS, CPPProblem.CPPMetaheuristic.GRASP };   
         //   InitInstances();

//            InitInstancesCompare16();
            InitInstancesCompare32();
            foreach (TestInstance t in mInstances)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if(!((i== 0) &&(j == 0)))
                             SolveParallelInstance(t, NumParallel, selectMetaheuristic[i], selectSAType[j], StartValue);
                    }
                }
            }

        }




        bool LoadResults(string Filename, long[] Info)
        {
            if (!File.Exists(Filename))
                return false;
            
            string[] Lines = File.ReadAllLines(Filename);
            char[] sep = { ' ' };
            string[] words;

            words = Lines[Lines.Length - 1].Split(sep);

            Info[0] = System.Convert.ToInt64(words[0]);
            Info[1] = System.Convert.ToInt64(words[1]);
            Info[2] = System.Convert.ToInt64(words[2]);

            return true;

        }

        public List<long> GetAllResultInstanceValue(string FileNameBase, string Folder, int NumRuns, string Method = "") {

            List<long> Result = new List<long>();
            long[] temp = new long[3];

            string cFileName;
            for (int i = 0; i < NumRuns; i++)
            {

                if (Method == "")
                    cFileName = Folder + "Log_" + i + "_" + FileNameBase;
                else
                    cFileName = Folder + Method + "Log_" + i + "_" + FileNameBase;


                if (!LoadResults(cFileName, temp))
                    return null;

                Result.Add((long)temp[0]);
            }


            return Result;
        
        }

        public bool  GetAggregateResults(string FileNameBase,  string Folder, int NumRuns, out ResultsInstance r,string Method = "") {

            List<long> Res = new List<long>();
            long SumTime = 0;
            long SumIter = 0;
            long SumObjective = 0;
            
            r = new ResultsInstance();

            int Hits;
            string cFileName;
            long[] temp = new long[3];

            r.BestObjective = int.MinValue;
            for (int i = 0; i < NumRuns; i++) {

                if (Method == "")
                    cFileName = Folder + "Log_" + i + "_" + FileNameBase;
                else
                     cFileName = Folder + Method + "Log_" + i + "_" + FileNameBase;


                if (!LoadResults(cFileName, temp))
                    return false;

                SumTime += temp[2];
                SumIter += temp[1];
                SumObjective += temp[0];
                if (r.BestObjective < temp[0])
                    r.BestObjective =(int) temp[0];
                Res.Add(temp[0]);
            }

            r.AverageIter = SumIter / (double)NumRuns;
            r.AverageTime = SumTime / ((double)NumRuns *1000);
            r.AverageObjective = SumObjective / (double)NumRuns;

            r.OutOf = NumRuns;

            r.Hits = 0;
            r.InstanceName = FileNameBase;

            foreach (int o in Res) {

                if (o == r.BestObjective)
                    r.Hits++;
            }

            return true;
        }







        public void CreateTable(int NumRuns, string ResultsFolder, string Method = "")
        {

            ResultsInstance Res;
            List<ResultsInstance> Compare = new List<ResultsInstance>();
            StreamWriter  F = new StreamWriter("Table_"+Method+".txt");
            string ResString;

            InitInstances();
            InitMDMCPResults();


            for(int i=0; i< mInstances.Count; i++)
            {
                if (GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out Res, Method)) {

                    Compare.Clear();
                    Compare.Add(mMDMCP[i]);
                    Compare.Add(Res);
                    ResString = ResultsInstance.GetTableCompareString(Compare, true, true);

                    F.WriteLine(ResString);
//                    F.WriteLine(Res.GetTableString(true));
                }
                
            }

            F.Close();
        }


        public void CreateCompareTable(int NumRuns, string ResultsFolder, string type)
        {

            ResultsInstance Res;
            List<ResultsInstance> Compare = new List<ResultsInstance>();
            StreamWriter F = new StreamWriter("Table"+ type +".txt");
            string ResString;

     //       InitInstances();
            //InitMDMCPResults();
            if(type == "16")
                InitInstancesCompare16();
            if (type == "32")
                InitInstancesCompare32();


            for (int i = 0; i < mInstances.Count; i++)
            {

                Compare.Clear();
                if (GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out Res, "GRASP_Single_"))
                {
                    Compare.Add(Res);
                }
                if (GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out Res, "FSS_Single_"))
                {
                    Compare.Add(Res);
                }
                if (GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out Res, "GRASP_Dual_"))
                {
                    Compare.Add(Res);
                }
                if (GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out Res, "FSS_Dual_"))
                {
                    Compare.Add(Res);
                }


                if (Compare.Count > 0)
                {

                    ResString = ResultsInstance.GetTableCompareString(Compare, true, false);

                    F.WriteLine(ResString);
                }

            }

            F.Close();
        }


        public string StatUnpairedTTEst(List<long> G1, List<long> G2) {

            string result = "$\\approx$";

            var group1Results = Vector.Create(new double[] {
                62, 77, 61, 94, 75, 82, 86, 83, 64, 84,
            });


            var group2Results = Vector.Create(new double[] {
                61, 80, 98, 90, 94, 65, 79, 75, 74, 86,
            });

            for (int ii = 0; ii < 10; ii++)
            {

                group1Results[ii] = G1[ii];
                group2Results[ii] = G2[ii];
                //                    group2Results[ii] = GRASP_Single[ii];
            }

            var tTest2 = new TwoSampleTTest(group1Results, group2Results, 1, SamplePairing.Unpaired, false, HypothesisType.TwoTailed);



            if (!tTest2.Reject())
                return result;
            Console.WriteLine("P-value:        {0:F4}", tTest2.PValue);
            Console.WriteLine("Significance level:     {0:F2}", tTest2.SignificanceLevel);


            tTest2 = new TwoSampleTTest(group1Results, group2Results, 1, SamplePairing.Unpaired, false, HypothesisType.OneTailedUpper);

            if (!tTest2.Reject())
            {
                Console.WriteLine("P-value:        {0:F4}", tTest2.PValue);
                Console.WriteLine("Significance level:     {0:F2}", tTest2.SignificanceLevel);
                Console.WriteLine("Reject null hypothesis? {0}", tTest2.Reject() ? "yes" : "no");
                result = "$<$";
                return result;
            }

            tTest2 = new TwoSampleTTest(group1Results, group2Results, 1, SamplePairing.Unpaired, false, HypothesisType.OneTailedLower);

            if (!tTest2.Reject())
            {
                result = "$>$";
                Console.WriteLine("P-value:        {0:F4}", tTest2.PValue);
                Console.WriteLine("Significance level:     {0:F2}", tTest2.SignificanceLevel);
                Console.WriteLine("Reject null hypothesis? {0}", tTest2.Reject() ? "yes" : "no");
                return result;
            }

            return result;

        }

        public void CreateTimeTable(int NumRuns, string ResultsFolder, string type)
        {


            ResultsInstance Res;
            List<ResultsInstance> Compare = new List<ResultsInstance>();
            StreamWriter F = new StreamWriter("TableTime" + type + ".txt");
            int[] NumInstances = { 10, 5, 5, 5, 3, 3 };
            int[] InstancesSize = { 2500, 3000, 4000, 5000, 6000, 7000 };
            int CurrentSizeCounter = 0;
            int CurrentSizeIndex;

            


            if (type == "16")
                InitInstancesCompare16();
            if (type == "32")
                InitInstancesCompare32();


            CurrentSizeIndex = 0;


            ResultsInstance RGRASP_Single;
            ResultsInstance RGRASP_Dual;


            ResultsInstance RFSS_Single;
            ResultsInstance RFSS_Dual;

            double AvgTimeIterFSS_Single = 0;
            double AvgTimeIterFSS_Dual = 0;

            double AvgTimeIterGRASP_Single = 0;
            double AvgTimeIterGRASP_Dual = 0;



            for (int i = 0; i < mInstances.Count; i++)
            {

                GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out RGRASP_Single, "GRASP_Single_");
                GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out RGRASP_Dual, "GRASP_Dual_");
                GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out RFSS_Single, "FSS_Single_");
                GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out RFSS_Dual, "FSS_Dual_");

                AvgTimeIterFSS_Dual += ((double)RFSS_Dual.AverageTime) / RFSS_Dual.AverageIter;
                AvgTimeIterFSS_Single += ((double)RFSS_Single.AverageTime) / RFSS_Single.AverageIter;


                AvgTimeIterGRASP_Dual += ((double)RGRASP_Dual.AverageTime) / RGRASP_Dual.AverageIter;
                AvgTimeIterGRASP_Single += ((double)RGRASP_Single.AverageTime) / RGRASP_Single.AverageIter;




                CurrentSizeCounter++;
                if (NumInstances[CurrentSizeIndex] == CurrentSizeCounter)
                {

                    AvgTimeIterFSS_Dual /= CurrentSizeCounter;
                    AvgTimeIterFSS_Single /= CurrentSizeCounter;


                    AvgTimeIterGRASP_Dual /= CurrentSizeCounter;
                    AvgTimeIterGRASP_Single /= CurrentSizeCounter;


                    F.WriteLine(InstancesSize[CurrentSizeIndex]
                                + " & " + (mInstances[i].mCalcTime / 2).ToString()
                                + " & " + AvgTimeIterGRASP_Single.ToString("0.0")
                                + " & " + AvgTimeIterGRASP_Dual.ToString("0.0")
                                + " & " + AvgTimeIterFSS_Single.ToString("0.0")
                                + " & " + AvgTimeIterFSS_Dual.ToString("0.0")
                                + "\\\\"
                        );

                    CurrentSizeCounter = 0;
                    CurrentSizeIndex++;


                }


            }

            F.Close();
        }
            public void CreateStatisticTable(int NumRuns, string ResultsFolder, string type)
        {

            ResultsInstance Res;
            List<ResultsInstance> Compare = new List<ResultsInstance>();
            StreamWriter F = new StreamWriter("TableStat" + type + ".txt");
            List<long> GRASP_Dual;
            List<long> GRASP_Single;

            List<long> FSS_Dual;
            List<long> FSS_Single;

            string ResString;

            var group1Results = Vector.Create(new double[] {
                62, 77, 61, 94, 75, 82, 86, 83, 64, 84,
            });


            var group2Results = Vector.Create(new double[] {
                61, 80, 98, 90, 94, 65, 79, 75, 74, 86,
            });


            

            //            var tTest2 = new MannWhitneyTest<double>(group1Results, group2Results); 

            var tTest2 = new TwoSampleTTest(group1Results, group2Results, SamplePairing.Unpaired, false);
            // We can obtan the value of the test statistic through the Statistic property,
            // and the corresponding P-value through the Probability property:
            Console.WriteLine("Test statistic: {0:F4}", tTest2.Statistic);
            Console.WriteLine("P-value:        {0:F4}", tTest2.PValue);

            // The significance level is the default value of 0.05:
            Console.WriteLine("Significance level:     {0:F2}", tTest2.SignificanceLevel);
            // We can now print the test scores:
            Console.WriteLine("Reject null hypothesis? {0}", tTest2.Reject() ? "yes" : "no");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();

            //       InitInstances();
            //InitMDMCPResults();
            if (type == "16")
                InitInstancesCompare16();
            if (type == "32")
                InitInstancesCompare32();

            string temp;
            for (int i = 0; i < mInstances.Count; i++)
            {




                ResString = mInstances[i].mFileName ;

                ResString = ResString.Replace(".txt", "");
                ResString = ResString.Replace("new_", "");

                GRASP_Single = GetAllResultInstanceValue(mInstances[i].mFileName, ResultsFolder, NumRuns, "GRASP_Single_");
                FSS_Single = GetAllResultInstanceValue(mInstances[i].mFileName, ResultsFolder, NumRuns, "FSS_Single_");
                GRASP_Dual = GetAllResultInstanceValue(mInstances[i].mFileName, ResultsFolder, NumRuns, "GRASP_Dual_");
                FSS_Dual = GetAllResultInstanceValue(mInstances[i].mFileName, ResultsFolder, NumRuns, "FSS_Dual_");

                temp = StatUnpairedTTEst(GRASP_Single, GRASP_Dual);
                ResString += " & " + temp;

                temp = StatUnpairedTTEst(GRASP_Single, FSS_Single);
                ResString += " & " +temp;

                temp = StatUnpairedTTEst(GRASP_Single, FSS_Dual);
                ResString += " & " + temp;

                temp = StatUnpairedTTEst(GRASP_Dual, FSS_Single);
                ResString += " & " + temp;

                temp = StatUnpairedTTEst(GRASP_Dual, FSS_Dual);
                ResString += " & " + temp;

                temp = StatUnpairedTTEst(FSS_Single, FSS_Dual);
                ResString += " & " + temp;

                ResString += " \\\\ ";





                F.WriteLine(ResString);              






            }

            F.Close();
        }




    }


}



