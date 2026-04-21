namespace SlotMachineRefactored;

class Program
{
    static void Main(string[] args)
    {
        int balance = Constants.INITIAL_BALANCE;
        int mode;
        int dim;

        UIMethods.DisplayMessage(
            $"Hello, this is a little slot machine game! Wager is $1 per line. You start with {Constants.
                INITIAL_BALANCE} Dollars");

        while (balance > 0)
        {
            //Let user choose mode
            mode = UIMethods.GetUserInput(
                "Please choose a mode (enter number of the mode and press enter):\n1 Middle Line\n2 All Horizontal " +
                "\n3 All Vertical \n4 Both Diagonals");

            //Let user choose machine size
            dim = UIMethods.GetUserInput(
                "Please choose the size of the slot machine (enter number of the size and press enter):\n1 3X3\n2 5X5" +
                "\n3 7X7");

            int size = LogicMethods.GetSizeOfArray(dim);


            //Initialize Array
            int[,] array = new int [size, size];

            //Declare random
            Random rng = new Random();

            //Populate array
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    array[row, col] = rng.Next(0, 3);
                }
            }

            //Print array
            UIMethods.PrintArray(array);

            //Evaluation

            bool boolWin = true;
            int countWins = 0;

            if (mode == Constants.MODE_MIDDLE_LINE)
            {
                balance -= Constants.WAGER_PER_LINE;
                int rowToCheck = (size + 1) / 2;

                for (int col = 1; col < size; col++)
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
            }

            if (mode == Constants.MODE_ALL_HORIZONTAL)
            {
                balance -= Constants.WAGER_PER_LINE * size;
                for (int row = 0; row < size; row++)
                {
                    bool boolWinRow = true;
                    for (int col = 1; col < size; col++)
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
            }

            if (mode == Constants.MODE_ALL_VERTICAL)
            {
                balance -= Constants.WAGER_PER_LINE * size;
                for (int col = 0; col < size; col++)
                {
                    bool boolWinCol = true;
                    for (int row = 1; row < size; row++)
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
            }

            if (mode == Constants.MODE_BOTH_DIAGONALS)
            {
                balance -= Constants.WAGER_PER_LINE * 2;
                //Diagonal 1
                bool boolWinDiag = true;
                int row = 1;
                for (int col = 1; col < size; col++)
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
                for (int col = size - 2; col >= 0; col--)
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
            }


            if (countWins > 0)
            {
                UIMethods.DisplayMessage($"Congrats you win {countWins * Constants.WIN_PER_LINE} Dollars!");
                balance += countWins * Constants.WIN_PER_LINE;
            }
            else
            {
                UIMethods.DisplayMessage("You loose...");
                balance -= countWins * Constants.WIN_PER_LINE;
            }

            UIMethods.DisplayMessage($"Your balance is: {balance}");
            UIMethods.DisplayMessage("Press any key to continue...");
            UIMethods.ReadKey();
        }

        UIMethods.DisplayMessage("No more money left... Game ends!");
    }
}