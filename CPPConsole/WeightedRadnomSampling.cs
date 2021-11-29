using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP
{
    class WeightedRadnomSampling
    {
        

        

        public static List<int>  GetWeightedRadnomSampling(int mN, int mK, double[] mWeigths, Random mGenerator) {

            List<int> Result;
            List<double[]> mUi = new List<double[]>();
            double rU;
            double[] temp;

            for (int i = 0; i < mN; i++) {

                rU = mGenerator.NextDouble();
                temp = new double[2];
                temp[0] = i;
                temp[1] = Math.Pow(rU, mWeigths[i]);
                mUi.Add(temp);
            }

            mUi = mUi.OrderBy(o => o[1]).ToList();

            Result = new List<int>();

            for (int i = 0; i < mK; i++) {

                Result.Add((int)mUi[i][0]);
            }

            return Result;
            
         }

        public static List<int> GetWeightedRadnomSampling(int mN, int mK, int[] mWeigths, Random mGenerator)
        {

            double[] dWeigths;

            double Sum = 0;

            dWeigths = new double[mN];

            for (int i = 0; i < mN; i++) {

                Sum += mWeigths[i];

                dWeigths[i] = mWeigths[i];
            }


            for (int i = 0; i < mN; i++)
            {

             

                dWeigths[i] = dWeigths[i]/Sum;
            }
            return GetWeightedRadnomSampling(mN, mK, dWeigths, mGenerator);

        }




    }
}
