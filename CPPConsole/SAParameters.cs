using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP
{
    class SAParameters
    {
        public CPPProblem.CPPCooling mCooling;
        public double                   mInitTemperature;
        public int                   mSizeRepeat;
        public double                mCoolingParam;
        public double                mMinAccept;
        public int                   mMaxStagnation;

        public void InitGeometric() {

            mCooling = CPPProblem.CPPCooling.Geometric;
            mSizeRepeat = 32;
            mCoolingParam = 0.9;
            mMinAccept = 0.01;
            mMaxStagnation = 5;
        }


        public void InitLinearMultiplicative()
        {

            mCooling = CPPProblem.CPPCooling.LinearMultiplicative;
            mSizeRepeat = 16;
            mCoolingParam = 0.5;
            mMinAccept = 0.01;
            mMaxStagnation = 5;
        }

    }
}
