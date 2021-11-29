using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HPCsharp;
namespace CPP
{
    public enum SASelectType { Simple, Dual, Triple};
    class CPPSolutionBase
    {
        protected List<List<int>> mCliques;
        protected int mObjective;
        protected int[] mNodeClique;
        protected CPPInstance mInstance;
        int mMaxBuffer;
        int[][] mAllConnections;
        SASelectType mSASelectType;
        List<int>    mRestricted;   

        public SASelectType SASType{
            get { return mSASelectType; }
            set { mSASelectType = value; }
        }


        public void InitRestricted(int Size) {

            mRestricted = new List<int>();

            for (int  i=0; i < mInstance.NumberOfNodes; i++) {
                mRestricted.Add(i);
            }

            CPPProblem.shuffle(mRestricted);

            mRestricted.RemoveRange(Size - 1, mInstance.NumberOfNodes - Size);

        }
        public virtual void Clear() {
        
        }


        public virtual void InitChange()
        {
        }

        public virtual int NumberOfCliques
        {
            get { return mCliques.Count; }
        }

        public virtual bool CheckSolutionValid()
        {

            return CheckSolutionValid(mInstance);
        }
        public void Load(string FileName) {

            string[] Lines = File.ReadAllLines(FileName);
            char[] sep = { ' ' };
            int[] iNodeCliques = new int[mInstance.NumberOfNodes];
            string[] words;

            List<List<int>> tCliques = new List<List<int>>();
            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                tCliques.Add(new List<int>());
            }

                for (int i = 0; i < mInstance.NumberOfNodes; i++) {
                words = Lines[i].Split(sep);
                tCliques[Convert.ToInt32(words[1])].Add(i);
            }

            mCliques = new List<List<int>>();

            foreach (List<int> l in tCliques) {

                if (l.Count > 0) {
                    mCliques.Add(l);
                }
            }

            int result = CalculateObjective();
        }
        public virtual int CalculateObjectiveForClique(List<int> Clique)
        {

            int result = 0;
            foreach (int i in Clique)
            {
                foreach (int j in Clique)
                {
                    if (i > j)
                        result += mInstance.Weights[i][j];

                }

            }

            return result;

        }
        public virtual void FixCliques() { 
        
        }

        public bool InSameClique(int nodeA, int nodeB) { 
        
               return mNodeClique[nodeA]  == mNodeClique[nodeB];
        }

        public virtual int CalculateObjective()
        {

            int result = 0;

            foreach (List<int> Clique in mCliques)
            {

                result += CalculateObjectiveForClique(Clique);
            }

            return result;

        }
        public virtual int GetChange(int A, int B) {
            return -1;
        
        }

        public virtual int GetChange(List<int> A, int B)
        {
            return -1;

        }



        public virtual int Objective
        {
            get { return mObjective; }
            set { mObjective = value; }
        }
        public List<List<int>> Cliques
        {
            get { return mCliques; }
        }

        public int[] NodeClique
        {
            get { return mNodeClique; } 
        }

        public virtual void AddCandidate(CPPCandidate A) {

/*
            if (CPPCandidateMaxIncrease.Equals(this.GetType())) { 
            
                
            }
*/
        }

        public CPPSolutionBase()
        {

            mCliques = new List<List<int>>();
        }

        public bool CheckSolutionValid(CPPInstance tInstance)
        {

            int TotalNodes;
            List<int> AllNodes = new List<int>();
            TotalNodes = 0;

            foreach (List<int> Cli in mCliques)
            {
                TotalNodes += Cli.Count;
                AllNodes.AddRange(Cli);
            }

            AllNodes.Sort();
            for (int i = 0; i < AllNodes.Count - 1; i++)
            {
                if (AllNodes[i] == AllNodes[i + 1])
                    return false;
            }
            if (TotalNodes != tInstance.NumberOfNodes)
                return false;

            for (int i = 0; i < tInstance.NumberOfNodes; i++)
            {
                if (!mCliques[mNodeClique[i]].Contains(i))
                    return false;
            }


            return true;
        }


        public List<int> CliqueForNode(int iNode) {

            return mCliques[mNodeClique[iNode]];
        } 
        public CPPSolutionBase(CPPSolutionBase iSolution) {

            mObjective = iSolution.mObjective;
            mCliques = new List<List<int>>();
            foreach (List<int> l in iSolution.Cliques) {
                mCliques.Add(new List<int>(l));
            }
            mNodeClique = new int[iSolution.mNodeClique.Length];
            Array.Copy(iSolution.mNodeClique, mNodeClique, mNodeClique.Length);
//            mCliques = mCliques.OrderBy(o => o.Count).ToList();
        }

        public CPPSolutionBase(int iObjective, List<List<int>> iPartitions)
        {

            mObjective = iObjective;
            mCliques = iPartitions;
        }
        /*
        public bool IsWorse(int iObjective ) {

            return mObjective < iObjective;
        }
        */
        public bool IsSame(int iObjective, List<List<int>> iPartitions) {

            if (iObjective != mObjective)
                return false;
            if (iPartitions.Count != mCliques.Count)
                return false;

            int FirstClique;
            foreach (List<int> l in iPartitions) {
                if (l.Count == 0)
                    continue;
                
                FirstClique = mNodeClique[l[0]];
                foreach (int n in l) {

                    if (FirstClique != mNodeClique[n])
                        return false;
                }
            
            }

           

            return true;
        }


