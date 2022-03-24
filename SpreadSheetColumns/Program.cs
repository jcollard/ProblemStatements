using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write(GetColumnPosition(Console.ReadLine()));
            if (i < n - 1) Console.Write(" ");
        }
    }

    static int GetColumnPosition(string column)
    {
        int value = 0;
        while (column.Length > 0)
        {
            value *= 26;
            value += (column[0] - 'A' + 1);
            column = column.Substring(1);
        }
        return value - 1;
    }
}