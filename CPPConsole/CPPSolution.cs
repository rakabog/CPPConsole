using System;
using System.Collections.Generic;

namespace CPP
{
    class CPPSolutionMaxIncrease : CPPSolutionBase
    {

        int[][] mChange;
        public static int[][] EmptyChange;

        public static void Init(int size)
        {


            EmptyChange = new int[size][];
            for (int i = 0; i < size; i++)
            {

                EmptyChange[i] = new int[size];

                Array.Fill(EmptyChange[i], 0);

            }

        }


        public override int Objective
        {
            get { return CalculateObjective(); }
        }


        public override void FixCliques()
        {

        }

        public override void InitChange()
        {
            /*
            int[,] Old = new int[mInstance.NumberOfNodes, mInstance.NumberOfNodes];
            

            for (int c = 0; c < mInstance.NumberOfNodes; c++)
            {
                for (int n = 0; n < mInstance.NumberOfNodes; n++)
                {
                    mChange[c, n] = 0;
                }
            }
            */

            for (int c = 0; c < mInstance.NumberOfNodes; c++)
            {
                Array.Copy(CPPSolutionMaxIncrease.EmptyChange[c], mChange[c], mInstance.NumberOfNodes);
            }

        }

        public override void AddCandidate(CPPCandidate A)
        {

            AddNodeToClique(A);
        }

        public override int GetChange(int iNode, int iClique)
        {

            if (iClique >= mCliques.Count)
                return 0;

            return mChange[iClique][iNode];
        }

        public override int GetChange(List<int> nodes, int iClique)
        {

            int result = 0;

            return GetChange(nodes[0], iClique);
            /*   int result = 0;

               if (iClique >= mCliques.Count)
                   return 0;

               foreach (int nnode in nodes)
               {
                   foreach (int cnode in mCliques[iClique])
                   {
                       result += mInstance.Weights[nnode][cnode];

                   }


               }


               return result;
            */
        }






        public void UpdateChange(int Clique, int Node)
        {
            int[] cArrClique = mChange[Clique];
            int[] cArrNode = mInstance.Weights[Node];
            for (int n = 0; n < mInstance.NumberOfNodes; n++)
            {

                cArrClique[n] += cArrNode[n];
            }

        }
        public CPPSolutionMaxIncrease()
        {


        }

        public CPPSolutionMaxIncrease(CPPInstance nInstance)
        {

            mInstance = nInstance;
            mChange = new int[mInstance.NumberOfNodes][];
            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                mChange[i] = new int[mInstance.NumberOfNodes];

            }
            Allocate();
      //      mWeights = nInstance.Weights;
        }

        public void Allocate()
        {

            mCliques = new List<List<int>>();
            mNodeClique = new int[mInstance.NumberOfNodes];
        }

        public override void Clear()
        {

            mCliques = new List<List<int>>();

            for (int i = 0; i < mInstance.NumberOfNodes; i++)
            {
                mNodeClique[i] = -1;
            }

            InitChange();
        }


        public int AddNodeToClique(CPPCandidate N)
        {
            int result = 0;
            foreach (int n in N.mNodes)
                result += AddNodeToClique(n, N.CandidateIndex);

            return result;
        }

        public int AddNodeToClique(int iNode, int iClique)
        {

            int Added;
            if (iNode == 1)
                Added = 1;
            if (mNodeClique[iNode] != -1)
                return -1;

            if (iClique >= mCliques.Count)
            {

                List<int> nClique;
                Added = mCliques.Count;
                nClique = new List<int>();
                nClique.Add(iNode);
                mCliques.Add(nClique);
                mNodeClique[iNode] = iClique;
                UpdateChange(iClique, iNode);
                return Added;
            }

            mNodeClique[iNode] = iClique;
            mCliques[iClique].Add(iNode);

            UpdateChange(iClique, iNode);

            return -1;
        }


    }
}
