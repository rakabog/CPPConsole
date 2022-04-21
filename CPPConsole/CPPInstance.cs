using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CPP
{
    class CPPInstance
    {
        int mNumberOfNodes;
        int[][] mWeights;
        int[][] mNegativeWeights;



        public int[][] Weights
        {
            get { return mWeights; }
        }

        public int[][] NegativeWeights
        {
            get { return mNegativeWeights; }
        }

        public CPPInstance()
        {

        }

        public int NumberOfNodes
        {
            get { return mNumberOfNodes; }
        }

        public CPPInstance(string FileName)
        {

//            Load(FileName);

            LoadMIP1(FileName);
        }
        public int GetWeight(int n1, int n2)
        {

            return mWeights[n1][n2];
        }
        public void InitNegativeWeights()
        {

            mNegativeWeights = new int[mNumberOfNodes][];

            for (int i = 0; i < mNumberOfNodes; i++)
                mNegativeWeights[i] = new int[mNumberOfNodes];


            for (int i = 0; i < mNumberOfNodes; i++)
                for (int j = 0; j < mNumberOfNodes; j++)
                    mNegativeWeights[i][j] = -mWeights[i][j];



        }

        public void Allocate()
        {
            mWeights = new int[mNumberOfNodes][];

            for (int i = 0; i < mNumberOfNodes; i++)
                mWeights[i] = new int[mNumberOfNodes];
        }

        public void Load(string FileName)
        {

            string[] Lines = File.ReadAllLines(FileName);
            string Temp;
            int cLine = 0;
            char[] Sep = { ' ', '\t' };
            string[] words;
            string pattern = "[\\s+\\t]";
            List<int> cWeights;
            int cValue;
            int Current;

            mNumberOfNodes = Convert.ToInt32(Lines[cLine]);
            Allocate();

            cLine++;

            cWeights = new List<int>();
            for (int i = 0; i < Lines.Length - 1; i++)
            {
                words = Regex.Split(Lines[cLine], pattern);


                for (int j = 0; j < words.Length; j++)
                {

                    if (Int32.TryParse(words[j], out cValue))
                    {

                        cWeights.Add(cValue);
                    }
                }
                cLine++;
            }
            Current = 0;

//            mWeightsCopy = new int[mNumberOfNodes, mNumberOfNodes];
            for (int i = 0; i < mNumberOfNodes; i++)
            {

                for (int j = i; j < mNumberOfNodes; j++)
                {
                    mWeights[i][j] = -cWeights[Current];
                    mWeights[j][i] = -cWeights[Current];

//                    mWeightsCopy[i,j] = -cWeights[Current];
//                    mWeightsCopy[j, i] = -cWeights[Current];

                    Current++;
                }

            }

            InitNegativeWeights();
        }

        public void LoadMIP1(string FileName)
        {

            string[] Lines = File.ReadAllLines(FileName);
            string Temp;
            int cLine = 0;
            char[] Sep = { ' ', '\t' };
            char[] SepMip = { '=' };

            string[] words;
            string pattern = "[\\s+\\t]";
            List<int> cWeights;
            int cValue;
            int Current;
            int Node1, Node2, Value;
            //filename
            cLine++;

            Temp = Lines[cLine];
            words = Temp.Split(SepMip);


            mNumberOfNodes = Convert.ToInt32(words[1]);
            Allocate();

            cLine++;

            

            for (int i = 0; i < Lines.Length - 2; i++)
            {
                words = Regex.Split(Lines[cLine], pattern);

                Node1 = Convert.ToInt32(words[0])-1;
                Node2 = Convert.ToInt32(words[1])-1;
                Value = Convert.ToInt32(words[2]);
                mWeights[Node1][Node2] = Value;
                mWeights[Node2][Node1] = Value;

                cLine++;

            }
            
            InitNegativeWeights();
        }

        public void LoadMIP_GT(string FileName)
        {

            string[] Lines = File.ReadAllLines(FileName);
            string Temp;
            int cLine = 0;
            char[] Sep = { ' ', '\t' };
            char[] SepMip = { '=' };

            string[] words;
            string pattern = "[\\s+\\t]";
            List<int> cWeights;
            int cValue;
            int Current;
            int Node1, Node2, Value;
            double tempVal;
            //filename
            int[,] Pair;
            int Machines;
            int Jobs; 

            Temp = Lines[cLine];

            Temp = Temp.Replace(';', ' ');
            words = Regex.Split(Temp, pattern);

            Jobs = Convert.ToInt32(words[0]);
            Machines = Convert.ToInt32(words[1]);
            Pair = new int[Jobs, Machines];

            mNumberOfNodes = Jobs + Machines;
            Allocate();
            cLine++;
            cLine++;
            for (int i = 0; i < Jobs; i++) {

                Temp = Lines[cLine];

                words = Regex.Split(Temp, pattern);

                for (int j = 0; j < Machines; j++) {

                    Pair[i, j] = Convert.ToInt32(words[j]);
                }
                cLine++;
            }


            
            //next

            cLine++;
            //param
            cLine++;
            //param name

            int counter;

            for (int i = 0; i < mNumberOfNodes; i++)
                for (int j = 0; j < mNumberOfNodes; j++)
                {

                    mWeights[i][j] = 0;


                }

//Jobs    0 --> Jobs-1
// Machines  Jobs --> Jobs + Machines -1
            for (int i = 0; i < Jobs; i++)
            {
                for (int j = 0; j < Machines; j++)
                {
                    if (Pair[i, j] == 0)
                    {
                        mWeights[i][j + Jobs] = -1;
                        mWeights[j + Jobs][i] = -1;
                    }
                    else
                    {
                        mWeights[i][j + Jobs] = 1;
                        mWeights[j + Jobs][i] = 1;
                    }
                }


            }

            InitNegativeWeights();

        }

        public double GetCForModularityMaximization(string FileName) {

            string[] Lines = File.ReadAllLines(FileName);
            double M;
            int cLine = 0;
            char[] Sep = { ' ', '\t' };
            string[] words;
            string temp;
            double N;
            double Sum = 0;
            temp = Lines[cLine];
            int k=0;
            words = temp.Split(Sep);
            N= Convert.ToInt32(words[0]);
            M = Convert.ToDouble(words[1]);
            cLine++;
            for (int i = 0; i < N; i++) {
                temp = Lines[cLine];
                words = temp.Split(Sep);
                k = words.Length -1;

                Sum += (k *k) / (4 * M*M);
                cLine++;
            }








            return Sum;
        
        }

        public void LoadMIP_MM(string FileName)
        {

            string[] Lines = File.ReadAllLines(FileName);
            string Temp;
            int cLine = 0;
            char[] Sep = { ' ', '\t' };
            char[] SepMip = { '=' };

            string[] words;
            string pattern = "[\\s+\\t]";
            List<int> cWeights;
            int cValue;
            int Current;
            int Node1, Node2, Value;
            double tempVal;
            //filename
            

            Temp = Lines[cLine];

            Temp = Temp.Replace(';', ' ');
            words = Temp.Split(SepMip);


            mNumberOfNodes = Convert.ToInt32(words[1]);
            Allocate();

            
            cLine++;
            //next

            cLine++;
            //param
            cLine++;
            //param name

            int counter;

            for (int i = 0; i < mNumberOfNodes; i++)
            {
                for (int j = 0; j < mNumberOfNodes; j++)
                {

                    mWeights[i][j] = 0;


                }
            }
            for (int i = 0; i < Lines.Length - 3; i++)
            {

                Temp = Lines[cLine].Replace(';', ' ');

                words = Regex.Split(Temp, pattern);

                counter = 0;
                while (!int.TryParse(words[counter], out Node1)) { 
                    counter++;
                };
                counter++;

                while (!int.TryParse(words[counter], out Node2))
                {
                    counter++;
                };
                counter++;
                while (!double.TryParse(words[counter], out tempVal))
                {
                    counter++;
                };

                if (tempVal >= 0)
                    tempVal = tempVal;
                

                Node1 = Node1 - 1;
                Node2 = Node2 - 1;
                cValue = (int)(tempVal * 1000000);
                if (mWeights[Node1][Node2] != 0)
                    Node1 = Node1;
                mWeights[Node1][Node2] = (int)cValue;
                mWeights[Node2][Node1] = (int)cValue;

                cLine++;

            }

            InitNegativeWeights();

        }

        public void LoadMIP_Convert(string FileName)
        {

            string[] Lines = File.ReadAllLines(FileName);
            string Temp;
            int cLine = 0;
            char[] Sep = { ' ', '\t' };
            char[] SepMip = { '=' };

            string[] words;
            string pattern = "[\\s+\\t]";
            List<int> cWeights;
            int cValue;
            int Current;
            int Node1, Node2, Value;
            double tempVal;
            //filename
            List<int> AllValues = new List<int>();

            while (Lines[cLine][0] == '%')
                cLine++;



            mNumberOfNodes = Convert.ToInt32(Lines[cLine]);
            Allocate();
            cLine++;

            while (cLine < Lines.Length)
            {

                if (Lines[cLine][0] == '%')
                {
                    cLine++;
                    continue;
                }
                if(cLine>= Lines.Length)
                    break;
                Temp = Lines[cLine];

                words = Regex.Split(Temp, pattern);

                for (int i = 0; i < words.Length; i++)
                {

                    if(int.TryParse(words[i], out Value))
                    {
                        AllValues.Add(Convert.ToInt32(Value));
                    };
                    
                }
                cLine++;
            }

            for (int i = 0; i < mNumberOfNodes; i++)
            {

                for (int j = 0; j < mNumberOfNodes; j++)
                {

                    mWeights[i][j] = 0;
                }
            }

            Current = AllValues.Count - 1;

                 //   Current = 0;

            //            mWeightsCopy = new int[mNumberOfNodes, mNumberOfNodes];
            for (int i = 0; i < mNumberOfNodes; i++)
            {

                for (int j = i+1; j < mNumberOfNodes; j++)
                {
                    mWeights[i][j] = AllValues[Current];
                    mWeights[j][i] = AllValues[Current];

                    //                    mWeightsCopy[i,j] = -cWeights[Current];
                    //                    mWeightsCopy[j, i] = -cWeights[Current];

                    Current--;
                }

            }

            /*

                        for (int i = 0; i < mNumberOfNodes; i++)
                            for (int j = 0; j < mNumberOfNodes; j++)
                            {

                                mWeights[i][j] = 0;


                            }
                        for (int i = 0; i < Lines.Length - 3; i++)
                        {

                            Temp = Lines[cLine].Replace(';', ' ');

                            words = Regex.Split(Temp, pattern);

                            counter = 0;
                            while (!int.TryParse(words[counter], out Node1))
                            {
                                counter++;
                            };
                            counter++;

                            while (!int.TryParse(words[counter], out Node2))
                            {
                                counter++;
                            };
                            counter++;
                            while (!double.TryParse(words[counter], out tempVal))
                            {
                                counter++;
                            };

                            if (tempVal >= 0)
                                tempVal = tempVal;


                            Node1 = Node1 - 1;
                            Node2 = Node2 - 1;
                            cValue = (int)(tempVal * 1000000);
                            mWeights[Node1][Node2] = (int)cValue;
                            mWeights[Node2][Node1] = (int)cValue;

                            cLine++;

                        }
            */
            InitNegativeWeights();

        }


    }

}





