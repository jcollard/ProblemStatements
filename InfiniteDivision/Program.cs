using System;
using System.Text;

namespace InfiniteDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 3;

            int left = a / b;
            StringBuilder output = new StringBuilder();
            output.Append(left + ".");
            a = a - (b * left);

            while(true)
            {
                while (a > 0 && a < b) a = a * 10;
                int next = a / b;
                if (next == left)
                {
                    output.Insert(output.Length-1, "(");
                    output.Append(")");
                    break;
                }
                left = next;
                a = a - (b * next);
                output.Append(next);
            }
            Console.WriteLine(output.ToString());
            
        }
    }
}
