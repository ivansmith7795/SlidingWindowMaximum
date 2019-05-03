using System;
using System.Diagnostics;
using System.Collections.Generic;

//C# .NET Core example of how to find the maximum value in a sliding window of array values demonstrating use of deque (double-ended queue) data data structures
//Written by Ivan Smith

namespace SlidingWindowMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
            //lets build a generic array to slide through
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Debug.WriteLine("Array1 = ");
            foreach (var item in array)
            {
                Debug.WriteLine("Array1 Values: " + item.ToString());
            }

            //find the maximum for a sliding window size of 3 in array 1
            List<int> maxArray = findMaxSlidingWindow(array, 3);
            foreach (int item in maxArray)
            {
                Debug.WriteLine("Array2 Values: " + item.ToString());
            }

            //build a second generic array to slide through
            int[] array2 = { 10, 6, 9, -3, 23, -1, 34, 56, 67, -1, -4, -8, -2, 9, 10, 34, 67 };
            Debug.WriteLine("Array2 = ");
            foreach (var item in array2)
            {
                Debug.WriteLine(item.ToString());
            }

            //find the maximum for a sliding window size of 3
            List<int> maxArray2 = findMaxSlidingWindow(array2, 3);
            foreach(int item in maxArray2)
            {
                Debug.WriteLine("Max for Array 2:" + item.ToString());
            }

          
        }
        public static List<int> findMaxSlidingWindow(int[] arr, int windowSize)
        {

            List<int> result = new List<int>(); // Generic list to use as our deque array for storing values

            if (arr.Length > 0)
            {

               LinkedList<int> list = new LinkedList<int>();

                if (arr.Length < windowSize)
                    return result;

                int startingIndex = 0;

                for (int i = startingIndex; i < windowSize; ++i)
                {
                    // Removing last smallest element index
                    while (list.Count > 0 && arr[i] >= arr[list.Last.Value])
                        list.RemoveLast();

                    // Adding newly picked element index
                    list.AddLast(i);

                    startingIndex = i + 1; // Next starting index
                }

                for (int i = startingIndex; i < arr.Length; ++i)
                {
                    result.Add(arr[list.First.Value]);

                    // Removeing all the elements indexes which are not in the current window
                    while (list.Count > 0 && list.First.Value <= i - windowSize)
                        list.RemoveFirst();

                    // Removing the smaller elements indexes which are not required
                    while (list.Count > 0 && arr[i] >= arr[list.Last.Value])
                        list.RemoveLast();

                    // Adding newly picked element index
                    list.AddLast(i);

                }

                // Adding the max number of the current window in the result
                result.Add(arr[list.First.Value]);

                return result; // returning result
            }
            else
                return result;
        }
    }
}
