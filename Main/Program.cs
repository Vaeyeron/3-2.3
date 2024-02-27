class Program
{
    static void Main(string[] args)
    {
        Array_Base[] arrays = new Array_Base[3];

        arrays[0] = new One_Dimensional_Array(5);
        arrays[1] = new Multi_Dimensional_Array(3, 4);
        arrays[2] = new Jagged_Array(5);

        for (int i = 0; i < arrays.Length; i++)
        {
            arrays[i].InitializeArray();
            arrays[i].PrintArray();
            Console.WriteLine("Average: " + arrays[i].Calculate_Average());
            Console.WriteLine();
        }
    }
}