        int CalculateAllConnections(int node, int clique) {

            int result=0;

            foreach (int tn in mCliques[clique]) {

                result += mInstance.Weights[tn][node];
            }

            return result;    
        }

        void UpdateAllConnections(int nNode, int nClique) {

            if (nClique >= mAllConnections.Length) {
                int[][] nAllConnections;

                nAllConnections = new int[mAllConnections.Length + 1][];
                nAllConnections[nClique] = new int[mNodeClique.Length];
                Array.Fill(nAllConnections[nClique], 0);

                for (int i = 0; i < mAllConnections.Length; i++) {

                    nAllConnections[i] = mAllConnections[i];
                }

                mAllConnections = nAllConnections;
            }


            int[] newAllConnectedNode = mAllConnections[nClique];
            int[] oldAllConnectedNode = mAllConnections[mNodeClique[nNode]];

            int[] NodeWeigths = mInstance.Weights[nNode];
            int[] NodeNegativeWeigths = mInstance.NegativeWeights[nNode];
            int Size;

            Size = mInstance.NumberOfNodes;

            HPCsharp.ParallelAlgorithms.Addition.AddToSse(newAllConnectedNode, NodeWeigths);
            HPCsharp.ParallelAlgorithms.Addition.AddToSse(oldAllConnectedNode, NodeNegativeWeigths);

            /*
            for (int tn = 0; tn < Size; tn++)
            {

                newAllConnectedNode[tn] += NodeWeigths[tn];
                oldAllConnectedNode[tn] -= NodeWeigths[tn];


            }
            */
        }


        void UpdateAllConnectionsRestricted(int nNodeIndex, int nClique)
        {

            int nNode = mRestricted[nNodeIndex];

            if (nClique >= mAllConnections.Length)
            {
                int[][] nAllConnections;

                nAllConnections = new int[mAllConnections.Length + 1][];
                nAllConnections[nClique] = new int[mNodeClique.Length];
                Array.Fill(nAllConnections[nClique], 0);

                for (int i = 0; i < mAllConnections.Length; i++)
                {

                    nAllConnections[i] = mAllConnections[i];
                }

                mAllConnections = nAllConnections;
            }


            int[] newAlllConnectedNode = mAllConnections[nClique];
            int[] oldAlllConnectedNode = mAllConnections[mNodeClique[nNode]];

            int[] NodeWeigths = mInstance.Weights[nNode];
            int Size;

            Size = mInstance.NumberOfNodes;

            foreach (int tn in mRestricted) {

                newAlllConnectedNode[tn] += NodeWeigths[tn];
                oldAlllConnectedNode[tn] -= NodeWeigths[tn];


            }


        }

        public void InitAllConnections() {

            mAllConnections = new int[mCliques.Count][];




            for (int c = 0; c < mCliques.Count; c++)
            {
                mAllConnections[c] = new int[mNodeClique.Length];

                for (int tn = 0; tn < mInstance.NumberOfNodes; tn++)
                {

                    mAllConnections[c][tn] = CalculateAllConnections(tn, c);
                }
            }


        }

        void CreateRelocations(int n1, int n2, int n3, int c, List<int[]> BestRelocations) {
            int[] temp;

            BestRelocations.Clear();
            temp = new int[2];
            temp[0] = n1;
            temp[1] = c;

            BestRelocations.Add(temp);

            temp = new int[2];
            temp[0] = n2;
            temp[1] = c;

            BestRelocations.Add(temp);

            temp = new int[2];
            temp[0] = n3;
            temp[1] = c;

            BestRelocations.Add(temp);
        }

