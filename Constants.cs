namespace SlotMachineRefactored;

public static class Constants
{
    public const int DIM_3X3 = 1;
    public const int DIM_5X5 = 2;
    public const int DIM_7X7 = 3;
    public const int SIZE_3X3 = 3;
    public const int SIZE_5X5 = 5;
    public const int SIZE_7X7 = 7;
    public const int INITIAL_BALANCE = 25;
    public const int WAGER_PER_LINE = 1;
    public const int WIN_PER_LINE = 3;

    public enum PlayMode
    {
        MiddleLine = 1,
        AllHorizontals = 2,
        AllVerticals = 3,
        Diagonals = 4
    }
}