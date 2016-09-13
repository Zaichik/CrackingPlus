using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_ArraysStrings
{
    public static class Turn90_6
    {
        public static void Turn90(int[,] myArray, int n)
        {
            int stop = n - 1;
            for (int layer = 0; layer < n / 2; layer++)
            {
                stop -= layer*2;
                int layerStop = stop;
                for (int start = layer; start < stop; start++)
                {
                    int tempA = myArray[layer,start];                               // save A
                    myArray[layer,start] = myArray[stop - start,layer];             // d -> a
                    myArray[stop - start,layer] = myArray[layerStop,stop - start];  // c -> d
                    myArray[layerStop,stop-start] = myArray[start,layerStop];       // b -> c
                    myArray[start,layerStop] = tempA;                               // saved A -> b
                }
            }
        }
    }
}
