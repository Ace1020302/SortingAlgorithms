///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Sorting Algorithms Project 2
// Description: Class that sorts an array or jagged array using a recursive merge sort algorithm.
//
///////////////////////////////////////////////////////////////////////////////

using System;
namespace SortingAlgorithms
{
    public class MergeSort
    {
        /// <summary>
        /// Sorts a provided array using Merge Sort
        /// </summary>
        /// <param name="arr"> Integer array </param>
        public void Sort(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;

            Sort(arr, low, high);

        }

        /// <summary>
        /// Sorts a provided array using Merge Sort over a specified range determined by a low and high index.
        /// </summary>
        /// <param name="arr"> Array to be sorted </param>
        /// <param name="low"> Integer representing begining of range to be sorted </param>
        /// <param name="high"> Integer represeing the end of range to be sorted </param>
        private void Sort(int[] arr, int low, int high)
        {
            //Source:  https://www.geeksforgeeks.org/merge-sort/
            if (low >= high)
                return;
            int midPoint = low + (high-low) / 2;
            Sort(arr, low, midPoint);
            Sort(arr, midPoint + 1, high);
            Merge(arr, low, midPoint, high);
        }

        /// <summary>
        /// Sorts a jagged array
        /// </summary>
        /// <param name="jaggedArr"> Jagged Array to be sorted; must be integers. </param>
        public void SortJagged(int[][] jaggedArr)
        {
            for(int i = 0; i < jaggedArr.Length; i++)
                Sort(jaggedArr[i]);
        }

        /// <summary>
        /// Merge together subarrays.
        /// </summary>
        /// <param name="arr"> Array that is having subarrays merged into. </param>
        /// <param name="low"> Pointer indicating left index for left subarray. </param>
        /// <param name="mid"> Pointer indicating middle index for the two subarrays. </param>
        /// <param name="high"> Pointer indicating right index for the right subarray. </param>
        private void Merge(int[] arr, int low, int mid, int high)
        {
            // Source: https://www.geeksforgeeks.org/merge-sort/
            int leftArrBound = mid - low + 1;
            int rightArrBound = high - mid;

            int[] leftArr = new int[leftArrBound];
            int[] rightArr = new int[rightArrBound];

            for (int idxOne = 0; idxOne < leftArrBound; idxOne++)
                leftArr[idxOne] = arr[low + idxOne];
            for (int idxTwo = 0; idxTwo < rightArrBound; idxTwo++)
                rightArr[idxTwo] = arr[mid + 1 + idxTwo];

            int i = 0;
            int j = 0;
            int k = low;

            while (i < leftArrBound && j < rightArrBound)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while (i < leftArrBound)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }

            while (j < rightArrBound)
            {
                arr[k] = rightArr[j];
                j++;
                k++;
            }
        }
    }
}