        void CreateRelocations(int n1, int n2, int c, List<int[]> BestRelocations)
        {
            int[] temp;

            BestRelocations.Clear();
            temp = new int[2];
            temp[0] = n1;
            temp[1] = c;

            BestRelocations.Add(temp);

            temp = new int[2];
            temp[0] = n2;
            temp[1] = c;

            BestRelocations.Add(temp);

        }
        void SimulatedAnnealingSelectTrio(int n1, int n2, int n3, ref int BestChange, List<int[]> BestRelocations, Random iGenerator)
        {
            int n1Clique, n2Clique, n3Clique;
            int cChange;
            
            
            if ((mNodeClique[n1] == mNodeClique[n2]) && (mNodeClique[n2] == mNodeClique[n3])) {


                n1Clique = mNodeClique[n1];
                for (int c = 0; c < mCliques.Count; c++)
                {
                    if (c != n1Clique)
                    {

                        cChange = mAllConnections[c][n1] + mAllConnections[c][n2] + mAllConnections[c][n3] 
                                   + 2 * mInstance.Weights[n1][n2] + 2 * mInstance.Weights[n1][n3] + 2 * mInstance.Weights[n2][n3]
                                   - mAllConnections[n1Clique][n1] - mAllConnections[n1Clique][n2] - mAllConnections[n1Clique][n3];


                        if (cChange > BestChange)
                        {
                            BestChange = cChange;

                            CreateRelocations(n1, n2, n3, c, BestRelocations);
                        }
                    }
                }

                return;
            }
           
            if ((mNodeClique[n1] != mNodeClique[n2]) && (mNodeClique[n2] != mNodeClique[n3]) && (mNodeClique[n1] != mNodeClique[n3])) {

                n1Clique = mNodeClique[n1];
                n2Clique = mNodeClique[n2];
                n3Clique = mNodeClique[n3];


                for (int c = 0; c < mCliques.Count; c++)
                {

                    if ((c != n1Clique) && (c != n2Clique) && (c != n3Clique))
                    {

                        cChange = mAllConnections[c][n1] + mAllConnections[c][n2] + mAllConnections[c][n3]
                                   + mInstance.Weights[n1][n2] +  mInstance.Weights[n1][n3] +  mInstance.Weights[n2][n3]
                                   - mAllConnections[n1Clique][n1] - mAllConnections[n2Clique][n2] - mAllConnections[n3Clique][n3];


                        if (cChange > BestChange)
                        {
                            BestChange = cChange;

                            CreateRelocations(n1, n2, n3, c, BestRelocations);
                        }
                    }
                }

                return;
            }

            
            int tN1, tN2, tN3;

            if (mNodeClique[n1] == mNodeClique[n2])
            {
                tN1 = n1;
                tN2 = n2;
                tN3 = n3;
            }
            else {
                if (mNodeClique[n1] == mNodeClique[n3])
                {
                    tN1 = n1;
                    tN2 = n3;
                    tN3 = n2;
                }
                else {
                    tN1 = n2;
                    tN2 = n3;
                    tN3 = n1;
                }
            }

            n1Clique = mNodeClique[tN1];
            n3Clique = mNodeClique[tN3];


            for (int c = 0; c < mCliques.Count; c++)
            {

                if ((c != n1Clique) && (c != n3Clique))
                {

                    cChange = mAllConnections[c][tN1] + mAllConnections[c][tN2] + mAllConnections[c][tN3]
                               + 2*mInstance.Weights[tN1][tN2] + mInstance.Weights[tN1][tN3] + mInstance.Weights[tN2][tN3]
                               - mAllConnections[n1Clique][tN1] - mAllConnections[n1Clique][tN2] - mAllConnections[n3Clique][tN3];


                    if (cChange > BestChange)
                    {
                        BestChange = cChange;

                        CreateRelocations(n1, n2, n3, c, BestRelocations);
                    }
                }
            }
          /*  */

        }





        void SimulatedAnnealingSelectDual(int n0, int n1, ref int BestChange, List<int[]> BestRelocations) {

            int[] CliqueConnections;

            int n0Clique = mNodeClique[n0];
            int n1Clique = mNodeClique[n1];
            int n0RemoveChange;
            int n1RemoveChange;
            int RemoveChange;
            //-1 non2 0 -n0 1- n1  2-both
            int relocateNode;
            int relocateClique;
            int cBest;
            int bWeight;
            int cChange0;
            int cChange1;
            int cChange;
            int[] temp;
            int swapChange;

            n0RemoveChange = -mAllConnections[n0Clique][n0];
            n1RemoveChange = -mAllConnections[n1Clique][n1];
            bWeight = mInstance.Weights[n0][n1];

            RemoveChange = n0RemoveChange + n1RemoveChange;
            
            if (n0RemoveChange < n1RemoveChange)
            {

                relocateNode = 1;
                relocateClique = mCliques.Count;
                cBest = n1RemoveChange;


            }
            else {

                relocateNode = 0;
                relocateClique = mCliques.Count;
                cBest = n0RemoveChange;
            }

            if (n1Clique == n0Clique)
            {
                if (cBest < RemoveChange + 2 * bWeight)
                {
                    relocateNode = 2;
                    relocateClique = mCliques.Count;
                    cBest = RemoveChange +2* bWeight;
                }
                
            }
            else
            {
                if (cBest < RemoveChange + bWeight)
                {
                    relocateNode = 2;
                    relocateClique = mCliques.Count;
                    cBest = RemoveChange + bWeight;
                }

            }
            /**/

            for (int c = 0; c < mCliques.Count; c++) {


                CliqueConnections = mAllConnections[c];

                    cChange0 = n0RemoveChange + CliqueConnections[n0];
                if (n0Clique != c)
                {
                    if (cChange0 > cBest)
                    {

                        relocateNode = 0;
                        relocateClique = c;
                        cBest = cChange0;
                    }
                }
                    cChange1 = n1RemoveChange + CliqueConnections[n1];
                if (n1Clique != c)
                {
                    if (cChange1 > cBest)
                    {

                        relocateNode = 1;
                        relocateClique = c;
                        cBest = cChange1;
                    }
                }
               
                if ((n1Clique != c) && (n0Clique != c))
                {

                    if (n1Clique == n0Clique)
                    {

                        cChange = cChange1 + cChange0 + 2 * bWeight;
                   //     cChange = int.MinValue;
                    }
                    else
                    {
                        cChange = cChange1 + cChange0+ bWeight;
//                        cChange = int.MinValue;
                    }

                    if (cChange > cBest)
                    {

                        relocateNode = 2;
                        relocateClique = c;
                        cBest = cChange;
                        
                    }
                }
       
            }


            if (n1Clique != n0Clique)
            {
                swapChange = n0RemoveChange + n1RemoveChange + mAllConnections[n0Clique][n1] + mAllConnections[n1Clique][n0] - 2 * bWeight;

                if (swapChange > cBest)
                {

                    BestRelocations.Clear();
                    BestChange = swapChange;

                    temp = new int[2];
                    temp[0] = n0;
                    temp[1] = n1Clique;

                    BestRelocations.Add(temp);

                    temp = new int[2];
                    temp[0] = n1;
                    temp[1] = n0Clique;
                    BestRelocations.Add(temp);

                    return;

                }
            }

            if (cBest > BestChange) 
            {

                BestRelocations.Clear();
                BestChange = cBest;
                if (relocateNode == 0)
                {
                    temp = new int[2];
                    temp[0] = n0;
                    temp[1] = relocateClique;
                    BestRelocations.Add(temp);

                }
                else
                {
                    if (relocateNode == 1)
                    {
                        temp = new int[2];
                        temp[0] = n1;
                        temp[1] = relocateClique;
                        BestRelocations.Add(temp);


                    }
                    else
                    {
                        temp = new int[2];
                        temp[0] = n0;
                        temp[1] = relocateClique;

                        BestRelocations.Add(temp);

                        temp = new int[2];
                        temp[0] = n1;
                        temp[1] = relocateClique;
                        BestRelocations.Add(temp);
                    }
                }
            }
        }

     




