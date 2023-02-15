using System;
namespace SortingAlgorithms
{
	public class BinarySearch
	{
		public int Find(int[] arr, int value)
		{
			//check if sorted
			//if not, sort
			if (!IsSorted(arr))
			{
				QuickSort quickSorter = new QuickSort();
				quickSorter.Sort(arr);
			}

			// core search
			return Search(arr, value, 0, arr.Length);
				
		}

		private int Search(int[] arr, int value, int lowerBound, int upperBound)
		{
			// 0, 10
			// 0, 5 // 5, 10
			// 0, 2 || 2, 5 // 
			// 0, 1 || 1, 2 || 2, 3 || 3, 4 //
			// 0, 0 || 1, 1 || 2, 2 || 3,3 || 4,4 //
			
			if (lowerBound == upperBound)
				return -1;

			// 0 + (10-0)/2 = 5 -> Assume lower half for remainder ||| 5 becomes new upper bound

			// 0 + (5-0)/2 = 2.5 | 2   |||  2 becomes new upper bound

			// 0 + (2-0)/2 = 1   |||  1 becomes new upper bound

			// 0 + (1-0)/2 = 0   |||  0 becomes new upper bound

			// 0 = 0, return -1


			// 0 + (10-0)/2 = 5 -> Assume upper half for remainder ||| 5 becomes new lower bound

			// 5 + (10-5)/2 = 7.5 | 7    |||  7 becomes new lower bound

			// 7 + (10-7)/2 = 8.5 | 8   |||  8 becomes new upper bound

			// 8 + (10-8)/2 = 9   |||  9 becomes new upper bound

			// 9 + (10-9)/2 = 9.5 | 9  ||| 9 becomes new upper bound


			// 0 + (10-0)/2 = 5 -> Assume upper half for remainder ||| 5+1 becomes new lower bound

			// 6 + (10-6)/2 = 8 | 8    |||  8+1 becomes new lower bound

			// 9 + (10-9)/2 = 9 | 9   |||  9 + 1 becomes new upper bound

			// 10 == 10, return -1.

			double mathDoub = (upperBound - lowerBound) / 2;

            int searchPosition = lowerBound + (int) mathDoub;


			// Sees if the value is at the search position.
            if (arr[searchPosition] == value)
                return searchPosition;

			// If value is larger than the search area, search right. Otherwise, search left.
            if (arr[searchPosition] < value)
				return Search(arr, value, lowerBound, searchPosition);
			else
				return Search(arr, value, searchPosition, upperBound);
        }

		private bool IsSorted(int[] arr)
		{
			for (int i = 0; i < arr.Length - 2; i++)
				if (arr[i] > arr[i + 1])
					return false;
			return true;
		}
	}
}

