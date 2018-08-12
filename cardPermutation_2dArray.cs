using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class cardPermutation
    {
        //public static void Main(string[] args)
        //{
        //    ulong[,] arr;
            
        //    arr = new ulong[39916800, 12];
        //    CardPermutation();            
        //}

        public static void CardPermutation()
        {
            long N = 20;
            long[,] newPermArray, oldPermArray=null;
            //long[] input = new long[] { 0, 3, 2, 0 };
            //long Output = 0;

            for (long i = N; i >= 1; i--)
            {
                long permutationcountMultiplexer = (N - i) + 1;
                long row = i < N ? ((oldPermArray.Length / (N - i)) * permutationcountMultiplexer) : permutationcountMultiplexer;
                long column = permutationcountMultiplexer;
                newPermArray = new long[row, column];
                if ((permutationcountMultiplexer - 1) == 0)
                {
                    oldPermArray = new long[1, 1];
                    oldPermArray[0, 0] = i;
                }
                else
                {
                    oldPermArray = permutations(N, i, permutationcountMultiplexer, newPermArray, oldPermArray);
                }
            }

            //for (long m = 0; m < (oldPermArray.Length / N); m++)
            //{
            //    bool match = true;
            //    for (long n = 0; n < N; n++)
            //    {
            //        if (input[n] != 0 && input[n] != oldPermArray[m, n])
            //        {
            //            match = false;
            //            break;
            //        }
            //    }
            //    if (match)
            //    {
            //        Output += (m + 1);
            //    }
            //}
            Console.WriteLine(oldPermArray.Length);
            Console.ReadLine();
        }


        public static long[,] permutations(long N, long newPermNo,long permutationcountMultiplexer, long[,] newPermArray, long[,] oldPermArray)
        {
            long row = 0, myIndex = 0;

            for(long i=0;i<permutationcountMultiplexer;i++)
            {
                for (long j = 0; j < (oldPermArray.Length/(N-newPermNo)); j++)
                {
                    for(long m=0;m<permutationcountMultiplexer;m++)
                    {
                        if (m == myIndex)
                        {
                            newPermArray[row, myIndex] = newPermNo;
                        }else if(m<myIndex)
                        {
                            newPermArray[row, m] = oldPermArray[j, m];
                        }else if(m>myIndex)
                        {
                            newPermArray[row, m] = oldPermArray[j, m - 1];
                        }
                    }
                    row++;
                }
                myIndex++;
            }
            return newPermArray;
        }

    } 
}
