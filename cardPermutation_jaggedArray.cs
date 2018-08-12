using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class cardPermutationjagged
    {
        public static void Main(string[] args)
        {
            //int[,] arr;            
            //arr = new int[39916800, 12];

            CardPermutation();            
        }

        public static void CardPermutation()
        {
            ulong[] input = new ulong[] { 1, 2, 3, 4, 5, 6, 7, 8,9,10};
            ulong Output = 0;
            ulong N = 10;
            ulong[][] newPermArray, oldPermArray=null;

            for (ulong i = N; i >= 1; i--)
            {
                ulong permutationcountMultiplexer = (N - i) + 1;
                ulong row = i < N ? (ulong)oldPermArray.Length * permutationcountMultiplexer : permutationcountMultiplexer;

                ulong column = permutationcountMultiplexer;

                newPermArray = new ulong[row][];

                if ((permutationcountMultiplexer - 1) == 0)
                {
                    ulong[] coln = new ulong[1];
                    coln[0] = i;
                    oldPermArray = new ulong[1][];
                    oldPermArray[0] = coln;
                }
                else
                {
                    oldPermArray = permutations(input,ref Output, N, i, permutationcountMultiplexer, newPermArray, oldPermArray);
                }
            }
            Console.WriteLine(Output);
            Console.ReadLine();
        }


        public static ulong[][] permutations(ulong[] input,ref ulong output, ulong N, ulong newPermNo,ulong permutationcountMultiplexer, ulong[][] newPermArray, ulong[][] oldPermArray)
        {
            ulong row = 0, myIndex = 0;

            for(ulong i=0;i<permutationcountMultiplexer;i++)
            {
                for (int j = 0; j < oldPermArray.Length; j++)
                {
                    ulong[] coln = new ulong[permutationcountMultiplexer];

                    for(ulong m=0;m<permutationcountMultiplexer;m++)
                    {
                        if (m == myIndex)
                        {
                            coln[m] = newPermNo;
                        }else if(m<myIndex)
                        {
                            coln[m] = oldPermArray[j][m];
                        }else if(m>myIndex)
                        {
                            coln[m] = oldPermArray[j][m - 1];
                        }
                    }

                    if ((ulong)input.Length == permutationcountMultiplexer)
                    {
                        if(Outp(input,permutationcountMultiplexer,coln))
                        {
                            output += (row + 1);
                        }
                    }

                    newPermArray[row] = coln;
                    row++;


                }
                myIndex++;
            }
            return newPermArray;
        }


        public static bool Outp(ulong[] input, ulong permutationcountMultiplexer, ulong[] coln)
        {
            bool match = true;
       
                for (ulong n = 0; n < permutationcountMultiplexer; n++)
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