        void SimulatedAnnealingSelectDual(out int BestChange, List<int[]> BestRelocations, Random iGenerator)
        {
            int n1, n2;

            BestChange = int.MinValue;

            n1 = iGenerator.Next() % mInstance.NumberOfNodes;
            
//          SimulatedAnnealingSelectSimple(n1, ref BestChange, BestRelocations, iGenerator);

            while (true) {

                n2 = iGenerator.Next() % mInstance.NumberOfNodes;
                if(n1 != n2)
                    break;
            }
            
  //         SimulatedAnnealingSelectSimple(n2, ref BestChange, BestRelocations, iGenerator);

//            SimulatedAnnealingSelectDual(n1, n2, ref BestChange, BestRelocations, iGenerator);

               SimulatedAnnealingSelectDual(n1, n2, ref BestChange, BestRelocations);
            //   return;




        }



        void SimulatedAnnealingSelectSimple(out int BestChange, List<int[]> BestRelocations, Random iGenerator)
        {
            int n;

            BestChange = int.MinValue;
            n = iGenerator.Next() % mInstance.NumberOfNodes;
            SimulatedAnnealingSelectSimple(n, ref BestChange, BestRelocations, iGenerator);
        }

       

        void SimulatedAnnealingSelectTrio(out int BestChange, List<int[]> BestRelocations, Random iGenerator)
        {
            int n1, n2, n3;

            n1 = iGenerator.Next() % mInstance.NumberOfNodes;
            while (true) { 
            
                n2 = iGenerator.Next() % mInstance.NumberOfNodes;
                if (n1 != n2)
                       break;
            }

            while (true)
            {

                n3 = iGenerator.Next() % mInstance.NumberOfNodes;
                if ((n1 != n3) && (n2 != n3))
                    break;
                
            }



            BestChange = int.MinValue;
            
            SimulatedAnnealingSelectSimple(n1, ref BestChange, BestRelocations, iGenerator);
            SimulatedAnnealingSelectSimple(n2, ref BestChange, BestRelocations, iGenerator);
            SimulatedAnnealingSelectSimple(n3, ref BestChange, BestRelocations, iGenerator);


            SimulatedAnnealingSelectDual(n1,n2, ref BestChange, BestRelocations);
            SimulatedAnnealingSelectDual(n1, n3, ref BestChange, BestRelocations);
            SimulatedAnnealingSelectDual(n2, n3, ref BestChange, BestRelocations);

            SimulatedAnnealingSelectTrio(n1, n2, n3, ref BestChange, BestRelocations, iGenerator);



        }



        void SimulatedAnnealingSelectSimple(int n, ref int BestChange, List<int[]> BestRelocations, Random iGenerator) {


            
            
            int cRemoveChange;
            int cChangeRelocate;
            int[] BestReloc;
            int   bestClique;
            cRemoveChange = mAllConnections[mNodeClique[n]][n];
            

            if ((BestChange < -cRemoveChange))
            
            {

                BestChange = -cRemoveChange;
                BestReloc = new int[2];

                BestRelocations.Clear();
                BestReloc[0] = n;
                BestReloc[1] = mCliques.Count;
                BestRelocations.Add(BestReloc);
            }

            for (int c = 0; c < mCliques.Count; c++)
            {

                if (c != mNodeClique[n])
                {
//                    cChangeRelocate = mAllConnections[c][n] - mAllConnections[mNodeClique[n]][n];
                    cChangeRelocate = mAllConnections[c][n] - cRemoveChange;
                    if (BestChange < cChangeRelocate)
                    {
                        BestReloc = new int[2];
                        BestReloc[0] = n;
                        BestReloc[1] = c;
                        BestChange = cChangeRelocate;

                        BestRelocations.Clear();
                        BestRelocations.Add(BestReloc);

                    }
                }
            }

           

        }

