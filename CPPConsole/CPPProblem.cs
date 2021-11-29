using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CPP
{
    class CPPProblem
    {
        public enum GreedyHeuristicType  { MaxIncrease, Random };
       public enum CPPMetaheuristic { GRASP, FSS }

        CPPInstance         mInstance;
        CPPSolutionBase     mSolution;
        CPPSolutionHolder   mSolutionHolder;
        
        RCL<CPPCandidate>   mRCL;

        int                 mRCLSize;
        static Random       mGenerator;
        List<List<int>>     mAvailableNodes;
        GreedyHeuristicType mGreedyHeuristic;
        int                 mBestSolutionValue;
        string              mLogFileName;
        string              mFileName;
        string              mInstanceName;

        CPPMetaheuristic    mMetaHeuristic;
        Stopwatch mStopWatch;
        SASelectType    mSASType;

        int mFixStagnation;
        int mFixK;
        int mFixInitPopulation;
        int mFixN;
        double          mSAInitTemperature;
        int             mID;


        List<int> mIntermediateSolutions;
        List<long> mIntermediateSolutionsTimes;
        List<long> mIntermediateSolutionsIterations;
        int mNumberOfSolutionsGenerated;


        public void SetID(int iID) {

            mID = iID;


            mLogFileName = "Log_" +mID+"_" + mInstanceName;
            StreamWriter S = new StreamWriter(mLogFileName);
            S.Close();


        }
        public int ID
        {
            get { return mID; }
        }
        public int BestSolution
        {
            get { return mBestSolutionValue; }
        }
        public GreedyHeuristicType GreedyHeuristic
        {
            get { return mGreedyHeuristic; }
            set { mGreedyHeuristic = value; }

        }

        public SASelectType SASelect
        {
            get { return mSASType; }
            set { mSASType = value; }
        }

        public void InitAvailable(List<List<int>> FixedSet) {
            List<int> temp;
            bool[] usedNodes = new bool[mInstance.NumberOfNodes];

            Array.Fill(usedNodes, false);

            mAvailableNodes = new List<List<int>>();
            if (FixedSet == null)
            {
                for (int i = 0; i < mInstance.NumberOfNodes; i++)
                {

                    temp = new List<int>();
                    temp.Add(i);
                    mAvailableNodes.Add(temp);
                }
                return;
            }

                foreach (List<int> l in FixedSet)
                {

                    mAvailableNodes.Add(l);
                    foreach (int n in l)
                    {
                        usedNodes[n] = true;
                    }
                }

                for (int i = 0; i < mInstance.NumberOfNodes; i++)
                {

                    if (!usedNodes[i])
                    {

                        temp = new List<int>();
                        temp.Add(i);
                        mAvailableNodes.Add(temp);
                    }
                }

                for (int i = 0; i < FixedSet.Count; i++) {

                    AddToSolution(new CPPCandidate(FixedSet[i], i, 0));
                }
            
        }

        public void InitTracking()
        {


            mIntermediateSolutions = new List<int>();
            mIntermediateSolutionsTimes = new List<long>();
            mIntermediateSolutionsIterations = new List<long>();


        }

        void InitFSS()
        {


            mFixStagnation = 10;
            mFixK = 10;
            mFixInitPopulation = 100;
            mFixN  =100;
        }




        public static void shuffle(List<int> list)
        {
            //            Random rng = new Random();   // i.e., java.util.Random.
            int n = list.Count;        // The number of items left to shuffle (loop invariant).
            while (n > 1)
            {
                int k = mGenerator.Next(n);  // 0 <= k < n.
                n--;                     // n is now the last pertinent index;
                int temp = list[n];     // swap array[n] with array[k] (does nothing if k == n).
                list[n] = list[k];
                list[k] = temp;
            }
        }

        public CPPProblem(string FileName, string InstanceName) {

            mInstance = new CPPInstance(FileName);
            mSolution = new CPPSolutionMaxIncrease(mInstance);
            mGenerator = new Random(2);

            mRCLSize =2;

            mFileName = FileName;
            mInstanceName = InstanceName;


            mRCL = new RCL< CPPCandidate > (mRCLSize);
            mLogFileName = "Log"+ mInstanceName;
            StreamWriter S = new StreamWriter(mLogFileName);
            S.Close();
            mSolutionHolder = new CPPSolutionHolder();

            InitFSS();

            mMetaHeuristic = CPPMetaheuristic.FSS;

           mGreedyHeuristic = GreedyHeuristicType.MaxIncrease;
            //          mGreedyHeuristic = GreedyHeuristicType.Agglomeration;

            CPPSolutionMaxIncrease.Init(mInstance.NumberOfNodes);

        }

        public void AllocateSolution() {

            mSolution = null;
            switch (mGreedyHeuristic) {

                case GreedyHeuristicType.MaxIncrease:
                    mSolution = new CPPSolutionMaxIncrease(mInstance);
                    break;
            }

            mSolution.SASType = mSASType;

        }

        public double[] GetFrequency(int BaseSolutionIndex, List<int> SelectedSolutionIndexes) {

            double[] frequency = new double[mInstance.NumberOfNodes];
            CPPSolutionBase Base = mSolutionHolder.Solutions[BaseSolutionIndex];

            for (int i = 0; i < mInstance.NumberOfNodes; i++)
                frequency[i] = 0;
            foreach (int sel in SelectedSolutionIndexes) {
                UpdateFrequency(Base, mSolutionHolder.Solutions[sel], frequency);
            }

            for (int i = 0; i < mInstance.NumberOfNodes; i++) {
                frequency[i] /= Base.CliqueForNode(i).Count* SelectedSolutionIndexes.Count;
            }

            return frequency;
        }

        public void UpdateEdgeFrequency(int[,] Occurence, CPPSolutionBase Base, CPPSolutionBase Update) {


            foreach (List<int> l in Base.Cliques) {

                for (int i = 0; i < l.Count; i++) {
                    for (int j = i+1; j < l.Count; j++)
                    {
                        if (Update.InSameClique(l[i], l[j]))
                            Occurence[l[i], l[j]]++;
                    }
                }
            }
        }

        public int[,] GetFrequencyEdge(int BaseSolutionIndex, List<int> SelectedSolutionIndexes)
        {

            CPPSolutionBase Base = mSolutionHolder.Solutions[BaseSolutionIndex];
            int[,] Occurance;

            Occurance = new int[mInstance.NumberOfNodes, mInstance.NumberOfNodes];

            for (int i = 0; i < mInstance.NumberOfNodes; i++) {
                for (int j = i+1; j < mInstance.NumberOfNodes; j++)
                {
                    Occurance[i, j] = 0;
                }
            }
            foreach (int sel in SelectedSolutionIndexes)
            {
                UpdateEdgeFrequency(Occurance, Base, mSolutionHolder.Solutions[sel]);
            }

        
            return Occurance;
        }


        public void UpdateFrequency(CPPSolutionBase Base, CPPSolutionBase Test, double[] frequency) {

            List<int> CurrentCliqueBase;
            int       CurrentNodeClique;
            
            for (int i = 0; i < mInstance.NumberOfNodes; i++) {

                CurrentCliqueBase = Base.CliqueForNode(i);
                CurrentNodeClique = Test.NodeClique[i];

                foreach (int n in CurrentCliqueBase) {
                    if (CurrentNodeClique == Test.NodeClique[n]) {
                        frequency[i]++;
                    }
                }
                
            }
        }

        public List<List<int>> GetFixEdge(int N, int K, double FixSize, List<List<int>> SuperNodes)
        {
            List<List<int>> resultCliques;
            int[,] Freq;
            int cNode;

            double[] w = new double[N];
            int tN = Math.Min(mSolutionHolder.Solutions.Count, N);
            int tK = Math.Min(mSolutionHolder.Solutions.Count, K);



            List<double[]> Elem = new List<double[]>();
            double[] TElem;


            for (int i = 0; i < tN; i++)
            {
                w[i] = ((double)1) / tN;
            }


            List<int> SelectSet = WeightedRadnomSampling.GetWeightedRadnomSampling(tN, tK, w, mGenerator);
            int BaseIndex = mGenerator.Next() % tN;

            if (!mSolutionHolder.Solutions[BaseIndex].CheckSolutionValid(mInstance))
            {
                cNode = 1;
            }


            Freq = GetFrequencyEdge(BaseIndex, SelectSet);

            if (!mSolutionHolder.Solutions[BaseIndex].CheckSolutionValid(mInstance))
            {
                cNode = 1;
            }

            List<int[]>[] Hold;
            int[] temp;
    
            Hold = new List<int[]>[tK+1];
            for (int i = 0; i < tK + 1; i++)
                Hold[i] = new List<int[]>();

            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                for (int j = i + 1; j < mInstance.NumberOfNodes; j++)
                {

                    if (Freq[i, j] > 0)
                    {
                        temp = new int[2];
                        temp[0] = i;
                        temp[1] = j;
                        Hold[Freq[i, j]].Add(temp);
                    }

                }
            }

            int[] tNodeClique = new int[mInstance.NumberOfNodes];
            int[] superNodeClique = new int[mInstance.NumberOfNodes];

            for (int i = 0; i < mInstance.NumberOfNodes; i++) {
                tNodeClique[i] = i;
            }

            int counter = (int)(FixSize * mInstance.NumberOfNodes -5);
            int size = 10;
            int ElemIndex =0;
            int[] tPair;
            bool Finish = false;
            int low;

            if (size >= Hold.Length)
                size = Hold.Length - 1;
            while (counter > 0) {

                while (ElemIndex < Hold[size].Count) {

                    tPair = Hold[size][ElemIndex];
                    if (tNodeClique[tPair[0]] != tNodeClique[tPair[1]]) {

                        if (tNodeClique[tPair[0]] < tNodeClique[tPair[1]])
                            low = tNodeClique[tPair[0]];
                        else
                            low = tNodeClique[tPair[1]];

                        counter--;
                        for(int j=0; j< mInstance.NumberOfNodes; j++)
                        {
                            if ((tNodeClique[j] == tNodeClique[tPair[1]]) || (tNodeClique[j] == tNodeClique[tPair[0]]))
                                tNodeClique[j] = low;
                        }


                        if (counter == 0)
                        {
                            Finish = true;
                            break;
                        }
                    }
                    ElemIndex++;
                }
                if (size == Hold.Length - 1) {
                    Array.Copy(tNodeClique, superNodeClique, mInstance.NumberOfNodes);
                }

                if (Finish)
                    break;
                size--;
                if (size == 0)
                    break;
                ElemIndex = 0;
            }

            List<int>[] CollectCliques = new List<int>[mInstance.NumberOfNodes];
            List<int>[] CollectSuperCliques = new List<int>[mInstance.NumberOfNodes];

            for (int i = 0; i < mInstance.NumberOfNodes; i++) {
                CollectCliques[i] = new List<int>();
                CollectSuperCliques[i] = new List<int>();
            }

            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                CollectCliques[tNodeClique[i]].Add(i);
                CollectSuperCliques[superNodeClique[i]].Add(i);

            }
            List<List<int>> Res = new List<List<int>>();

            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                if (CollectCliques[i].Count > 1)
                    Res.Add(CollectCliques[i]);

                if (CollectSuperCliques[i].Count > 1) {

                    if (!ContainsList(SuperNodes,CollectSuperCliques[i])) {
                        SuperNodes.Add(CollectSuperCliques[i]);
                    }
                    
                }
                    


            }



            return Res;
        }

        bool ContainsList(List<List<int>> Container, List<int> Test) {

            foreach (List<int> l in Container) {
                if (l.Count != Test.Count)
                    continue;
                if ((l.Except(Test).Any() || Test.Except(l).Any()))
                    continue;
                return true;
            }
            return false;
        }


        public List<List<int>> GetFix(int N, int K, double FixSize)
        {
            List<List<int>> resultCliques; 
            double[] Freq;
            int cNode;

            double[] w = new double[N];
            int tN = Math.Min(mSolutionHolder.Solutions.Count, N);
            int tK = Math.Min(mSolutionHolder.Solutions.Count, K);



            List<double[]> Elem = new List<double[]>();
            double[] TElem;


            for (int i = 0; i < tN; i++)
            {
                w[i] = ((double)1) / tN;
            }


            List<int> SelectSet = WeightedRadnomSampling.GetWeightedRadnomSampling(tN, tK, w, mGenerator);
            int tB = (int)Math.Min(tN, 10);
//            int BaseIndex = mGenerator.Next() % tN;
            int BaseIndex = mGenerator.Next() % tB;

            if (!mSolutionHolder.Solutions[BaseIndex].CheckSolutionValid(mInstance))
            {
                cNode = 1;
            }


            Freq = GetFrequency(BaseIndex, SelectSet);

            if (!mSolutionHolder.Solutions[BaseIndex].CheckSolutionValid(mInstance))
            {
                cNode = 1;
            }


            for (int i = 0; i < mInstance.NumberOfNodes; i++){
                            TElem = new double[2];
                            TElem[0] = i;
                            TElem[1] = Freq[i];
                            Elem.Add(TElem);
            }
             Elem = Elem.OrderBy(o => o[1]).ToList();
             Elem.Reverse();

/*
            for (int i = 0; i < FixSize * mInstance.NumberOfNodes; i++)
            {
                Result.Add((int)Elem[i][0]);
            }
*/
            resultCliques = new List<List<int>>();

            for (int i = 0; i < mSolutionHolder.Solutions[BaseIndex].Cliques.Count; i++) {
                resultCliques.Add(new List<int>());
            }


            List<int> T = new List<int>();

            for (int i = 0; i < FixSize * mInstance.NumberOfNodes; i++)
            {
                cNode = (int)Elem[i][0];
                resultCliques[mSolutionHolder.Solutions[BaseIndex].NodeClique[cNode]].Add(cNode);
                T.Add(cNode);
            }
            List<List<int>> cResultCliques = new List<List<int>>();

            foreach (List<int> l in resultCliques) {

                if (l.Count > 0) {
                    cResultCliques.Add(l);
                }
            }


            return cResultCliques;
        }


        void LogResult() {

            StreamWriter S = new StreamWriter(mLogFileName, true);

            S.WriteLine(mBestSolutionValue + " "+ mNumberOfSolutionsGenerated+ " " + mStopWatch.ElapsedMilliseconds);
            S.Close();

        }

        void LogString (string OutText)
        {

            StreamWriter S = new StreamWriter(mLogFileName, true);

            S.WriteLine(OutText);
            S.Close();

        }


      

        public void InitGreedy() {


            mSolution.Clear();
            InitAvailable(null);
            
        }

        public bool CheckBest()
        {

            int nValue = mSolution.CalculateObjective();
            if (nValue > mBestSolutionValue)
            {
                mBestSolutionValue = nValue;
                //mBestVertexCover = new List<int>(mSolution.CoverNodes);

                mIntermediateSolutions.Add(mBestSolutionValue);
                mIntermediateSolutionsIterations.Add(mNumberOfSolutionsGenerated);
                mIntermediateSolutionsTimes.Add(mStopWatch.ElapsedMilliseconds);
                LogResult();
                return true;
            }

            return false;

        }


        public void SolveFixSetSearch(double iTimeLimit, int MaxGenerated)
        {


            AllocateSolution();


            double[] w = new double[mFixN];
            double FixSize = 0.50;
            int cSolutionValue=0;
            double Accept;

            List<List<int>> FixSet;

            List<List<int>> FixSet1;

            for (int i = 0; i < mFixN; i++)
            {
                w[i] = ((double)1) / mFixN;
            }


            mStopWatch = new Stopwatch();
            mStopWatch.Start();
            InitTracking();

            SolveGRASP(mFixInitPopulation, iTimeLimit);

            int counter = 1;

            while (mInstance.NumberOfNodes / Math.Pow(2, counter) > 10)
            {

                counter++;
            }

            int MaxDiv = counter;
            int FixSetSizeIndex = 0;
            int StagCounter = 0;
            List<int> tt;
            List<List<int>> SuperNodes = new List<List<int>>();
            int cObj;
            for (int i = 0; i < MaxGenerated - mFixInitPopulation; i++)
            {

                if (mStopWatch.ElapsedMilliseconds > iTimeLimit * 1000)
                    break;

                FixSize = 1 - Math.Pow(2, -1 * (FixSetSizeIndex + 1));


                FixSet = GetFix(mFixN, mFixK, FixSize);
//              FixSet = GetFixEdge(mFixN, mFixK, FixSize, SuperNodes);

                SolveGreedy(FixSet);
                cObj = mSolution.CalculateObjective();


//               mSolution.LocalSearch(null);

                mSolution.LocalSearch(mGenerator, null);
                cObj = mSolution.CalculateObjective();
                mSolution.SimulatedAnealing(mGenerator, mSAInitTemperature, out Accept);
                cObj = mSolution.CalculateObjective();


                //      SuperNodes.Clear();
                //                mSolution.LocalSearch(FixSet);
                cObj = mSolution.CalculateObjective();
                if (!mSolution.CheckSolutionValid(mInstance))
                    cSolutionValue = cSolutionValue;


                mSolutionHolder.Add(mSolution);

                mNumberOfSolutionsGenerated++;
                if (!CheckBest())
                {
                    StagCounter++;
                    if (StagCounter >= mFixStagnation)
                    {

                        FixSetSizeIndex++;
                        FixSetSizeIndex %= MaxDiv;
                        StagCounter = 0;
                    }


                }
                else
                {
                    StagCounter = 0;
                }
            }

        }
        public void Calibrate(double iTimeLimit) {


            double Accept;
            double LT = 1;
            double UT = 2000;
            double Tolerate = 0.05;
            double DesiredAcceptance = 0.5;
            int    cSolutionValue;
            AllocateSolution();

            mBestSolutionValue = int.MinValue;

            mStopWatch = new Stopwatch();
            mStopWatch.Start();

            InitTracking();

            mSAInitTemperature = 1000;
            mNumberOfSolutionsGenerated = 0;
            while(true)
            {

                SolveGreedy();
                mSolution.CalibrateSA(mGenerator, mSAInitTemperature, out Accept);
                cSolutionValue = mSolution.CalculateObjective();
                mSolution.Objective = cSolutionValue;
                mSolutionHolder.Add(mSolution);
                CheckBest();


                if (Accept > DesiredAcceptance + Tolerate)
                {

                    UT = mSAInitTemperature;
                    mSAInitTemperature = (LT + UT) / 2;
                    continue;
                }

                if (Accept < DesiredAcceptance - Tolerate)
                {
                    LT = mSAInitTemperature;
                    mSAInitTemperature = (LT + UT) / 2;
                    continue;
                }
                break;

                if (mStopWatch.ElapsedMilliseconds > iTimeLimit * 1000)
                    break;


            }


        }


        public void SolveGRASP(int MaxIterations, double iTimeLimit) {
            int cSolutionValue;

            double Accept;
         

    
            for (int i = 0; i < MaxIterations; i++) {



                if (mStopWatch.ElapsedMilliseconds > iTimeLimit * 1000)
                    break;

                SolveGreedy();
                cSolutionValue = mSolution.CalculateObjective();
                mSolution.LocalSearch(mGenerator);
                cSolutionValue = mSolution.CalculateObjective();
                mSolution.SimulatedAnealing(mGenerator, mSAInitTemperature, out Accept);
       //         mSolution.SARestricted(mGenerator, mSAInitTemperature, out Accept);
                cSolutionValue = mSolution.CalculateObjective();
                mNumberOfSolutionsGenerated++;
                mSolutionHolder.Add(mSolution);
                CheckBest();
            }
        }

        public void SolveGreedy(List<List<int>> FixedSet= null) {


            CPPCandidate Select = null;
            InitGreedy();
            int i;
            List<int> T = new List<int>();
            int first;

            mSolution.InitChange();
            InitAvailable(FixedSet);



            while (true) {
              
                Select = GetHeuristic();
                if (Select == null)
                    break;
                AddToSolution(Select);
            }
            mSolution.FixCliques();
         
        }


        CPPCandidate GetHeuristicMaxIncrease()
        {
            int cValue;
            int Select; 
            if (mAvailableNodes.Count == 0)
                return null;
            
            mRCL = new RCL< CPPCandidate> (mRCLSize);

            //   shuffle(mAvalilableNodes);

            if (mSolution.Cliques.Count == 0) {

                Select = mGenerator.Next() % mAvailableNodes.Count;
                AddToSolution(new CPPCandidate(mAvailableNodes[Select], 0, Select));
            }

            int counter = 0;
            foreach (List<int> n in mAvailableNodes) {

                for(int c=0; c< mSolution.NumberOfCliques; c++) {

                    cValue = mSolution.GetChange(n, c);

                    mRCL.Add(new CPPCandidate(n, c,counter), cValue);
                }

                counter++;
            }

            if ((mRCL.MaxValue <= 0) || (mRCL.CurrentSize == 0))  {
                int index;
                index = mGenerator.Next() % mAvailableNodes.Count;
                return new CPPCandidate(mAvailableNodes[index], mSolution.NumberOfCliques, index);
            }

            return mRCL.GetCandidate(mGenerator.Next() % mRCL.CurrentSize);
        }
        CPPCandidate GetHeuristic() {

            switch (mGreedyHeuristic) {

                case GreedyHeuristicType.MaxIncrease:
                    return GetHeuristicMaxIncrease();
            }

            return null;
        }

        public bool AddToSolution(CPPCandidate N) {
            
            
            if(mGreedyHeuristic == GreedyHeuristicType.MaxIncrease)
                RemoveFromAvaillable(N);

            
            mSolution.AddCandidate(N);
            return true;
        
        }

        void RemoveFromAvaillable(CPPCandidate N) {

            mAvailableNodes.RemoveAt(N.mCandidateIndex);
        
        
        
        }
    }
}
