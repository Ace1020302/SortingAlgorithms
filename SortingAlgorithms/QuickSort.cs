using System;
namespace SortingAlgorithms
{
	public class QuickSort
	{
		// An array needs to be put in here
		// array needs to be sorted here
		// array needs to be send back

		public int[] QuickSortArray(int[] ArrToBeSorted)
        {
			// check if big enough to sort
			if (ArrToBeSorted.Length <= 1)
				return ArrToBeSorted;

            // pick a pivot
            // int pivotIdx = pickPivot();
            int pivotIdx = ArrToBeSorted.Length;

            // swap pivot to end (if needed)
            // swap(pivotIdx, endIdx);
            // pivotIdx = endIdx;


            // place higher values than pivot to the right side of pivot
            for (int i = ArrToBeSorted.Length-1; i > 0; i--)
            {
                if (ArrToBeSorted[i] > ArrToBeSorted[pivotIdx])
                {
                    //swap(pivotIdx, i)
                    //pivotIdx = i
                }
            }

            return ArrToBeSorted;
		}
	}
}

