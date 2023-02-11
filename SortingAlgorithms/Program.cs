namespace SortingAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        const string _filePath = @"../../../inputJagged.csv";
        int[][] jaggedArray =  new int[20][];

        //Console.ReadLine(File.OpenRead(_filePath));

        //Console.Write(File.ReadLines(_filePath).Where(lineToCheck => lineToCheck != null).Select(lineToSplit => lineToSplit.Split(',')));

        //SOURCE THIS!!!
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


        PrintJaggedArray(jaggedArray);

    }


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

    static private void PrintJaggedArray(int[][] jagArr)
    {
        // Simply prints out array
        foreach (int[] arr in jagArr)
        {
            foreach (int num in arr)
                Console.Write($"{num} | ");
            Console.WriteLine();
        }
    }
}
