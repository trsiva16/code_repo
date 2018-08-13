using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class cardPermutationList
    {
        public static void Main(string[] args)
        {
            CardPermutation();            
        }

        public static void CardPermutation()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            int Output = 0;
            int N = 11;
            List<List<int>> newPermArray, oldPermArray=null;

            for (int i = N; i >= 1; i--)
            {
                int permutationcountMultiplexer = (N - i) + 1;
                newPermArray = new List<List<int>>();

                if ((permutationcountMultiplexer - 1) == 0)
                {
                    List<int> coln = new List<int>();
                    coln.Add(i);
                    oldPermArray = new List<List<int>>();
                    oldPermArray.Add(coln);
                }
                else
                {
                    oldPermArray = permutations(input,ref Output, N, i, permutationcountMultiplexer, newPermArray, oldPermArray);
                }
            }
            Console.WriteLine(Output);
            Console.ReadLine();
        }


        public static List<List<int>> permutations(int[] input, ref int output, int N, int newPermNo, int permutationcountMultiplexer, List<List<int>> newPermArray, List<List<int>> oldPermArray)
        {
            Int32 row = 0, myIndex = 0;

            for(Int32 i=0;i<permutationcountMultiplexer;i++)
            {
                for (Int32 j = 0; j < oldPermArray.Count; j++)
                {
                    List<int> coln = new List<int>();

                    for(Int32 m=0;m<permutationcountMultiplexer;m++)
                    {
                        if (m == myIndex)
                        {
                            coln.Add(newPermNo);
                        }else if(m<myIndex)
                        {
                            coln.Add(oldPermArray[j][m]);
                        }else if(m>myIndex)
                        {
                            coln.Add(oldPermArray[j][m - 1]);
                        }
                    }

                    if (input.Length == permutationcountMultiplexer)
                    {
                        if(Outp(input,permutationcountMultiplexer,coln))
                        {
                            output += (row + 1);
                        }
                    }
                    newPermArray.Add(coln);
                    row++;
                }
                myIndex++;
            }
            return newPermArray;
        }


        public static bool Outp(int[] input, int permutationcountMultiplexer, List<int> coln)
        {
            bool match = true;       
                for (int n = 0; n < permutationcountMultiplexer; n++)
                {
                    if (input[n] != 0 && input[n] != coln[n])
                    {
                        match = false;
                        break;
                    }
                }
            return match;
        }
    } 
}

