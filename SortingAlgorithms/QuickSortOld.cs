using System;
namespace SortingAlgorithms
{
	public class QuickSortOld
	{
        // An array needs to be put in here
        // array needs to be sorted here
        // array needs to be send back
        int pivotIdx { get; set; }
        int leftPivotIdx { get; set; }
        int rightPivotIdx { get; set; }

        int timesRun = 0;

		public int[] QuickSortArray(int[] ArrToBeSorted)
        {
			// check if big enough to sort
			if (ArrToBeSorted.Length <= 1)
				return ArrToBeSorted;

            // pick a pivot
            pivotIdx = ArrToBeSorted.Length - 1;

            //if (timesRun == 0)
            //{
            //    //WriteElements(ArrToBeSorted);
            //    Console.WriteLine($"Pivot Value: {ArrToBeSorted[pivotIdx]}, Pivot Index: {pivotIdx}");
            //    //timesRun++;
            //}

            // moves smaller values to the left of pivot and larger values to the right!
            Partition(ArrToBeSorted, 0, pivotIdx-1, pivotIdx);

            // Tells me whether or not the intial partition and pivot selection was correct!
            if (timesRun == 0)
            {
                WriteElements(ArrToBeSorted);
                Console.WriteLine($"Pivot Value: {ArrToBeSorted[pivotIdx]}, Pivot Index: {pivotIdx}");
                
            }


            // I need to partition the left and right sides! Do not make sub arrays. Sub arrays get sorted but do not sort main array.
            // Maybe I need to use pointers to track it?

            // Needs to be long as 0 -> pivotIdx or the amount of elements preceeding the pivot.
            int[] subArrayLeft = new int[pivotIdx];

            // Needs to be long as 0 -> (Inital Array Size - the amount of elements after the pivot, excluding the pivot)
            int[] subArrayRight = new int[ArrToBeSorted.Length - pivotIdx - 1];

            leftPivotIdx = pivotIdx - 1;
            rightPivotIdx = ArrToBeSorted.Length-1;

            //partition(ArrToBeSorted, 0, leftPivotIdx-1, leftPivotIdx);
            //partition(ArrToBeSorted, pivotIdx + 1, rightPivotIdx, rightPivotIdx);

            //Array.Copy(ArrToBeSorted, subArrayLeft, pivotIdx);
            //Array.Copy(ArrToBeSorted, pivotIdx+1, subArrayRight, 0, ArrToBeSorted.Length - pivotIdx - 1);


            timesRun++;

            //QuickSortArray(subArrayLeft);
            //QuickSortArray(subArrayRight);

            //WriteElements(ArrToBeSorted);

            return ArrToBeSorted;
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


        //private int partition(int[] arr, int leftIdx, int rightIdx)
        //{
        //    if(leftIdx == rightIdx)
        //    {
        //        // swaps in the pivot to the right spot
        //        int idxToSwap = (arr[rightIdx] < arr[pivotIdx]) ? rightIdx + 1 : rightIdx;
        //        swap(arr, idxToSwap, pivotIdx);
        //        pivotIdx = idxToSwap;

        //        // stops the recursion
        //        return 0;
        //    }

        //    if (arr[rightIdx] < arr[pivotIdx])
        //    {
        //        swap(arr, leftIdx, rightIdx);
        //        partition(arr, leftIdx + 1, rightIdx);
        //    }
        //    else
        //        partition(arr, leftIdx, rightIdx - 1);

        //    return 0;
        //}

        /*
        private int partition(int[] arr, int leftIdx, int rightIdx, int activePivotIdx)
        {
            if (leftIdx == rightIdx)
            {
                // swaps in the pivot to the right spot
                int idxToSwap = (arr[rightIdx] < arr[activePivotIdx]) ? rightIdx + 1 : rightIdx;
                swap(arr, idxToSwap, activePivotIdx);
                activePivotIdx = idxToSwap;

                // stops the recursion
                return 0;
            }

            if (arr[rightIdx] < arr[activePivotIdx])
            {
                swap(arr, leftIdx, rightIdx);
                partition(arr, leftIdx + 1, rightIdx);
            }
            else
                partition(arr, leftIdx, rightIdx - 1);

            return 0;
        }
        */

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




        private int[] Partition(int[] ArrToBeSorted, int leftPointer, int rightPointer, int pivotPointer)
        {
            if (leftPointer == rightPointer)
            {
                return ArrToBeSorted;
            }

            if (ArrToBeSorted[leftPointer] < ArrToBeSorted[pivotPointer])
            {
                swap(ArrToBeSorted, leftPointer, rightPointer);
                Partition(ArrToBeSorted, leftPointer + 1, rightPointer, pivotPointer);
            }
            else
            {
                Partition(ArrToBeSorted, leftPointer, rightPointer - 1, pivotPointer);
            }


            return ArrToBeSorted;
        }
	}
}

