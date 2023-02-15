using System;
namespace SortingAlgorithms
{
	public class QuickSort
	{
        /// <summary>
        /// Sorts a provided array using Quick Sort
        /// </summary>
        /// <param name="arr"> Integer array </param>
        public void Sort(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;

            Sort(arr, low, high);
        }


        /// <summary>
        /// Sorts each array in the provided jagged array.
        /// </summary>
        /// <param name="jagArr"> The jagged array being sorted </param>
        public void SortJagged(int[][] jagArr)
        {
            foreach (int[] arr in jagArr)
                Sort(arr);
        }

        /// <summary>
        /// Sorts a provided array using Quick Sort over a specified range determined by a low and high index.
        /// </summary>
        /// <param name="arr"> Array to be sorted </param>
        /// <param name="low"> Integer representing begining of range to be sorted </param>
        /// <param name="high"> Integer represeing the end of range to be sorted </param>
        private void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                Sort(arr, low, pivotIndex - 1);
                Sort(arr, pivotIndex + 1, high);
            }

        }

        /// <summary>
        /// Chooses a pivot and moves all smaller values left of the pivot and bigger values to the right of pivot.
        /// </summary>
        /// <param name="arr"> Array to be partitioned </param>
        /// <param name="leftPointer"> Index of where the begining of the rearranging will begin. </param>
        /// <param name="rightPointer"> Index of where the begining of the rearranging will end. </param>
        /// <returns> Returns (the index of) where the pivot is at the end. </returns>
        private int Partition(int[] arr, int leftPointer, int rightPointer)
        { 
            int pivotValue = arr[rightPointer];

            int i = leftPointer - 1;

            for (int j = leftPointer; j <= rightPointer - 1; j++)
            {
                if (arr[j] < pivotValue)
                {
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i+1, rightPointer);

            return i + 1;
        }

        /// <summary>
        /// Swaps any two elements in an array
        /// </summary>
        /// <param name="arr"> The array where the swap is happening </param>
        /// <param name="idxOne"> index of an element to be swapped </param>
        /// <param name="idxTwo"> index of an element being swapped </param>
        private void swap(int[] arr, int idxOne, int idxTwo)
        {
            int idxOneVal = arr[idxOne];
            arr[idxOne] = arr[idxTwo];
            arr[idxTwo] = idxOneVal;
        }

        /// <summary>
        /// Writes out the elements of an array in a formatted way
        /// </summary>
        /// <param name="arr"> Array whose elements are being written out </param>
        public void WriteElements(int[] arr)
        {
            foreach (int num in arr)
                Console.Write($"{num} | ");
            Console.WriteLine();
        }
    }
}

