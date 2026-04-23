namespace SlotMachineRefactored;

class Program
{
    static void Main(string[] args)
    {
        int balance = Constants.INITIAL_BALANCE;
        int numberModeUser;
        int dim;

        UIMethods.DisplayMessage(
            $"Hello, this is a little slot machine game! Wager is $1 per line. You start with {Constants.
                INITIAL_BALANCE} Dollars");

        while (balance > 0)
        {
            //Let user choose mode
            numberModeUser = UIMethods.GetUserInput(
                "Please choose a mode (enter number of the mode and press enter):\n1 Middle Line\n2 All Horizontal " +
                "\n3 All Vertical \n4 Both Diagonals");

            //Let user choose machine size
            dim = UIMethods.GetUserInput(
                "Please choose the size of the slot machine (enter number of the size and press enter):\n1 3X3\n2 5X5" +
                "\n3 7X7");

            int size = LogicMethods.GetSizeOfArray(dim);


            //Initialize Array
            int[,] array = new int [size, size];

            array = LogicMethods.PopulateArray(array);

            //Evaluation

            int countWins = 0;

            if (Enum.IsDefined(typeof(Constants.PlayMode), numberModeUser))
            {
                Constants.PlayMode mode = (Constants.PlayMode)numberModeUser;

                //Print array
                UIMethods.PrintArray(array);

                switch (mode)
                {
                    case Constants.PlayMode.MiddleLine:
                        balance -= Constants.WAGER_PER_LINE;
                        countWins = LogicMethods.EvaluateMiddleLine(array);
                        break;

                    case Constants.PlayMode.AllHorizontals:
                        balance -= Constants.WAGER_PER_LINE * size;
                        countWins = LogicMethods.EvaluateAllHorizontals(array);
                        break;

                    case Constants.PlayMode.AllVerticals:
                        balance -= Constants.WAGER_PER_LINE * size;
                        countWins = LogicMethods.EvaluateAllVerticals(array);
                        break;

                    case Constants.PlayMode.Diagonals:
                        balance -= Constants.WAGER_PER_LINE * 2;
                        countWins = LogicMethods.EvaluateDiagonals(array);
                        break;
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

            else
            {
                UIMethods.DisplayMessage("Number is invalid!");
                UIMethods.DisplayMessage("Press any key to continue...");
                UIMethods.ReadKey();
            }
        }

        UIMethods.DisplayMessage("No more money left... Game ends!");
    }
}