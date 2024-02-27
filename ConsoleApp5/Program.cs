using System;
using System.Linq;

abstract class Array_Base
{
    protected int[] array;

    public abstract void Initialize(bool user_Input);
    public abstract void Print();
    public abstract double Calculate_Average();
    public abstract void Remove_Elements_More_Than_Abs_100();
    public abstract void Remove_Duplicate_Elements();
}

sealed class One_Dimensional_Array : Array_Base
{
    public void Initialize(int length, bool user_Input = false)
    {
        array = new int[length];
        if (user_Input)
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
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"Enter value for index {i}: ");
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Invalid input. Please enter an integer value.");
                i--;
            }
        }
    }

    public override void Fill_Array_With_Random_Values()
    {
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-100, 101);
        }
    }

    public void Print_Array()
    {
        Console.WriteLine("Array elements:");
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    public override double Calculate_Average()
    {
        double sum = 0;
        foreach (var element in array)
        {
            sum += element;
        }
        return sum / array.Length;
    }

    public void Remove_Elements_Greater_Than_Abs_100()
    {
        array = Array.FindAll(array, x => Math.Abs(x) <= 100);
    }

    public override void Remove_Duplicate_Elements()
    {
        array = array.Distinct().ToArray();
    }
}
