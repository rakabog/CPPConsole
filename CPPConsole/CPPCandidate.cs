using System.Collections.Generic;

namespace CPP
{
    class CPPCandidate
    {

        public int mClique;
        public List<int> mNodes;
        public int mCandidateIndex;



        public int Clique
        {
            get { return mClique; }
            set { mClique = value; }
        }
        public int CandidateIndex
        {
            get { return mClique; }
            set { mClique = value; }
        }




        public CPPCandidate(List<int> nNodes, int nClique, int nCandidateIndex)
        {
            mNodes = nNodes;
            mClique = nClique;
            mCandidateIndex = nCandidateIndex;

        }

    }


}
