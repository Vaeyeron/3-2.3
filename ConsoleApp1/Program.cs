using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length for the array");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a type for the array(1, 2 or 3)");
            int type = int.Parse(Console.ReadLine());
            if (type == 1)
            {
                // TODO: Считывать с конслои значение user_Input
                One_Dim one_Dim = new One_Dim(length, false);
                one_Dim.Print_Array();
                one_Dim.Calculate_Average();
                one_Dim.Remove_Elements_More_Than_Abs_100();
                one_Dim.Remove_Duplicate_Elements();
                one_Dim.Print_Array();

                one_Dim.Initialize(length);
                one_Dim.Print_Array();
                one_Dim.Calculate_Average();
                one_Dim.Remove_Elements_More_Than_Abs_100();
                one_Dim.Print_Array();
                one_Dim.Remove_Duplicate_Elements();
                one_Dim.Print_Array();
            }
        }
    }
}

