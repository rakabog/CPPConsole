using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP
{
    class CPPSolutionHolder
    {
        List<CPPSolutionBase> mSolutions;
        int                   mMaxSize;
        int                   mMinObjective;
        public CPPSolutionHolder() {
            mSolutions = new List<CPPSolutionBase>();
            mMaxSize = 100;
        }
        public List<CPPSolutionBase> Solutions
        {
            get { return mSolutions; }
        }

        public void Clear() {

            mSolutions.Clear(); 
        }
        public bool Add(CPPSolutionBase iSolution) {
            CPPSolutionBase nSol;

            if (!iSolution.CheckSolutionValid()) {
                nSol = null;
            }

            if (mSolutions.Count ==0) {

                nSol = new CPPSolutionBase(iSolution);
                nSol.Objective = iSolution.CalculateObjective();
                mSolutions.Add(nSol);
                mMinObjective = nSol.Objective;
                return true;
            }
            if (!((mSolutions.Count < mMaxSize) || (iSolution.Objective > mMinObjective))) {

                return false;
            }

            int iObjective = iSolution.Objective;
            foreach (CPPSolutionBase l in mSolutions) {
                if (l.IsSame(iObjective, iSolution.Cliques))
                    return false;
            }
            for (int i = 0; i < mSolutions.Count; i++) {
                if (mSolutions[i].Objective <= iObjective) {
                    
                    nSol = new CPPSolutionBase(iSolution);
                    nSol.Objective = iSolution.CalculateObjective();
                    mSolutions.Insert(i, nSol);
                    
                    
                    break;
                }
            }
            if (mSolutions.Count > mMaxSize) {
                mSolutions.RemoveAt(mMaxSize);
                mMinObjective = mSolutions[mMaxSize - 1].Objective;
            }

            return true;
        
        }

        
    }
}
