using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP
{
    class ResultsInstance
    {
        public double AverageTime;
        public double AverageIter;
        public double AverageObjective;
        public int    BestObjective;
        public int    Hits;
        public int    OutOf;
        public string InstanceName;


        public ResultsInstance() { 
        
        }

        public string GetTableString(bool UseInstanceName) {

            string result = "";
            if (UseInstanceName)
                result += InstanceName + " & ";

            result += BestObjective + " & ";
            result += AverageObjective.ToString("0.00") + " & ";
            result += AverageTime.ToString("0.00") + " & ";
            result += AverageIter.ToString("0.00") + " & ";
            result += Hits + "/" +OutOf ;

            return result;
        }

    }
}
