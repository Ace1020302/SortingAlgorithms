///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Sorting Algorithms Project 2
// Description: Class that runs a search for provided value over a given array.
//
///////////////////////////////////////////////////////////////////////////////

using System;
namespace SortingAlgorithms
{
	public class BinarySearch
	{
		/// <summary>
		/// Finds the index of a given value in the array.
		/// </summary>
		/// <param name="arr"> Array being searched. </param>
		/// <param name="value"> Value being found. </param>
		/// <returns> Index of the value being looked for. -1 if not found. </returns>
		public int Find(int[] arr, int value)
		{
			//check if sorted
			//if not, sort (update to throw exception?)
			if (!IsSorted(arr))
			{
				//QuickSort quickSorter = new QuickSort();
				//quickSorter.Sort(arr);
				throw new ArgumentException();
			}

			// core search
			return Search(arr, value, 0, arr.Length);
				
		}


		/// <summary>
		/// Searchs for the provided value in the array and the bounds provided.
		/// </summary>
		/// <param name="arr"> The sorted array being searched </param>
		/// <param name="value"> The value being searched for </param>
		/// <param name="lowerBound"> The lower boundary of where to look </param>
		/// <param name="upperBound"> The upper boundary of where to look </param>
		/// <returns> Returns the index of the element in the array. Returns -1 if not found. </returns>
		private int Search(int[] arr, int value, int lowerBound, int upperBound)
		{

			if (lowerBound > upperBound)
				return -1;

            // Source: https://www.geeksforgeeks.org/binary-search/
            int middlePosition = (upperBound + lowerBound) / 2; ;

			// Sees if the value is at the search position.
            if (arr[middlePosition] == value)
                return middlePosition;

			// If value is larger than the search area, search right. Otherwise, search left.
            if (arr[middlePosition] < value)
				return Search(arr, value, middlePosition+1, upperBound);
			else
				return Search(arr, value, lowerBound, middlePosition-1);
        }


		/// <summary>
		/// Checks to see if the array needs to be sorted
		/// </summary>
		/// <param name="arr"> Array being checked</param>
		/// <returns> Returns True if it is already sorted, False if not. </returns>
		private bool IsSorted(int[] arr)
		{
			for (int i = 0; i < arr.Length - 2; i++)
				if (arr[i] > arr[i + 1])
					return false;
			return true;
		}
	}
}

