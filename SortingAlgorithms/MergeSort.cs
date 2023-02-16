using System;
namespace SortingAlgorithms
{
	public class MergeSort
	{
        /// <summary>
        /// Sorts a provided array using Merge Sort
        /// </summary>
        /// <param name="arr"> Integer array </param>
        public int Sort(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;

            Sort(arr, low, high);

            return -1;
        }

        /// <summary>
        /// Sorts a provided array using Merge Sort over a specified range determined by a low and high index.
        /// </summary>
        /// <param name="arr"> Array to be sorted </param>
        /// <param name="low"> Integer representing begining of range to be sorted </param>
        /// <param name="high"> Integer represeing the end of range to be sorted </param>
        private int Sort(int[] arr, int low, int high)
        {
            if (low > high)
                return -1;
            int midPoint = (low + high) / 2;
            Sort(arr, low, midPoint);
            Sort(arr, midPoint + 1, high);
            Merge(arr, low, midPoint, high);
            return -1;
        }
    }

