using System;

abstract class Array_Base
{
    protected int[,] array;
    protected int rows;
    protected int columns;
    protected string type;

    public abstract void Initialize(bool user_Input);
    public abstract void Print();
    public abstract double Calculate_Average();
    public abstract void Reverse_Even_Rows();
}

sealed class Multi_Dimensional_Array : Array_Base
{
    public override void Initialize(bool user_Input)
    {
        if (user_Input == true)
        {
            Input_Array_From_User();
        }
        else
        {
            Fill_Array_With_Random_Values();
        }
    }

    public override void Input_Array_From_User()
    {
        Console.WriteLine("Enter values for the array:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Enter value for index [{i},{j}]: ");
                if (!int.TryParse(Console.ReadLine(), out array[i, j]))
                {
                    Console.WriteLine("Invalid input. Please enter an integer value.");
                    j--;
                }
            }
        }
    }

    public override void Print()
    {
        Console.WriteLine("Array elements:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public override double Calculate_Average()
    {
        double sum = 0;
        foreach (var element in array)
        {
            sum += element;
        }
        return sum / (rows * columns);
    }

    public void Reverse_Even_Rows()
    {
        for (int i = 1; i < rows; i += 2)
        {
            for (int j = 0; j < columns / 2; j++)
            {
                int temp = array[i, j];
                array[i, j] = array[i, columns - 1 - j];
                array[i, columns - 1 - j] = temp;
            }
        }
    }
}