        public void SASelect(out int cBestChange, List<int[]> cBestRelocation, Random iGenerator) {

            switch (mSASelectType) {

                case SASelectType.Simple:
                    SimulatedAnnealingSelectSimple(out cBestChange, cBestRelocation,iGenerator);
                    break;
                case SASelectType.Dual:
                    SimulatedAnnealingSelectDual(out cBestChange, cBestRelocation, iGenerator);
                    break;
                case SASelectType.Triple:
                    SimulatedAnnealingSelectTrio(out cBestChange, cBestRelocation, iGenerator);
                    break;
                default:
                    SimulatedAnnealingSelectSimple(out cBestChange, cBestRelocation, iGenerator);
                    break;
            }
        }

  
        public bool SimulatedAnealing(Random iGenerator, double InitTemperature, out double AcceptRelative)
        {

            int SizeSARepeat = 16;
            int NeiborhoodSize = mInstance.NumberOfNodes * NumberOfCliques;
            double MinAccept = 0.01;
            double SACool = 0.95;
            int n;
            double Prob;
            double T = 1;
            int BestSol = int.MinValue;
            int cSol = int.MinValue;
            int[] tNodeClique = new int[mInstance.NumberOfNodes];
            int StartObjective = CalculateObjective();
            int cSolObjective;
            int NoImprove = 0;
            int cBestChange;
           List<int[]> cBestRelocation = new List<int[]>();
            int  Accept = 0;
            int AcceptTotal = 0;
            int Stag = 0;
            int counter = 0;
            InitAllConnections();

            T = InitTemperature;


            cSolObjective = StartObjective;
            AcceptTotal = 0;
            while (true) {
                counter++;
                Accept = 0;
                
                for (int i = 0; i < NeiborhoodSize * SizeSARepeat; i++) {
                    cBestChange = int.MinValue;


                    SASelect(out cBestChange, cBestRelocation, iGenerator);
//                      SimulatedAnnealingSelectSimple(out cBestChange, cBestRelocation, iGenerator);
  //                  SimulatedAnnealingSelectDual(out cBestChange, cBestRelocation, iGenerator);
//                                SimulatedAnnealingSelectTrio(out cBestChange, cBestRelocation, iGenerator);

//                    Prob = Math.Exp(cBestChange / T);
                    Prob = FastExp(cBestChange / T);

                    if (Prob * 1000 > 1+ iGenerator.Next() % 1000)
                    {
                        Accept++;
                        foreach (int[] t in cBestRelocation)
                        {

                            UpdateAllConnections(t[0], t[1]);
                            MoveNode(t[0], t[1]);

                        }
                        while (RemoveEmptyClique(true)) ;
                        
//                        cSol = CalculateObjective();
                        cSolObjective += cBestChange;
                        if (cSol != cSolObjective)
                            cSol = cSol;

                        if (BestSol < cSolObjective)
                        {
                            NoImprove = 0;
                            BestSol = cSolObjective;
                            Array.Copy(mNodeClique, tNodeClique, mInstance.NumberOfNodes);
                        }

                    }
                }

                T *= SACool;

                if ((double)Accept / (NeiborhoodSize * SizeSARepeat) < MinAccept) {

                    Stag++;
                }
                else {
                    Stag = 0;
                }

                if (Stag >= 5)
                    break;

                if (T < 0.0005)
                    break;
            }


            if (StartObjective < BestSol)
            {
                CreateFromNodeClique(tNodeClique);
            }


            AcceptRelative =((double) AcceptTotal) / (NeiborhoodSize * SizeSARepeat * counter);
            return true;
        }


        public bool CalibrateSA(Random iGenerator, double InitTemperature, out double Accept)
        {

            int MaxStep = mInstance.NumberOfNodes * NumberOfCliques*20;
            int n;
            double Prob;
            double T = 1;
            int BestSol = int.MinValue;
            int cSol = int.MinValue;
            int[] tNodeClique = new int[mInstance.NumberOfNodes];
            int StartObjective = CalculateObjective();
            int cSolObjective;
            int NoImprove = 0;
            int cBestChange;
            List<int[]> cBestRelocation = new List<int[]>();
            Accept = 0;

            InitAllConnections();


            cSolObjective = StartObjective;
            for (int i = 0; i < MaxStep; i++)
            {
                NoImprove++;

                cBestChange = int.MinValue;
                SASelect(out cBestChange, cBestRelocation, iGenerator);
                T = InitTemperature;

                Prob = Math.Exp(cBestChange / T);

                if (Prob * 1000 > iGenerator.Next() % 1000)
                {
                    Accept++;
                    foreach (int[] t in cBestRelocation)
                    {

                        UpdateAllConnections(t[0], t[1]);
                        MoveNode(t[0], t[1]);
                        

                    }
                    while (RemoveEmptyClique(true)) ;

//                    cSol = CalculateObjective();
                    cSolObjective += cBestChange;
                    if (cSol != cSolObjective)
                        cSol = cSol;

                    if (BestSol < cSolObjective)
                    {
                        NoImprove = 0;
                        BestSol = cSolObjective;
                        Array.Copy(mNodeClique, tNodeClique, mInstance.NumberOfNodes);
                    }

                }
            }

            if (StartObjective < BestSol)
            {
                CreateFromNodeClique(tNodeClique);
            }

            Accept = Accept / MaxStep;
            return true;
        }




        public static double FastExp(double x)
        {
            var tmp = (long)(1512775 * x + 1072632447);
            return BitConverter.Int64BitsToDouble(tmp << 32);
        }


