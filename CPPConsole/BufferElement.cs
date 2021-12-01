using System;
using System.Collections.Generic;

namespace CPP
{
    public class BufferElement
    {
        public int[] mNewLocations;
        public int[] mOldLocations;

        public List<int[]> mRelocations;
        public int mChange;

        public BufferElement(int Size)
        {

            mNewLocations = new int[Size];
            mOldLocations = new int[Size];

            Array.Fill(mNewLocations, -1);
            Array.Fill(mOldLocations, -1);
            mRelocations = new List<int[]>();
        }

        public bool HasRelocation(int[] r)
        {

            return mNewLocations[r[0]] == r[1];
        }
        public int[] TakeRandomRelocation(Random iGenerator)
        {
            int[] result;

            int select = iGenerator.Next() % mRelocations.Count;

            result = mRelocations[select];

            mNewLocations[mRelocations[select][0]] = -1;
            mRelocations.RemoveAt(select);



            return result;

        }
        public void RemoveRelocation(int iNode)
        {

            mNewLocations[iNode] = -1;
            mOldLocations[iNode] = -1;

            List<int[]> tRelocations = new List<int[]>();

            foreach (int[] t in mRelocations)
            {

                if (t[0] != iNode)
                    tRelocations.Add(t);
            }
            mRelocations = tRelocations;
        }
        public bool CanAdd(int nNode, int nClique)
        {
            return mNewLocations[nNode] == -1;
        }

        public bool Contains(int nNode)
        {
            return mNewLocations[nNode] != -1;
        }

        public bool Add(int nNode, int nClique, int oClique)
        {


            if (!CanAdd(nNode, nClique))
                return false;
            int[] temp = new int[2];

            mNewLocations[nNode] = nClique;
            mOldLocations[nNode] = oClique;
            temp[0] = nNode;
            temp[1] = nClique;

            mRelocations.Add(temp);
            return true;
        }

        public BufferElement(BufferElement A)
        {
            mNewLocations = new int[A.mNewLocations.Length];
            mOldLocations = new int[A.mOldLocations.Length];
            mRelocations = new List<int[]>();
            Array.Copy(A.mNewLocations, mNewLocations, A.mNewLocations.Length);
            Array.Copy(A.mOldLocations, mOldLocations, A.mOldLocations.Length);


            int[] temp;
            foreach (int[] t in A.mRelocations)
            {
                temp = new int[2];
                temp[0] = t[0];
                temp[1] = t[1];
                mRelocations.Add(temp);

            }


        }


        bool IsSameDest(int N1, int N2)
        {
            return mNewLocations[N1] == mNewLocations[N2];

        }

        bool Related(BufferElement A)
        {


            bool[] Contains = new bool[mOldLocations.Length];
            Array.Fill(Contains, false);


            for (int i = 0; i < mOldLocations.Length; i++)
            {
                if ((mOldLocations[i] != -1))
                    Contains[mOldLocations[i]] = true;

                if ((mNewLocations[i] != -1))
                    Contains[mNewLocations[i]] = true;

            }
            foreach (int[] t in A.mRelocations)
            {

                if (Contains[t[1]])
                    return true;
                if (Contains[A.mOldLocations[t[0]]])
                    return true;
            }


            return false;
        }

        void Merge(BufferElement A)
        {

            foreach (int[] t in A.mRelocations)
            {
                Add(t[0], t[1], A.mOldLocations[t[0]]);

            }
        }

        public List<BufferElement> SplitIndependet()
        {

            List<BufferElement> Result = new List<BufferElement>();
            BufferElement Dependent;
            List<BufferElement> Independent;

            foreach (int[] t in mRelocations)
            {


                Independent = new List<BufferElement>();

                Dependent = new BufferElement(mOldLocations.Length);
                Dependent.Add(t[0], t[1], mOldLocations[t[0]]);

                foreach (BufferElement cReloc in Result)
                {

                    if (Dependent.Related(cReloc))
                    {
                        Dependent.Merge(cReloc);
                    }
                    else
                    {

                        Independent.Add(cReloc);
                    }
                }

                Result = Independent;
                Result.Add(Dependent);

            }

            return Result;
        }
    }
}
