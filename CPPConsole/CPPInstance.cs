using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CPP
{
    class CPPInstance
    {
        int         mNumberOfNodes;
        int[][]      mWeights;
        int[][]      mNegativeWeights;



        public int[][] Weights
        {
            get { return mWeights; }
        }

        public int[][] NegativeWeights
        {
            get { return mNegativeWeights; }
        }

        public CPPInstance() { 
        
        }

        public int NumberOfNodes
        {
            get { return mNumberOfNodes; }
        }

        public CPPInstance(string FileName)
        {

            Load(FileName);
        }
        public void InitNegativeWeights() {

            mNegativeWeights = new int[mNumberOfNodes][];

            for (int i = 0; i < mNumberOfNodes; i++)
                mNegativeWeights[i] = new int[mNumberOfNodes];


            for (int i = 0; i < mNumberOfNodes; i++)
                for (int j = 0; j < mNumberOfNodes; j++)
                    mNegativeWeights[i][j] = -mWeights[i][j];
        }

        public void Allocate() {
            mWeights = new int[mNumberOfNodes][];

             for(int i=0; i< mNumberOfNodes; i++)   
                mWeights[i] = new int[mNumberOfNodes];
        }

        public void Load(string FileName) {

            string[] Lines = File.ReadAllLines(FileName);
            string Temp;
            int cLine=0;
            char[] Sep = {  ' ','\t' };
            string[] words;
            string pattern = "[\\s+\\t]";
            List<int> cWeights;
            int cValue;
            int Current;

            mNumberOfNodes = Convert.ToInt32(Lines[cLine]);
            Allocate();

            cLine++;

            cWeights = new List<int>();
            for (int i = 0; i < Lines.Length-1; i++) {
                words = Regex.Split(Lines[cLine], pattern);


                for (int j = 0; j < words.Length; j++) {

                    if (Int32.TryParse(words[j], out cValue) ){

                        cWeights.Add(cValue);
                    }
                }
                cLine++;
            }
            Current = 0;
            for (int i = 0; i < mNumberOfNodes; i++) {

                for (int j = i; j < mNumberOfNodes; j++) {
                    mWeights[i][j] = -cWeights[Current];
                    mWeights[j][i] = -cWeights[Current];
                    Current++;
                }    
            
            }

            InitNegativeWeights();
        }

    }
}
