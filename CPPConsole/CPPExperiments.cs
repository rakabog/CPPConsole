using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
            cResult.BestObjective = 16808;
            cResult.AverageObjective = 16808;
            cResult.AverageTime = 192.45;
            cResult.Hits = 20;
            cResult.OutOf = 20;
            mMDMCP.Add(cResult);

            cResult = new ResultsInstance();

            cResult.InstanceName = "p500-100-5.txt";
            cResult.BestObjective = 309567;
            cResult.AverageObjective = 309555.50;
            cResult.AverageTime = 509.23;
            cResult.Hits = 16;
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
            cResult.AverageObjective = 1063602.25;
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












        }
        void InitInstances()
        {

            string SmallFolder = "c:\\primeri\\CPP\\small\\";
            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";


            mInstances = new List<TestInstance>();

            /*
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
            */
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

            //                        mInstances.Add(new TestInstance(2000, "p1000-1.txt", MediumFolder));
            //                            mInstances.Add(new TestInstance(100, "rand100-100.txt", SmallFolder));

            //                        mInstances.Add(new TestInstance(10000, "rand100-100.txt", SmallFolder));

            //           mInstances.Add(new TestInstance(4000, "p1500-5.txt", MediumFolder));

            //            mInstances.Add(new TestInstance(20000, "new_p4000.3.txt", LargeFolder));
            //            mInstances.Add(new TestInstance(20000, "new_p6000.1.txt", LargeFolder));

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

        void SolveParallelInstance( TestInstance iInstance, int NumParallel) {

            List<CPPProblem> tProblems = new List<CPPProblem>();
            CPPProblem tProblem;

            for (int i = 0; i < NumParallel; i++)
            {


                tProblem = new CPPProblem(iInstance.mFolder + iInstance.mFileName, iInstance.mFileName);
                tProblem.SetID(i);
                tProblem.AllocateSolution();
                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(iInstance.mCalcTime);
                tProblems.Add(tProblem);

            }


            Parallel.ForEach(tProblems, Prob =>
            {

                Prob.SolveFixSetSearch(iInstance.mCalcTime, 100000);
            }
            );


        }

        public void SolveSingleParallel()
        {


            string SmallFolder = "c:\\primeri\\CPP\\small\\";
            string MediumFolder = "c:\\primeri\\CPP\\medium\\";
            string LargeFolder = "c:\\primeri\\CPP\\large\\";

            CPPProblem tProblem;
            InitInstances();
            int tNumParallel = 10;
            List<CPPProblem> tProblems = new List<CPPProblem>();
            mInstances.Clear();

            mInstances.Add(new TestInstance(2000, "p1000-5.txt", MediumFolder));

            //                                    mInstances.Add(new TestInstance(100, "rand100-100.txt", SmallFolder));

            //                        mInstances.Add(new TestInstance(4000, "p1500-1.txt", MediumFolder));
            //          mInstances.Add(new TestInstance(10000, "p2000-2.txt", MediumFolder));

            /**/


            for (int i = 0; i < tNumParallel; i++)
            {


                tProblem = new CPPProblem(mInstances[0].mFolder + mInstances[0].mFileName, mInstances[0].mFileName);
                tProblem.SetID(i);
                tProblem.AllocateSolution();
                tProblem.SASelect = SASelectType.Dual;
                tProblem.Calibrate(mInstances[0].mCalcTime);
                tProblems.Add(tProblem);

            }

            int c;

           

            Parallel.ForEach(tProblems, Prob =>
                                {

                                    Prob.SolveFixSetSearch(mInstances[0].mCalcTime, 10000);
                                }
            );
            /**/







            //            A.Close();
            //            B.Close();


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
                tProblem.SolveFixSetSearch(t.mCalcTime, 100000);

                S = new StreamWriter("ResAll.txt", true);
                S.WriteLine(t.mFileName + " " + tProblem.BestSolution);
                S.Close();
            }

        }

        public void SolveAllParallel(int NumParallel) {

            InitInstances();

            foreach (TestInstance t in mInstances)
            {
                SolveParallelInstance(t, NumParallel);
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

        public bool  GetAggregateResults(string FileNameBase, string Folder, int NumRuns, out ResultsInstance r) {

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
                
                cFileName = Folder + "Log_"+i+"_" + FileNameBase;
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

        public void CreateTable(int NumRuns, string ResultsFolder)
        {

            ResultsInstance Res;
            List<ResultsInstance> Compare = new List<ResultsInstance>();
            StreamWriter  F = new StreamWriter("Table.txt");
            string ResString;

            InitInstances();
            InitMDMCPResults();


            for(int i=0; i< mInstances.Count; i++)
            {
                if (GetAggregateResults(mInstances[i].mFileName, ResultsFolder, NumRuns, out Res)) {

                    Compare.Clear();
                    Compare.Add(mMDMCP[i]);
                    Compare.Add(Res);
                    ResString = ResultsInstance.GetTableCompareString(Compare, true);

                    F.WriteLine(ResString);
//                    F.WriteLine(Res.GetTableString(true));
                }

                
            }

            F.Close();
        }

    }


}

