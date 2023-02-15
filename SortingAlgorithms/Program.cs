namespace SortingAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        const string _filePath = @"../../../inputJagged.csv";
        int[][] jaggedArray =  new int[20][];

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
                    jaggedArray[idxOfArr] = ConvertLineToInt(line);
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

        // Sorts the entire jagged array
        QuickSort quickSorter = new QuickSort();
        quickSorter.SortJagged(jaggedArray);


        BinarySearch searcher = new BinarySearch();

        // Tells what value the searcher needs to find.
        int valueToFind = 610;
        bool wasFound = false;

        // Iterates the search for each array in the jagged array.
        // Could implement in the BinarySearch class but this is for demostration only.

        for(int i = 0; i < jaggedArray.Length; i++)
        {
            int index = searcher.Find(jaggedArray[i], valueToFind);
            
            if(index != -1)
            {
                Console.WriteLine($"Found in Array {i} at Index {index}");
                wasFound = true;
            }
        }

        if (!wasFound)
            Console.WriteLine($"{valueToFind} Not Found");

        //PrintJaggedArray(jaggedArray);
    }



    /// <summary>
    /// Converts a string of comma separated integers into an array of numbers
    /// </summary>
    /// <param name="line"> The string containing the values </param>
    /// <returns> An integer array containing the comma separated integers in the string </returns>
    static private int[] ConvertLineToInt(string line)
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
    static private void PrintJaggedArray(int[][] jagArr)
    {
        // Simply prints out array
        foreach (int[] arr in jagArr)
        {
            foreach (int num in arr)
                Console.Write($"{num} | ");
            Console.WriteLine();
            Console.WriteLine("================================================================================================================");

        }
    }
}
