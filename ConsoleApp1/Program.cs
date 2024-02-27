using System;

abstract class Array_Base
{
    protected int[][] jagged_Array;

    protected Array_Base(int[][] array)
    {
        jagged_Array = array;
    }

    public abstract void Initialize_Array(bool user_Input);
    public abstract double Calculate_Average();
    public abstract void Calculate_Nested_Averages();
    public abstract void Modify_Even_Elements();
}

sealed class Jagged_Array : Array_Base
{
    public void Initialize()
    {
        public Jagged_Array(int[][] array, bool user_Input = false) : base(array)
        {
            Console.WriteLine("What type (user input(true) or random input(false))");
            user_Input = bool.Parse(Console.ReadLine());
            if (user_Input == true)
            {
                Initialize_Array(user_Input);
            }
            else
            {
                Fill_Array_With_Random_Values();
            }
        }
        public override void Initialize_Array(bool user_Input)
        {
            Console.WriteLine("Enter values for the jagged array:");
            for (int i = 0; i < jagged_Array.Length; i++)
            {
                Console.Write($"Enter the number of elements in array {i}: ");
                int length;
                if (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    i--;
                    continue;
                }
                jagged_Array[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    Console.Write($"Enter value for index {j}: ");
                    if (!int.TryParse(Console.ReadLine(), out jagged_Array[i][j]))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer value.");
                        j--;
                    }
                } 
            }
        }
        protected void Fill_Array_With_Random_Values()
        {
            Random random = new Random();
            for (int i = 0; i < jagged_Array.Length; i++)
            {
                jagged_Array[i] = new int[random.Next(1, 6)];
                for (int j = 0; j < jagged_Array[i].Length; j++)
                {
                    jagged_Array[i][j] = random.Next(-100, 101);
                }
            }
        }   
    }

    public override void Print()
    {
        Console.WriteLine("Jagged Array:");
        for (int i = 0; i < jagged_Array.Length; i++)
        {
            Console.Write("Array " + i + ": ");
            for (int j = 0; j < jagged_Array[i].Length; j++)
            {
                Console.Write(jagged_Array[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public double CalculateAverage()
    {
        double sum = 0;
        int count = 0;
        foreach (var array in jagged_Array)
        {
            foreach (var element in array)
            {
                sum += element;
                count++;
            }
        }
        return count == 0 ? 0 : sum / count;
    }

    public override void Calculate_Nested_Averages()
    {
        Console.WriteLine("Average values in nested arrays:");
        for (int i = 0; i < jagged_Array.Length; i++)
        {
            double sum = 0;
            foreach (var element in jagged_Array[i])
            {
                sum += element;
            }
            double average = jagged_Array[i].Length == 0 ? 0 : sum / jagged_Array[i].Length;
            Console.WriteLine($"Array {i}: {average}");
        }
    }

    public override void Modify_Even_Elements()
    {
        for (int i = 0; i < jagged_Array.Length; i++)
        {
            for (int j = 0; j < jagged_Array[i].Length; j++)
            {
                if (jagged_Array[i][j] % 2 == 0)
                {
                    jagged_Array[i][j] = i * j;
                }
            }
        }
    }
}