        public bool SimulatedAnealing1(Random iGenerator, double InitTemperature, out double Accept) {

            int MaxStep = mInstance.NumberOfNodes *NumberOfCliques*200;
            int n;
            double Prob1;
            double Prob;
            double T = 1;
            int BestSol = int.MinValue;
            int cSol = int.MinValue;
            int[] tNodeClique = new int[mInstance.NumberOfNodes];
            int StartObjective = CalculateObjective();
            int cSolObjective;
            int NoImprove = 0;
            int cBestChange;
            List<int[]> cBestRelocation = new List<int[]>();
            int checkClique;
            Accept = 0;

            InitAllConnections();
          
             
            cSolObjective = StartObjective;
            for (int i = 0; i < MaxStep; i++) {
                NoImprove++;

                cBestChange = int.MinValue;

                SASelect(out cBestChange, cBestRelocation, iGenerator);

                T = InitTemperature * (1 - (i + 1) / (double)MaxStep);
                Prob = FastExp(cBestChange / T);

                if (Prob * 1000 >1+ iGenerator.Next() % 1000) {
                    Accept++;
                    foreach (int[] t in cBestRelocation) {
                     
                        UpdateAllConnections(t[0], t[1]);
                        MoveNode(t[0], t[1]);

                    }
                    while (RemoveEmptyClique(true)) ;
                    cSol = CalculateObjective();
                    cSolObjective += cBestChange;
                    if (cSol != cSolObjective)
                        cSol = cSol;

                    if (BestSol < cSolObjective)
                    {
                        NoImprove = 0;
                        BestSol = cSolObjective;
                        Array.Copy(mNodeClique, tNodeClique, mInstance.NumberOfNodes);
                    }

                }
            }

            if (StartObjective < BestSol) {
                CreateFromNodeClique(tNodeClique);
            }

            Accept = Accept / MaxStep;
            return true;
        }

        int CalculateMoveChange(List<int> iNodes, int iClique) {

            int Remove = 0;
            int Add = 0;
            int counter = 0;
            foreach (int n1 in iNodes) {
                counter++;
                foreach (int n2 in iNodes.Skip(counter))
                {
                    if (InSameClique(n1, n2)) {
                        Remove += mInstance.Weights[n1][n2];
                    }
                    Add += mInstance.Weights[n1][n2];
                }
                
            }

            foreach (int n1 in iNodes)
            {
                foreach (int n2 in mCliques[mNodeClique[n1]])
                {
                    if (!iNodes.Contains(n2))
                    {
                        Remove += mInstance.Weights[n1][n2];
                    }

                   
                }
            }
            if (iClique < mCliques.Count)
            {
                foreach (int n1 in iNodes)
                {
                    foreach (int n2 in mCliques[iClique])
                    {

                        if (!iNodes.Contains(n2))
                        {
                            Add += mInstance.Weights[n1][ n2];
                        }
                    }

                }
            }
            
            return Add - Remove;
        }


        int CalculateMoveChange(BufferElement Set)
        {

            int Remove = 0;
            int Add = 0;
            int counter = 0;


            foreach (int[] r1 in Set.mRelocations)
            {
                counter++;
                foreach(int[] r2 in Set.mRelocations.Skip(counter))
                {
                    if (InSameClique(r1[0], r2[0]))
                    {
                        Remove += mInstance.Weights[r1[0]][r2[0]];
                    }

                    if(r1[1] == r2[1])
                          Add += mInstance.Weights[r1[0]][ r2[0]];
                }

            }

            foreach (int[] r1 in Set.mRelocations)
            {
                foreach (int n2 in mCliques[mNodeClique[r1[0]]])
                {
                    if (!Set.Contains(n2))
                    {
                        Remove += mInstance.Weights[r1[0]][ n2];
                    }


                }
            }


            foreach (int[] r1 in Set.mRelocations)
            {
                if (r1[1] < mCliques.Count) {

                    foreach (int n in mCliques[r1[1]]) {

                        if (!Set.Contains(n)) { 
                            Add += mInstance.Weights[r1[0]][ n];
                        }
                    }
                }

            }

            return Add - Remove;
        }


        int CalculateMoveChange(int iNode, int iClique, int iNodeRemoveChange = int.MinValue)
        {

            int result;
            if (mNodeClique[iNode] == iClique)
                return 0;

            if (iNodeRemoveChange != int.MinValue)
            {
                result = iNodeRemoveChange;
            }
            else
            {
                result = CalculateRemoveChange(iNode);
            }
            if (iClique >= mCliques.Count)
                return -result;

            result = CalculateAddChange(iNode, iClique) - result;

            return result;
        }

        bool CheckMove(int iNode, int iClique, int iNodeRemoveChange = int.MinValue)
        {

            return CalculateMoveChange(iNode, iClique, iNodeRemoveChange) > 0;
        }

        bool MoveNode(int iNode, int NewClique)
        {

            mCliques[mNodeClique[iNode]].Remove(iNode);

            mNodeClique[iNode] = NewClique;
            if (mCliques.Count <= NewClique) {
                mCliques.Add(new List<int>());
            }
            if (mCliques[NewClique] == null)
                mCliques[NewClique] = new List<int>();
            mCliques[NewClique].Add(iNode);

            return true;


        }
        public bool RemoveEmptyClique(bool bUpdateAllConections = false)
        {

            for (int i = 0; i < mCliques.Count; i++)
            {

                if (mCliques[i].Count == 0)
                {

                    mCliques.RemoveAt(i);
                    for (int j = 0; j < mNodeClique.Length; j++)
                    {
                        if (mNodeClique[j] > i)
                            mNodeClique[j]--;
                    }
                    if (bUpdateAllConections)
                    {
                        int[][] nAllConnections = new int[mAllConnections.Length - 1][];

                        int counter = 0;
                        for (int ii = 0; ii < mAllConnections.Length; ii++)
                        {
                            if (ii != i)
                                nAllConnections[counter++] = mAllConnections[ii];

                        }

                        mAllConnections = nAllConnections;
                    }
                    return true;
                }
            }

            return false;
        }

      
        public virtual bool LocalSearch(Random iGenerator, List<List<int>> Nodes = null)
        {

            List<BufferElement> currentBuffer = new List<BufferElement>();
            int counter = 0;
            bool Result = false;

            InitAllConnections();
            while (true)
            {
//              if (!ImproveMoveExt(currentBuffer, iGenerator)) 
                if (!ImproveMove())
                {
                       if (Nodes == null)
                            return Result;
                       if (!ImproveMove(Nodes))
                            return Result;

                }
                RemoveEmptyClique();
                Result = true;
                counter++;
            }
        }

