///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Sorting Algorithms Project 2
// Description: Class that sorts a provided CSV file's data and searches through it for the number 256.
//
///////////////////////////////////////////////////////////////////////////////

using System.Diagnostics;

namespace SortingAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        // File path relative to location of the program.
        const string _filePath = @"../../../inputJagged.csv";

        // JaggedArray with an inital length of 20.
        int[][] jaggedArray = new int[20][];

        // Second JaggedArray with an inital length of 20.
        int[][] jaggedArray2 = new int[20][];

        // Reads csv contents into an integer array for both arrays
        ReadFileToArray(_filePath, jaggedArray);
        ReadFileToArray(_filePath, jaggedArray2);

        double timeToQuickSort = 0;
        double timeToMergeSort = 0;

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        
        // Sorts the entire jagged array
        QuickSort quickSorter = new QuickSort();
        quickSorter.SortJagged(jaggedArray);

        stopwatch.Stop();
        timeToQuickSort = stopwatch.Elapsed.TotalSeconds;

        stopwatch.Reset();

        stopwatch.Start();
        MergeSort mergeSorter = new MergeSort();
        mergeSorter.SortJagged(jaggedArray2);

        stopwatch.Stop();
        timeToMergeSort = stopwatch.Elapsed.TotalSeconds;

        Console.WriteLine($"QUICK SORT: {timeToQuickSort} seconds to sort \n");

        Console.WriteLine("================================================================================================================");
        Console.WriteLine();


        PrintJaggedArray(jaggedArray);

        /*for(int i = 0; i < jaggedArray.Length; i++)
        {
            for(int j = 0; j < jaggedArray[i].Length; j++)
            {
                if (jaggedArray[i][j] != jaggedArray2[i][j])
                {
                    Console.WriteLine("NOT SORTED!");
                    return;
                }

            }
        }*/

        Console.WriteLine("================================================================================================================");
        Console.WriteLine();

        Console.WriteLine($"MERGE SORT: {timeToMergeSort} seconds to sort\n");

        Console.WriteLine("================================================================================================================");
        Console.WriteLine();


        PrintJaggedArray(jaggedArray2);

        Console.WriteLine("================================================================================================================");
        Console.WriteLine();

        Console.WriteLine("BINARY SEARCH\n");

        Console.WriteLine("================================================================================================================");
        Console.WriteLine();
        // Sets up the searcher.
        BinarySearch searcher = new BinarySearch();

        // Tells what value the searcher needs to find.
        int valueToFind = 256;

        Console.WriteLine($"Value being searched for: {valueToFind}\n");

        // Iterates the search for each array in the jagged array.
        // Could implement in the BinarySearch class but this is for demostration only
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            int index = searcher.Find(jaggedArray[i], valueToFind);

            if (index != -1)
            {
                Console.WriteLine($"{valueToFind} found in Array {i} at Index {index}");
            }
            else
            {
                Console.WriteLine($"{valueToFind} not found in Array {i}\t\tIndex not found: {index}");
            }
        }

    }

    private static void ReadFileToArray(string _filePath, int[][] jagArr)
    {
        // Source: https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-7.0
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(_filePath))
            {
                string line;
                int idxOfArr = 0;


                while ((line = sr.ReadLine()!) != null)
                {
                    jagArr[idxOfArr] = ConvertLineToInt(line);
                    idxOfArr++;
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }



    /// <summary>
    /// Converts a string of comma separated integers into an array of numbers
    /// </summary>
    /// <param name="line"> The string containing the values </param>
    /// <returns> An integer array containing the comma separated integers in the string </returns>
    private static int[] ConvertLineToInt(string line)
    {
        // splits the line where there are commas
        string[] lineParts = line.Split(',');

        // To store new array of integers
        int[] intArray = new int[lineParts.Length];

        // Converts string to numbers
        for (int i = 0; i < lineParts.Length; i++)
            int.TryParse(lineParts[i], out intArray[i]);

        // send back an array of those numbers
        return intArray;
    }

    /// <summary>
    /// Prints the jagged array in a formatted output.
    /// </summary>
    /// <param name="jagArr"> The jagged array that is being printed out. </param>
    private static void PrintJaggedArray(int[][] jagArr)
    {
        // Simply prints out array
        foreach (int[] arr in jagArr)
        {
            foreach (int num in arr)
                Console.Write($"{num} | ");
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("================================================================================================================");

        }
    }
}
