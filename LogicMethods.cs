namespace SlotMachineRefactored;

public static class LogicMethods
{
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
}