        bool ImproveMove(List<List<int>> Nodes) {

            List<int> shuffleCliques = new List<int>();
            int change;
            int c;
            shuffleCliques = new List<int>();

            for (int i = 0; i <= mCliques.Count; i++)
            {
                shuffleCliques.Add(i);
            }

            CPPProblem.shuffle(shuffleCliques);

            foreach (List<int> l in Nodes) {
                for (int tc = 0; tc < mCliques.Count; tc++)
                {
                    c = shuffleCliques[tc];

                    change =  CalculateMoveChange(l, c);

                    

                    if (change > 0) {
                        int Objective1;
                        int Objective2;

                        Objective1 = CalculateObjective();
                        foreach (int n in l) {
                            if (mNodeClique[n] != c) {
                                MoveNode(n, c);
                            }
                        }

                        Objective2 = CalculateObjective();
                        return true;
                    }
                
                }
            }



            return false;
        }
        bool ImproveMove()
        {

            int cRemoveChange;
            int cChangeRelocate;
            List<int> shuffleNodes = new List<int>();
            List<int> shuffleCliques = new List<int>();

            shuffleNodes = new List<int>();
            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {

                shuffleNodes.Add(i);
            }

            CPPProblem.shuffle(shuffleNodes);

            shuffleCliques = new List<int>();
            for (int i = 0; i < mCliques.Count; i++)
            {
                shuffleCliques.Add(i);
            }

            CPPProblem.shuffle(shuffleCliques);
            int n;
            int c;

            
          





            


            for (int tn = 0; tn < mInstance.NumberOfNodes; tn++)
            {

                n = shuffleNodes[tn];

                 cRemoveChange = mAllConnections[mNodeClique[n]][n];



                for (int tc = 0; tc < mCliques.Count; tc++)
                {

                    c = shuffleCliques[tc];
                    if (mNodeClique[n] != c)
                    {

                        cChangeRelocate = mAllConnections[c][n] - mAllConnections[mNodeClique[n]][n];

                        if (cChangeRelocate > 0)
                        {
                            UpdateAllConnections(n, c);
                            MoveNode(n, c);
                            RemoveEmptyClique(true);

                            return true;

                        }
                        
                    }
                }

                if (cRemoveChange < 0)
                {
                    

                    UpdateAllConnections(n, mCliques.Count);
                    MoveNode(n, mCliques.Count);
                    RemoveEmptyClique(true);
                    return true;
                }

            }


            return false;
        }
        public void ExpandedBuffer(List<BufferElement> AllTest, int iNode, int iClique, int oClique) {

            List<BufferElement> newAllTest = new List<BufferElement>();
            int[] temp;
            BufferElement tBufferElement;

            foreach (BufferElement CurrentSet in AllTest) {

                if (CurrentSet.CanAdd(iNode,iClique)) {
                    tBufferElement = new BufferElement(CurrentSet);
                    tBufferElement.Add(iNode, iClique,oClique);
                    newAllTest.Add(tBufferElement);
                }
            }

            foreach (BufferElement cSet in newAllTest) {

                AllTest.Add(cSet);
            }
                     
        }

        
        bool ImproveMoveExt(List<BufferElement> currentBuffer, Random iGenerator)
        {

            int removeChange;
            List<int> shuffleNodes = new List<int>();
            List<int> shuffleCliques = new List<int>();
            
            int[] InitTest;
            BufferElement tempSet;

            currentBuffer.Add(new BufferElement(mInstance.NumberOfNodes));
            
            


            mMaxBuffer = 1000;

            shuffleNodes = new List<int>();
            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {

                shuffleNodes.Add(i);
            }

            CPPProblem.shuffle(shuffleNodes);

            shuffleCliques = new List<int>();
            for (int i = 0; i < mCliques.Count; i++)
            {
                shuffleCliques.Add(i);
            }

            CPPProblem.shuffle(shuffleCliques);
            int n;
            int c;

            List<int[]> Bad = new List<int[]>();
            int[] tempBad;

            for (int tn = 0; tn < mInstance.NumberOfNodes; tn++)
            {

                n = shuffleNodes[tn];

                removeChange = CalculateRemoveChange(n);
                for (int tc = 0; tc < mCliques.Count; tc++)
                {

                    c = shuffleCliques[tc];
                    if (mNodeClique[n] != c)
                    {
                        if (CheckMove(n, c, removeChange))
                        {

                            ExpandedBuffer(currentBuffer, n, c, mNodeClique[n]);
                        }
/*                        else {

                            tempBad = new int[3];
                            tempBad[0] = n;
                            tempBad[1] = c;
                            tempBad[2] = CalculateMoveChange(n, c, removeChange);
                            Bad.Add(tempBad);
                        }
*/
                    }

                    if (currentBuffer.Count > mMaxBuffer)
                        break;
                }

                if (removeChange < 0)
                {
                    if (CheckMove(n, mCliques.Count))
                    {

                        ExpandedBuffer(currentBuffer, n, mCliques.Count, mNodeClique[n]);
                    }
                }
                else {
              /*      tempBad = new int[3];
                    tempBad[0] = n;
                    tempBad[1] = mCliques.Count;
                    tempBad[2] = removeChange;
                    Bad.Add(tempBad);
              */
                }

                if (currentBuffer.Count > mMaxBuffer)
                    break;


            }


            int NewObjective;
            int ReturnObjective;
            int[] tempR;
            int SumComb;
            int MaxIncrease = 0;
            BufferElement MaxSet = null;
            List<BufferElement> tBuffers;

        /*    if (currentBuffer.Count < mMaxBuffer) {

                Bad = Bad.OrderBy(o => o[2]).ToList();
                Bad.Reverse();
                foreach(int[] t in Bad){

                    if (iGenerator.NextDouble() > 0.5) {
                        ExpandedBuffer(currentBuffer,t[0], t[1], mNodeClique[t[0]]);
                    }

                    if (currentBuffer.Count > mMaxBuffer)
                        break;
                }
            }
        */
            foreach (BufferElement cSet in currentBuffer)
            {


                SumComb = CalculateMoveChange(cSet);
                if (MaxIncrease < SumComb)
                {

                    MaxIncrease = SumComb;
                    MaxSet = cSet;
                }
            }

            if (MaxSet == null)
                return false;

//            tBuffers =  MaxSet.SplitIndependet();
            
            foreach (int[] r in MaxSet.mRelocations)
            {
                MoveNode(r[0], r[1]);
            }
            /**/
            
            /*
            int[] Selected = MaxSet.TakeRandomRelocation(iGenerator);

            MoveNode(Selected[0], Selected[1]);

            if (MaxSet.mRelocations.Count > 0)
                currentBuffer.Add(MaxSet);
            List<BufferElement> nBuffer = new List<BufferElement>();

            foreach (BufferElement b in currentBuffer) {

                if (!b.HasRelocation(Selected)) {

                    if (CalculateMoveChange(b) > 0)
                        nBuffer.Add(b);
                }
            }

            */
            currentBuffer.Clear();

    //        currentBuffer.Add(new BufferElement(mInstance.NumberOfNodes));
            /*foreach (BufferElement b in nBuffer)
            {

                currentBuffer.Add(b);
            }
            
            
            /**/
            //            
            return true;


            return false;
        }



