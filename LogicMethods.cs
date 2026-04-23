namespace SlotMachineRefactored;

public static class LogicMethods
{
    //Declare random
    private static readonly Random rng = new Random();

    /// <summary>
    /// Get size of array from dim
    /// </summary>
    /// <param name="dim">Dimension - number chosen by user</param>
    /// <returns>returns size of array</returns>
    public static int GetSizeOfArray(int dim)
    {
        if (dim == Constants.DIM_3X3)
        {
            return Constants.SIZE_3X3;
        }

        if (dim == Constants.DIM_5X5)
        {
            return Constants.SIZE_5X5;
        }

        if (dim == Constants.DIM_7X7)
        {
            return Constants.SIZE_7X7;
        }

        return 0;
    }

    /// <summary>
    /// Populate array randomly (0,1,2)
    /// </summary>
    /// <param name="array">array to populate</param>
    /// <returns>randomly populated array (0,1,2)</returns>
    public static int[,] PopulateArray(int[,] array)
    {
        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                array[row, col] = rng.Next(0, 3);
            }
        }

        return array;
    }

    /// <summary>
    /// Evaluates Playmode Middle Line
    /// </summary>
    /// <param name="array">array to evaluate</param>
    /// <returns>count of wins</returns>
    public static int EvaluateMiddleLine(int[,] array)
    {
        bool boolWin = true;
        int countWins = 0;
        int rowToCheck = (array.GetLength(0) + 1) / 2 - 1;

        for (int col = 1; col < array.GetLength(1); col++)
        {
            if (array[rowToCheck, col] != array[rowToCheck, col - 1])
            {
                boolWin = false;
            }
        }

        if (boolWin)
        {
            countWins++;
        }

        return countWins;
    }


    /// <summary>
    /// Evaluate Play Mode Alle Horizontals
    /// </summary>
    /// <param name="array">array to evaluate</param>
    /// <returns>count of wins</returns>
    public static int EvaluateAllHorizontals(int[,] array)
    {
        int countWins = 0;
        for (int row = 0; row < array.GetLength(0); row++)
        {
            bool boolWinRow = true;
            for (int col = 1; col < array.GetLength(1); col++)
            {
                if (array[row, col] != array[row, col - 1])
                {
                    boolWinRow = false;
                }
            }

            if (boolWinRow)
            {
                countWins++;
            }
        }

        return countWins;
    }

    public static int EvaluateAllVerticals(int[,] array)
    {
        int countWins = 0;
        for (int col = 0; col < array.GetLength(1); col++)
        {
            bool boolWinCol = true;
            for (int row = 1; row < array.GetLength(0); row++)
            {
                if (array[row, col] != array[row - 1, col])
                {
                    boolWinCol = false;
                }
            }

            if (boolWinCol)
            {
                countWins++;
            }
        }

        return countWins;
    }

    /// <summary>
    /// evaluates both eiagonals
    /// </summary>
    /// <param name="array">array to evaluate</param>
    /// <returns>count of wins</returns>
    public static int EvaluateDiagonals(int[,] array)
    {
        int countWins = 0;
        //Diagonal 1
        bool boolWinDiag = true;
        int row = 1;
        for (int col = 1; col < array.GetLength(1); col++)
        {
            if (array[row, col] != array[row - 1, col - 1])
            {
                boolWinDiag = false;
            }

            row++;
        }

        if (boolWinDiag)
        {
            countWins++;
        }

        //Diagonal 2
        boolWinDiag = true;
        row = 1;
        for (int col = array.GetLength(1) - 2; col >= 0; col--)
        {
            if (array[row, col] != array[row - 1, col + 1])
            {
                boolWinDiag = false;
            }

            row++;
        }
        
        if (boolWinDiag)
        {
            countWins++;
        }
        return countWins;
    }
}