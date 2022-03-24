// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace SpreadSheetColumns
// {

//     class Program
//     {

//         static void SolveProblem()
//         {
//             int n = int.Parse(Console.ReadLine());
//             for (int i = 0; i < n; i++)
//             {
//                 Console.Write(GetColumnPosition(Console.ReadLine()));
//                 if (i < n - 1) Console.Write(" ");
//             }
//         }

//         static void GenerateProblem(int inputs, int MIN_COLUMN, int MAX_COLUMN)
//         {
//             Random gen = new Random(43);    
//             Console.WriteLine(inputs);        
//             while (inputs-- > 0)
//             {
//                 string c_id = GetColumnName(gen.Next(MIN_COLUMN, MAX_COLUMN));
//                 Console.WriteLine(c_id);
//             }
//         }

//         static int GetColumnPosition(string column)
//         {
//             int value = 0;
//             while(column.Length > 0)
//             {
//                 value *= 26;
//                 value += (column[0] - 'A' + 1);
//                 column = column.Substring(1);
//             }
//             return value - 1;
//         }

//         static string GetColumnName(int i)
//         {
//             if (i < 26) return $"{GetAlpha(i)}";
//             char rightMostChar = GetAlpha(i % 26);
//             return $"{GetColumnName((i-26)/26)}{rightMostChar}";
//         }

//         static char GetAlpha(int i)
//         {
//             if (i < 0 || i >= 26) throw new Exception("Invalid int.");
//             return (char)('Z' - ('Z' - 'A' - i));
//         }
//     }
// }
