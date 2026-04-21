namespace SlotMachineRefactored;

public static class UIMethods
{
    /// <summary>
    /// Prints message to console
    /// </summary>
    /// <param name="message">message to print to console</param>
    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    
    /// <summary>
    /// Get input from user
    /// </summary>
    /// <param name="question">Question to be printed to console</param>
    /// <returns>User Input</returns>
    public static int GetUserInput(string question)
    {
        Console.WriteLine(question);
        
        int userInput = 0;
        while (true)
        {
            bool success = int.TryParse(Console.ReadLine(), out userInput);
            if (success)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("This is not a number...");
            }
        }
    }

    /// <summary>
    /// Prints array to console
    /// </summary>
    /// <param name="array">array to print</param>
    public static void PrintArray(int[,] array)
    {
        Console.Write("\n");
        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                Console.Write(array[row, col] + " ");
            }

            Console.Write("\n");
        }
    }

    /// <summary>
    /// ReadKey
    /// </summary>
    public static void ReadKey()
    {
        Console.ReadKey();
    }
}