        public int CalculateSwap(int A, List<int> CliqueA, int B, List<int> CliqueB)
        {

            int result = 0;
            int NewA = 0;
            int NewB = 0;
            int OldA = 0;
            int OldB = 0;

            foreach (int n in CliqueA)
            {
                if (n != A)
                {

                    OldA += mInstance.Weights[n][ A];
                    NewB += mInstance.Weights[n][ B];
                }
            }

            foreach (int n in CliqueB)
            {
                if (n != B)
                {

                    OldB += mInstance.Weights[n][B];
                    NewA += mInstance.Weights[n][A];
                }
            }

            return NewA + NewB - OldA - OldB;
        }

        public bool ImproveSwap()
        {

            int ocA, ocB;

            List<int> shuffleCliques = new List<int>();
            List<int> AClique, BClique;


            shuffleCliques = new List<int>();
            for (int i = 0; i < mCliques.Count; i++)
            {
                shuffleCliques.Add(i);
            }

            CPPProblem.shuffle(shuffleCliques);



            foreach (int AC in shuffleCliques)
            {
                foreach (int BC in shuffleCliques)
                {
                    if (AC != BC)
                    {
                        AClique = mCliques[AC];
                        BClique = mCliques[BC];

                        foreach (int A in AClique)
                        {
                            foreach (int B in BClique)
                            {
                                if (CalculateSwap(A, AClique, B, BClique) > 0)
                                {

                                    ocA = mNodeClique[A];
                                    ocB = mNodeClique[B];
                                    MoveNode(A, ocB);
                                    MoveNode(B, ocA);

                                    return true;
                                }
                            }
                        }

                    }
                }
            }

            return false;
        }

        public int CalculateRemoveChange(int iNode)
        {

            int result = 0;

            foreach (int tNode in mCliques[mNodeClique[iNode]])
            {
                result += mInstance.Weights[iNode][tNode];
            }

            return result;
        }

        public int CalculateAddChange(int iNode, int iClique)
        {

            int result = mInstance.Weights[iNode][iNode];

            foreach (int tNode in mCliques[iClique])
            {
                result += mInstance.Weights[iNode][tNode];
            }

            return result;

        }
        public void CreateFromNodeClique(int[] iNodeClique) {

            mNodeClique = new int[iNodeClique.Length];
            Array.Copy(iNodeClique, mNodeClique, iNodeClique.Length);

            mCliques = new List<List<int>>();
            int iNumCliques = -1;
            for (int i = 0; i < mNodeClique.Length; i++) {
                if (iNumCliques < mNodeClique[i]+1)
                    iNumCliques = mNodeClique[i] + 1;

            }

            for (int i = 0; i < iNumCliques; i++) {

                mCliques.Add(new List<int>());

            }

            for (int i = 0; i < mNodeClique.Length; i++) {

                mCliques[mNodeClique[i]].Add(i);
            }
        
        }

    }
}
