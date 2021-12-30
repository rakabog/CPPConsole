using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace CPP
{
    public enum SASelectType { Single, Dual, Triple };
    class CPPSolutionBase
    {
        protected List<List<int>> mCliques;
        protected List<int>       mCliqueSizes;

        protected int mObjective;
        protected int[] mNodeClique;
    //    protected int[][] mWeights;
        protected CPPInstance mInstance;
        int mMaxBuffer;
        int[][] mAllConnections;
        SASelectType mSASelectType;
        List<int> mRestricted;
        Random mGenerator;

        public SASelectType SASType
        {
            get { return mSASelectType; }
            set { mSASelectType = value; }
        }


        public Random Generator
        {
            get { return mGenerator; }
            set { mGenerator = value; }
        }

        public void InitRestricted(int Size)
        {

            mRestricted = new List<int>();

            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                mRestricted.Add(i);
            }

            CPPProblem.shuffle(mRestricted, mGenerator);

            mRestricted.RemoveRange(Size - 1, mInstance.NumberOfNodes - Size);

        }
        public virtual void Clear()
        {

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
        public void Load(string FileName)
        {

            string[] Lines = File.ReadAllLines(FileName);
            char[] sep = { ' ' };
            int[] iNodeCliques = new int[mInstance.NumberOfNodes];
            string[] words;

            List<List<int>> tCliques = new List<List<int>>();
            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                tCliques.Add(new List<int>());
            }

            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                words = Lines[i].Split(sep);
                tCliques[Convert.ToInt32(words[1])].Add(i);
            }

            mCliques = new List<List<int>>();

            foreach (List<int> l in tCliques)
            {

                if (l.Count > 0)
                {
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
        public virtual void FixCliques()
        {

        }

        public bool InSameClique(int nodeA, int nodeB)
        {

            return mNodeClique[nodeA] == mNodeClique[nodeB];
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
        public virtual int GetChange(int A, int B)
        {
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

        public virtual void AddCandidate(CPPCandidate A)
        {

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


        public List<int> CliqueForNode(int iNode)
        {

            return mCliques[mNodeClique[iNode]];
        }
        public CPPSolutionBase(CPPSolutionBase iSolution)
        {

            mObjective = iSolution.mObjective;
            mCliques = new List<List<int>>();
            foreach (List<int> l in iSolution.Cliques)
            {
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
        public bool IsSame(int iObjective, List<List<int>> iPartitions)
        {

            if (iObjective != mObjective)
                return false;
            if (iPartitions.Count != mCliques.Count)
                return false;

            int FirstClique;
            foreach (List<int> l in iPartitions)
            {
                if (l.Count == 0)
                    continue;

                FirstClique = mNodeClique[l[0]];
                foreach (int n in l)
                {

                    if (FirstClique != mNodeClique[n])
                        return false;
                }

            }



            return true;
        }


        int CalculateAllConnections(int node, int clique)
        {

            int result = 0;

            foreach (int tn in mCliques[clique])
            {

                result += mInstance.Weights[tn][node];
            }

            return result;
        }

        void UpdateAllConnections(int nNode, int nClique)
        {

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


            int[] newAllConnectedNode = mAllConnections[nClique];
            int[] oldAllConnectedNode = mAllConnections[mNodeClique[nNode]];

            int[] NodeWeigths = mInstance.Weights[nNode];
            int[] NodeNegativeWeigths = mInstance.NegativeWeights[nNode];


            //          HPCsharp.ParallelAlgorithms.Addition.AddToSsePar(newAllConnectedNode, NodeWeigths);
            //            HPCsharp.ParallelAlgorithms.Addition.AddToSsePar(oldAllConnectedNode, NodeNegativeWeigths);


            HPCsharp.ParallelAlgorithms.Addition.AddToSse(newAllConnectedNode, NodeWeigths);
            HPCsharp.ParallelAlgorithms.Addition.AddToSse(oldAllConnectedNode, NodeNegativeWeigths);



            /*       for (int tn = 0; (tn < NodeWeigths.Length) && (tn < newAllConnectedNode.Length) && (tn < oldAllConnectedNode.Length); tn++)
                   {

                       newAllConnectedNode[tn] += NodeWeigths[tn];
                       oldAllConnectedNode[tn] -= NodeWeigths[tn];


                   }
                   /**/
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

            foreach (int tn in mRestricted)
            {

                newAlllConnectedNode[tn] += NodeWeigths[tn];
                oldAlllConnectedNode[tn] -= NodeWeigths[tn];


            }


        }

        public void InitAllConnections()
        {

            mAllConnections = new int[mCliques.Count][];




            for (int c = 0; c < mCliques.Count; c++)
            {
                mAllConnections[c] = new int[mNodeClique.Length];

                for (int tn = 0; tn < mInstance.NumberOfNodes; tn++)
                {

                    mAllConnections[c][tn] = CalculateAllConnections(tn, c);
                }
            }
            mCliqueSizes = new List<int>();

            foreach (List<int> cClique in mCliques) {
                mCliqueSizes.Add(cClique.Count);
            }

        }

        void CreateRelocations(int n1, int n2, int n3, int c, List<int[]> BestRelocations)
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


            if ((mNodeClique[n1] == mNodeClique[n2]) && (mNodeClique[n2] == mNodeClique[n3]))
            {


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

            if ((mNodeClique[n1] != mNodeClique[n2]) && (mNodeClique[n2] != mNodeClique[n3]) && (mNodeClique[n1] != mNodeClique[n3]))
            {

                n1Clique = mNodeClique[n1];
                n2Clique = mNodeClique[n2];
                n3Clique = mNodeClique[n3];


                for (int c = 0; c < mCliques.Count; c++)
                {

                    if ((c != n1Clique) && (c != n2Clique) && (c != n3Clique))
                    {

                        cChange = mAllConnections[c][n1] + mAllConnections[c][n2] + mAllConnections[c][n3]
                                   + mInstance.Weights[n1][n2] + mInstance.Weights[n1][n3] + mInstance.Weights[n2][n3]
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
            else
            {
                if (mNodeClique[n1] == mNodeClique[n3])
                {
                    tN1 = n1;
                    tN2 = n3;
                    tN3 = n2;
                }
                else
                {
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
                               + 2 * mInstance.Weights[tN1][tN2] + mInstance.Weights[tN1][tN3] + mInstance.Weights[tN2][tN3]
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





        void SASelectDual(ref SARelocation Relocation)
        {

            int[] CliqueConnections;

            int n0Clique = mNodeClique[Relocation.mN0];
            int n1Clique = mNodeClique[Relocation.mN1];
            int n0RemoveChange;
            int n1RemoveChange;
            int RemoveChange;
            //-1 non2 0 -n0 1- n1  2-both
            int bWeight;
            int cChange0;
            int cChange1;
            int cChange;
            int swapChange;
            int Size = mCliqueSizes.Count;

            n0RemoveChange = -mAllConnections[n0Clique][Relocation.mN0];
            n1RemoveChange = -mAllConnections[n1Clique][Relocation.mN1];


              bWeight = mInstance.Weights[Relocation.mN0][Relocation.mN1];
//            bWeight = mInstance.mWeightsCopy[Relocation.mN0,Relocation.mN1];
//            bWeight = mWeights[Relocation.mN0][Relocation.mN1];


            if (n0RemoveChange < n1RemoveChange)
            {
                if (mCliqueSizes[n1Clique] > 1)
                {

                    Relocation.mChange = n1RemoveChange;
                    Relocation.mC1 = Size;
                    Relocation.mMoveType = SAMoveType.N1;
                }


            }
            else
            {


                if (mCliqueSizes[n0Clique] > 1)
                {
                    Relocation.mChange = n0RemoveChange;
                    Relocation.mC0 = Size;
                    Relocation.mMoveType = SAMoveType.N0;
                }

            }

            //           bWeight = mInstance.GetWeight(Relocation.mN0, Relocation.mN1);
            /**/

            for (int c = 0; c < Size; c++)
            {

                /**/
                CliqueConnections = mAllConnections[c];

                cChange0 = n0RemoveChange + CliqueConnections[Relocation.mN0];
                if (n0Clique != c)
                {
                    if (cChange0 > Relocation.mChange)
                    {

                        Relocation.mChange = cChange0;
                        Relocation.mC0 = c;
                        Relocation.mMoveType = SAMoveType.N0;
                        /*
                        relocateNode = 0;
                        relocateClique = c;
                        cBest = cChange0;
                        */
                    }
                }
                cChange1 = n1RemoveChange + CliqueConnections[Relocation.mN1];
                if (n1Clique != c)
                {
                    if (cChange1 > Relocation.mChange)
                    {

                        Relocation.mChange = cChange1;
                        Relocation.mC1 = c;
                        Relocation.mMoveType = SAMoveType.N1;


                        /*
                        relocateNode = 1;
                        relocateClique = c;
                        cBest = cChange1;
                        */
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
                        cChange = cChange1 + cChange0 + bWeight;
                        //                        cChange = int.MinValue;
                    }

                    if (cChange > Relocation.mChange)
                    {
                        /*
                        relocateNode = 2;
                        relocateClique = c;
                        cBest = cChange;
                        */

                        Relocation.mChange = cChange;
                        Relocation.mC0 = c;
                        Relocation.mC1 = c;
                        Relocation.mMoveType = SAMoveType.Both;
                    }

                }

            }


            if (n1Clique != n0Clique )
            {
                

                swapChange = n0RemoveChange + n1RemoveChange + mAllConnections[n0Clique][Relocation.mN1] + mAllConnections[n1Clique][Relocation.mN0] - 2 * bWeight;
                if (swapChange > Relocation.mChange)
                {
                    Relocation.mChange = swapChange;
                    Relocation.mMoveType = SAMoveType.Swap;
                }
            }

            n0RemoveChange += n1RemoveChange;


            if (n1Clique == n0Clique)
            {
          
                //                if (cBest < RemoveChange + 2 * bWeight)
                if (Relocation.mChange < n0RemoveChange + 2 * bWeight)
                {
                    Relocation.mChange = n0RemoveChange + 2 * bWeight;
                    Relocation.mC0 = Size;
                    Relocation.mC1 = Size;
                    Relocation.mMoveType = SAMoveType.Both;
                }

            }
            else
            {
       
                if (Relocation.mChange < n0RemoveChange + bWeight)
                //                    if (cBest < RemoveChange + bWeight)
                {

                    Relocation.mChange = n0RemoveChange + bWeight;
                    Relocation.mC0 = Size;
                    Relocation.mC1 = Size;
                    Relocation.mMoveType = SAMoveType.Both;
                }

            }


        }


        void SASelectDualExt(ref SARelocation Relocation)
        {

            int[] CliqueConnections;

            int n0Clique = mNodeClique[Relocation.mN0];
            int n1Clique = mNodeClique[Relocation.mN1];
            int n0RemoveChange;
            int n1RemoveChange;
            int RemoveChange;
            //-1 non2 0 -n0 1- n1  2-both
            int bWeight;
            int cChange0;
            int cChange1;
            int cChange;
            int swapChange;
            int Size = mCliqueSizes.Count;

            n0RemoveChange = -mAllConnections[n0Clique][Relocation.mN0];
            n1RemoveChange = -mAllConnections[n1Clique][Relocation.mN1];


            bWeight = mInstance.Weights[Relocation.mN0][Relocation.mN1];
            //            bWeight = mInstance.mWeightsCopy[Relocation.mN0,Relocation.mN1];
            //            bWeight = mWeights[Relocation.mN0][Relocation.mN1];


            if (n0RemoveChange < n1RemoveChange)
            {
                if (mCliqueSizes[n1Clique] > 1)
                {

                    Relocation.mChange = n1RemoveChange;
                    Relocation.mC1 = Size;
                    Relocation.mMoveType = SAMoveType.N1;
                }


            }
            else
            {


                if (mCliqueSizes[n0Clique] > 1)
                {
                    Relocation.mChange = n0RemoveChange;
                    Relocation.mC0 = Size;
                    Relocation.mMoveType = SAMoveType.N0;
                }

            }

            //           bWeight = mInstance.GetWeight(Relocation.mN0, Relocation.mN1);
            /**/

            for (int c = 0; c < Size; c++)
            {

                /**/
                CliqueConnections = mAllConnections[c];

                cChange0 = n0RemoveChange + CliqueConnections[Relocation.mN0];

                if (n0Clique != c)
                {
                    if (cChange0 > Relocation.mChange)
                    {

                        Relocation.mChange = cChange0;
                        Relocation.mC0 = c;
                        Relocation.mMoveType = SAMoveType.N0;
                        /*
                        relocateNode = 0;
                        relocateClique = c;
                        cBest = cChange0;
                        */
                    }

                


                }
                cChange1 = n1RemoveChange + CliqueConnections[Relocation.mN1];


                if (n1Clique != c)
                {
                    if (cChange1 > Relocation.mChange)
                    {

                        Relocation.mChange = cChange1;
                        Relocation.mC1 = c;
                        Relocation.mMoveType = SAMoveType.N1;


                        /*
                        relocateNode = 1;
                        relocateClique = c;
                        cBest = cChange1;
                        */
                    }
                }
                // edge

                if ((n1Clique != c) && (n0Clique != c))
                {

                    if (n1Clique == n0Clique)
                    {

                        cChange = cChange1 + cChange0 + 2 * bWeight;
                        //     cChange = int.MinValue;
                    }
                    else
                    {
                        cChange = cChange1 + cChange0 + bWeight;
                        //                        cChange = int.MinValue;
                    }

                    if (cChange > Relocation.mChange)
                    {
                        /*
                        relocateNode = 2;
                        relocateClique = c;
                        cBest = cChange;
                        */

                        Relocation.mChange = cChange;
                        Relocation.mC0 = c;
                        Relocation.mC1 = c;
                        Relocation.mMoveType = SAMoveType.Both;
                    }

                }

                //slide
                if (n0Clique != n1Clique)
                {
                    if (c != n0Clique)
                    {
                        if (c != n1Clique)
                        {
                            cChange = cChange0 + n1RemoveChange + mAllConnections[n0Clique][Relocation.mN1] - bWeight;
                        }
                        else
                        {

                            cChange = cChange0 + n1RemoveChange + mAllConnections[n0Clique][Relocation.mN1] - 2 * bWeight;
                        }

                        if (cChange > Relocation.mChange)
                        {

                            Relocation.mChange = cChange;
                            Relocation.mC0 = c;
                            Relocation.mC1 = n0Clique;
                            Relocation.mMoveType = SAMoveType.Slide;
                        }
                    }

                    if (c != n1Clique)
                    {
                        if (c != n0Clique)
                        {
                            cChange = cChange1 + n0RemoveChange + mAllConnections[n1Clique][Relocation.mN0] - bWeight;
                        }
                        else
                        {

                            cChange = cChange1 + n0RemoveChange + mAllConnections[n1Clique][Relocation.mN0] - 2 * bWeight;
                        }

                        if (cChange > Relocation.mChange)
                        {

                            Relocation.mChange = cChange;
                            Relocation.mC0 = n1Clique;
                            Relocation.mC1 = c;
                            Relocation.mMoveType = SAMoveType.Slide;
                        }

                    }

                }
                /*
                
               
              /*  */





            }


            if (n1Clique != n0Clique)
            {


                swapChange = n0RemoveChange + n1RemoveChange + mAllConnections[n0Clique][Relocation.mN1] + mAllConnections[n1Clique][Relocation.mN0] - 2 * bWeight;
                if (swapChange > Relocation.mChange)
                {
                    Relocation.mChange = swapChange;
                    Relocation.mMoveType = SAMoveType.Swap;
                }
            }

            n0RemoveChange += n1RemoveChange;


            if (n1Clique == n0Clique)
            {

                //                if (cBest < RemoveChange + 2 * bWeight)
                if (Relocation.mChange < n0RemoveChange + 2 * bWeight)
                {
                    Relocation.mChange = n0RemoveChange + 2 * bWeight;
                    Relocation.mC0 = Size;
                    Relocation.mC1 = Size;
                    Relocation.mMoveType = SAMoveType.Both;
                }

            }
            else
            {

                if (Relocation.mChange < n0RemoveChange + bWeight)
                //                    if (cBest < RemoveChange + bWeight)
                {

                    Relocation.mChange = n0RemoveChange + bWeight;
                    Relocation.mC0 = Size;
                    Relocation.mC1 = Size;
                    Relocation.mMoveType = SAMoveType.Both;
                }

            }


        }

        void SASelectSingle(ref SARelocation Relocation)
        {

            int[] CliqueConnections;

            int n0Clique = mNodeClique[Relocation.mN0];
            int n0RemoveChange;
            //-1 non2 0 -n0 1- n1  2-both
            int cChange0;
            int Size = mCliqueSizes.Count;

            n0RemoveChange = -mAllConnections[n0Clique][Relocation.mN0];



           


            if (mCliqueSizes[n0Clique] > 1)
            {
                Relocation.mChange = n0RemoveChange;
                Relocation.mC0 = Size;
                Relocation.mMoveType = SAMoveType.N0;
            }

           


            for (int c = 0; c < Size; c++)
            {

                /**/
                CliqueConnections = mAllConnections[c];

                cChange0 = n0RemoveChange + CliqueConnections[Relocation.mN0];
                if (n0Clique != c)
                {
                    if (cChange0 > Relocation.mChange)
                    {

                        Relocation.mChange = cChange0;
                        Relocation.mC0 = c;
                        Relocation.mMoveType = SAMoveType.N0;
                
                    }
                }
                
                

            }


           


        }


        /*

        void SASelectSingle(ref SARelocation Relocation)
        {

            int[] CliqueConnections;

            int n0Clique = mNodeClique[Relocation.mN0];
            int n0RemoveChange;
            //-1 non2 0 -n0 1- n1  2-both
            int Size = mCliques.Count;
            int cChange0;    
            n0RemoveChange = -mAllConnections[n0Clique][Relocation.mN0];


            Relocation.mChange = n0RemoveChange;
            Relocation.mC1 = Size;
            Relocation.mMoveType = SAMoveType.N0;



           
            for (int c = 0; c < Size; c++)
            {

              
                CliqueConnections = mAllConnections[c];

                cChange0 = n0RemoveChange + CliqueConnections[Relocation.mN0];
                if (n0Clique != c)
                {
                    if (cChange0 > Relocation.mChange)
                    {

                        Relocation.mChange = cChange0;
                        Relocation.mC0 = c;
                        Relocation.mMoveType = SAMoveType.N0;
                       
                    }
                }
                
            }


        }
        */



        void SASelectDual(ref SARelocation Relocation, Random iGenerator)
        {
            int n0, n1;



            n0 = iGenerator.Next() % mInstance.NumberOfNodes;

            while (true)
            {

                n1 = iGenerator.Next() % mInstance.NumberOfNodes;
                if (n0 != n1)
                    break;
            }
            Relocation.mN0 = n0;
            Relocation.mN1 = n1;
            //            int bWeight = mInstance.Weights[Relocation.mN0][Relocation.mN1];

//            SASelectDualExt(ref Relocation);
              SASelectDual(ref Relocation);





        }


        void SASelectSingle(ref SARelocation Relocation, Random iGenerator)
        {
            int n0, n1;



            n0 = iGenerator.Next() % mInstance.NumberOfNodes;

         
            Relocation.mN0 = n0;
            //            int bWeight = mInstance.Weights[Relocation.mN0][Relocation.mN1];

            SASelectSingle(ref Relocation);





        }







        public void SASelect(ref SARelocation Relocations, Random iGenerator)
        {

            switch (mSASelectType)
            {

                case SASelectType.Single:
                                 SASelectSingle(ref Relocations, iGenerator);
                                 break;
                case SASelectType.Dual:
                    SASelectDual(ref Relocations, iGenerator);
                    break;
                //                case SASelectType.Triple:
                //                    SimulatedAnnealingSelectTrio(out cBestChange, cBestRelocation, iGenerator);
                //                    break;
                default:
                    SASelectDual(ref Relocations, iGenerator);
                    //                    SimulatedAnnealingSelectSimple(out cBestChange, cBestRelocation, iGenerator);
                    break;
            }
        }


        void ApplyRelocation(SARelocation Relocation)
        {

            switch (Relocation.mMoveType)
            {

                case SAMoveType.N0:

                    UpdateAllConnections(Relocation.mN0, Relocation.mC0);
                    MoveNodeSA(Relocation.mN0, Relocation.mC0);
//                    MoveNode(Relocation.mN0, Relocation.mC0);

                    break;
                case SAMoveType.N1:
                    UpdateAllConnections(Relocation.mN1, Relocation.mC1);
//                    MoveNode(Relocation.mN1, Relocation.mC1);
                    MoveNodeSA(Relocation.mN1, Relocation.mC1);
                    break;
                case SAMoveType.Both:

                    UpdateAllConnections(Relocation.mN0, Relocation.mC0);
//                    MoveNode(Relocation.mN0, Relocation.mC0);
                    MoveNodeSA(Relocation.mN0, Relocation.mC0);
                    UpdateAllConnections(Relocation.mN1, Relocation.mC1);
//                    MoveNode(Relocation.mN1, Relocation.mC1);
                    MoveNodeSA(Relocation.mN1, Relocation.mC1);
                    break;
                case SAMoveType.Swap:
                    int oldC0 = mNodeClique[Relocation.mN0];
                    UpdateAllConnections(Relocation.mN0, mNodeClique[Relocation.mN1]);
//                    MoveNode(Relocation.mN0, mNodeClique[Relocation.mN1]);
                    MoveNodeSA(Relocation.mN0, mNodeClique[Relocation.mN1]);
                    UpdateAllConnections(Relocation.mN1, oldC0);
//                    MoveNode(Relocation.mN1, oldC0);
                    MoveNodeSA(Relocation.mN1, oldC0);
                    break;
                case SAMoveType.Slide:
                    UpdateAllConnections(Relocation.mN0, Relocation.mC0);
                    //                    MoveNode(Relocation.mN0, Relocation.mC0);
                    MoveNodeSA(Relocation.mN0, Relocation.mC0);
                    UpdateAllConnections(Relocation.mN1, Relocation.mC1);
                    //                    MoveNode(Relocation.mN1, Relocation.mC1);
                    MoveNodeSA(Relocation.mN1, Relocation.mC1);
                    break;
            }

            while (RemoveEmptyCliqueSA(true,true)) ;
        }

        public bool SimulatedAnealing(Random iGenerator, SAParameters iSAParameters, out double AcceptRelative)
        {

            int NeiborhoodSize = mInstance.NumberOfNodes * NumberOfCliques;
            int n;
            double Prob;
            double T = 1;
            int BestSol = int.MinValue;
            int cSol = int.MinValue;
            int[] tNodeClique = new int[mInstance.NumberOfNodes];
            int StartObjective = CalculateObjective();
            int cSolObjective;
            int Accept;
            int AcceptTotal;
            int Stag = 0;
            int counter = 0;
            int[] NodesChange = new int[mInstance.NumberOfNodes];
            SARelocation cRelocation = new SARelocation();
            int waste =0;

            InitAllConnections();
            Array.Copy(mNodeClique, tNodeClique, mInstance.NumberOfNodes);

            T = iSAParameters.mInitTemperature;

            
            int counterCool = 0;
            cSolObjective = StartObjective;
            AcceptTotal = 0;
            int sumNodeChange;
            while (true)
            {
                counter++;
                Accept = 0;

                waste = 0;
                for (int i = 0; i < NeiborhoodSize * iSAParameters.mSizeRepeat; i++)
                {
                    cRelocation.mChange = int.MinValue;

                    SASelect(ref cRelocation, iGenerator);

                    //                    Prob = Math.Exp(cBestChange / T);
                    Prob = FastExp(cRelocation.mChange / T);

                    if (Prob * 1000 > 1 + iGenerator.Next() % 1000)
                    {
                        Accept++;
                     
                        ApplyRelocation(cRelocation);

//                        CreateFromNodeClique(mNodeClique);

//                        cSol = CalculateObjective();
                        cSolObjective += cRelocation.mChange;
                        if (cSol != cSolObjective)
                            cSol = cSol;

                        if (BestSol < cSolObjective)
                        {
                            BestSol = cSolObjective;
                            Array.Copy(mNodeClique, tNodeClique, mInstance.NumberOfNodes);
                        }

                    }
                }


                counterCool++;

                if (iSAParameters.mCooling == CPPProblem.CPPCooling.Geometric)
                {
                    T *= iSAParameters.mCoolingParam;
                }
                if (iSAParameters.mCooling == CPPProblem.CPPCooling.LinearMultiplicative) {

                    T = iSAParameters.mInitTemperature *  1 / (1 + iSAParameters.mCoolingParam * counterCool);
                }

              
               


                if ((double)Accept / (NeiborhoodSize * iSAParameters.mSizeRepeat) < iSAParameters.mMinAccept)
                {

                    Stag++;
                }
                else
                {
                    Stag = 0;
                }

                if (Stag >= 5)
                    break;

                if (T < 0.0005)
                    break;
            }


 //           if (StartObjective < BestSol)
 //           {
                CreateFromNodeClique(tNodeClique);
//            }

//            Console.WriteLine("Cool counter " + counterCool);

            AcceptRelative = ((double)AcceptTotal) / (NeiborhoodSize * iSAParameters.mSizeRepeat * counter);
            return true;
        }


        public bool CalibrateSA(Random iGenerator, SAParameters iSAParameters, out double Accept)
        {

            int MaxStep = mInstance.NumberOfNodes * NumberOfCliques *iSAParameters.mSizeRepeat;
            int n;
            double Prob;
            double T = 1;
            int BestSol = int.MinValue;
            int cSol = int.MinValue;
            int[] tNodeClique = new int[mInstance.NumberOfNodes];
            int StartObjective = CalculateObjective();
            int cSolObjective;
            int NoImprove = 0;
            Accept = 0;
            SARelocation Relocation = new SARelocation();

            InitAllConnections();
            Array.Copy(mNodeClique, tNodeClique, mInstance.NumberOfNodes);

            cSolObjective = StartObjective;
            for (int i = 0; i < MaxStep; i++)
            {
                NoImprove++;

                Relocation.mChange = int.MinValue;
                //                cBestChange = int.MinValue;
                SASelect(ref Relocation, iGenerator);
                T = iSAParameters.mInitTemperature;

                //                Prob = Math.Exp(cBestChange / T);
                Prob = Math.Exp(Relocation.mChange / T);

                if (Prob * 1000 > iGenerator.Next() % 1000)
                {
                    Accept++;

                    ApplyRelocation(Relocation);
                    
                    cSolObjective += Relocation.mChange;
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

//            if (StartObjective < BestSol)
//            {
                CreateFromNodeClique(tNodeClique);
//            }

            Accept = Accept / MaxStep;
            return true;
        }




        public static double FastExp(double x)
        {
            var tmp = (long)(1512775 * x + 1072632447);
            return BitConverter.Int64BitsToDouble(tmp << 32);
        }

        
        int CalculateMoveChange(List<int> iNodes, int iClique)
        {

            int Remove = 0;
            int Add = 0;
            int counter = 0;
            foreach (int n1 in iNodes)
            {
                counter++;
                foreach (int n2 in iNodes.Skip(counter))
                {
                    if (InSameClique(n1, n2))
                    {
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
                            Add += mInstance.Weights[n1][n2];
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
                foreach (int[] r2 in Set.mRelocations.Skip(counter))
                {
                    if (InSameClique(r1[0], r2[0]))
                    {
                        Remove += mInstance.Weights[r1[0]][r2[0]];
                    }

                    if (r1[1] == r2[1])
                        Add += mInstance.Weights[r1[0]][r2[0]];
                }

            }

            foreach (int[] r1 in Set.mRelocations)
            {
                foreach (int n2 in mCliques[mNodeClique[r1[0]]])
                {
                    if (!Set.Contains(n2))
                    {
                        Remove += mInstance.Weights[r1[0]][n2];
                    }


                }
            }


            foreach (int[] r1 in Set.mRelocations)
            {
                if (r1[1] < mCliques.Count)
                {

                    foreach (int n in mCliques[r1[1]])
                    {

                        if (!Set.Contains(n))
                        {
                            Add += mInstance.Weights[r1[0]][n];
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
            if (mCliques.Count <= NewClique)
            {
                mCliques.Add(new List<int>());
            }
            if (mCliques[NewClique] == null)
                mCliques[NewClique] = new List<int>();
            mCliques[NewClique].Add(iNode);

            return true;


        }

        bool MoveNodeSA(int iNode, int NewClique)
        {

            mCliqueSizes[mNodeClique[iNode]]--;

            mNodeClique[iNode] = NewClique;
            if (mCliqueSizes.Count <= NewClique)
            {
                mCliqueSizes.Add(1);
            }
            else {

                mCliqueSizes[NewClique]++;
            }

            return true;


        }


        public bool RemoveEmptyClique(bool bUpdateAllConections = false, bool bUseCliqueSize=false)

        {

            for (int i = 0; i < mCliques.Count; i++)
            {

                if (mCliques[i].Count == 0)
                {

                    mCliques.RemoveAt(i);

                    if(bUseCliqueSize)
                    mCliqueSizes.RemoveAt(i);
                    

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


        public bool RemoveEmptyCliqueSA(bool bUpdateAllConections = false, bool bUseCliqueSize = false)

        {

            for (int i = 0; i < mCliqueSizes.Count; i++)
            {

                if (mCliqueSizes[i] == 0)
                {


                    if (bUseCliqueSize)
                        mCliqueSizes.RemoveAt(i);


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

        bool ImproveMove(List<List<int>> Nodes)
        {

            List<int> shuffleCliques = new List<int>();
            int change;
            int c;
            shuffleCliques = new List<int>();

            for (int i = 0; i <= mCliques.Count; i++)
            {
                shuffleCliques.Add(i);
            }

            CPPProblem.shuffle(shuffleCliques, mGenerator);

            foreach (List<int> l in Nodes)
            {
                for (int tc = 0; tc < mCliques.Count; tc++)
                {
                    c = shuffleCliques[tc];

                    change = CalculateMoveChange(l, c);



                    if (change > 0)
                    {
                        int Objective1;
                        int Objective2;

                        Objective1 = CalculateObjective();
                        foreach (int n in l)
                        {
                            if (mNodeClique[n] != c)
                            {
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

            CPPProblem.shuffle(shuffleNodes, mGenerator);

            shuffleCliques = new List<int>();
            for (int i = 0; i < mCliques.Count; i++)
            {
                shuffleCliques.Add(i);
            }

            CPPProblem.shuffle(shuffleCliques, mGenerator);
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
        public void ExpandedBuffer(List<BufferElement> AllTest, int iNode, int iClique, int oClique)
        {

            List<BufferElement> newAllTest = new List<BufferElement>();
            int[] temp;
            BufferElement tBufferElement;

            foreach (BufferElement CurrentSet in AllTest)
            {

                if (CurrentSet.CanAdd(iNode, iClique))
                {
                    tBufferElement = new BufferElement(CurrentSet);
                    tBufferElement.Add(iNode, iClique, oClique);
                    newAllTest.Add(tBufferElement);
                }
            }

            foreach (BufferElement cSet in newAllTest)
            {

                AllTest.Add(cSet);
            }

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

                    OldA += mInstance.Weights[n][A];
                    NewB += mInstance.Weights[n][B];
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
        public void CreateFromNodeClique(int[] iNodeClique)
        {

            mNodeClique = new int[iNodeClique.Length];
            Array.Copy(iNodeClique, mNodeClique, iNodeClique.Length);

            mCliques = new List<List<int>>();
            int iNumCliques = -1;
            for (int i = 0; i < mNodeClique.Length; i++)
            {
                if (iNumCliques < mNodeClique[i] + 1)
                    iNumCliques = mNodeClique[i] + 1;

            }

            for (int i = 0; i < iNumCliques; i++)
            {

                mCliques.Add(new List<int>());

            }

            for (int i = 0; i < mNodeClique.Length; i++)
            {

                mCliques[mNodeClique[i]].Add(i);
            }

        }

    }
}
