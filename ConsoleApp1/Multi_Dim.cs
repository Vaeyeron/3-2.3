using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Multi_Dim
    {
        private int[,] _array;
        private string _type;

        public Multi_Dim(int rows, int columns, bool user_Input = false)
        {
            Console.WriteLine("What type? (if user input(true) or if random(false))");
            user_Input = bool.Parse(Console.ReadLine());
            Initialize(rows, columns, user_Input);

        }

        public void Initialize(int rows, int columns, bool user_Input = false)
        {
            _array = new int[rows, columns];
            if (user_Input == true)
            {
                Fill_Array_With_User_Values();
            }
            else
            {
                Fill_Array_With_Random_Values();
            }
        }

        public void Fill_Array_With_User_Values()
        {
            Console.WriteLine("Enter values for the array:");
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    Console.Write($"Enter value for index [{i},{j}]: ");
                    if (!int.TryParse(Console.ReadLine(), out _array[i, j]))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer value.");
                        j--;
                    }
                }
            }
        }

        private void Fill_Array_With_Random_Values()
        {
            Random random = new Random();
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    _array[i, j] = random.Next(-100, 101);
                }
            }
        }


        public void Print()
        {
            Console.WriteLine("Array elements:");
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    Console.Write(_array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public double Calculate_Average()
        {
            double sum = 0;
            foreach (var element in _array)
            {
                sum += element;
            }
            return sum / _array.Length;
        }

        public void Reverse_Even_Rows()
        {
            for (int i = 1; i < _array.GetLength(0); i += 2)
            {
                for (int j = 0; j < _array.GetLength(1) / 2; j++)
                {
                    int temp = _array[i, j];
                    _array[i, j] = _array[i, _array.GetLength(1) - 1 - j];
                    _array[i, _array.GetLength(1) - 1 - j] = temp;
                }
            }
        }
    }
}
