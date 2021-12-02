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

        public static string GetTableCompareString(List<ResultsInstance> Results, bool UseInstanceName)
        {
            string temp;
            string result = "";
            bool uniqueBest;
            bool uniqueAvg;
            if (UseInstanceName)
            {
                temp = Results[0].InstanceName;
                temp =  temp.Replace(".txt", "");
                temp = temp.Replace("new_", "");

                result += temp + " & ";

            }

            int     BestObjective = int.MinValue ;
            double  BestAverageObjective = double.MinValue;


            uniqueBest = true;
            uniqueAvg = true;
            foreach (ResultsInstance r in Results) {

                if (r.BestObjective > BestObjective)
                {
                    uniqueBest = true;
                    BestObjective = r.BestObjective;
                }
                else {

                    if (r.BestObjective == BestObjective)
                        uniqueBest = false;
                }
                if (r.AverageObjective > BestAverageObjective)
                {
                    uniqueAvg = true;

                    BestAverageObjective = r.AverageObjective;
                }
                else {
                    if (r.AverageObjective == BestAverageObjective)
                        uniqueAvg = false;


                }
            }

            int Length = Results.Count;
            int counter = 0;


            counter = 0;
            foreach (ResultsInstance r in Results) {

                if ((r.BestObjective == BestObjective) && (uniqueBest))
                {
                    result += "\\underline{" + r.BestObjective + "}";
                }
                else {
                    result +=  r.BestObjective;
                }

                counter++;
                if(counter < Length)
                    result += " & ";
            }

            result += " & ";

            counter = 0;

            foreach (ResultsInstance r in Results)
            {

                if ((r.AverageObjective == BestAverageObjective) && (uniqueAvg))
                {
                    result += "\\underline{" + r.AverageObjective.ToString("0.00") + "}";
                }
                else
                {
                    result += r.AverageObjective.ToString("0.00");
                }

                counter++;
                if (counter < Length)
                    result += " & ";
            }
            string sTime = "";
            string sIter = "";
            string sHits = ""; 
            foreach (ResultsInstance r in Results)
            {

                    sTime += " & " + r.AverageTime.ToString("0.00");
                    sHits += " & " + r.Hits + "/" + r.OutOf;
                    
            }


//            result += sHits + " & " + sTime + "\\\\";
            result += sHits +  "\\\\";



            return result;
        }


    }
}
