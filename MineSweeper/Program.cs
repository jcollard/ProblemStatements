using System;
using System.Linq;
using System.Text;
using System.IO;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                char[,] grid = GenerateGrid(4 << i, .25, 42 + i);
                File.WriteAllText($"test_{i}.txt", GridToString(grid));
                File.WriteAllText($"test_{i}_solution.txt", GridToString(FillGrid(grid)));

                grid = GenerateGrid(4 << i, .25, 142 + i);
                File.WriteAllText($"validator_{i}.txt", GridToString(grid));
                File.WriteAllText($"validator_{i}_solution.txt", GridToString(FillGrid(grid)));
                
            }

        }

        static string GridToString(char[,] grid)
        {
            StringBuilder b = new StringBuilder();
            int N = grid.GetLength(0);
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    b.Append(grid[r, c]);
                }
                b.Append("\n");
            }
            return b.ToString().Trim();
        }

        static char[,] GenerateGrid(int N, double density, int seed = 42)
        {
            char[,] grid = new char[N, N];
            Random gen = new Random();
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    grid[r, c] = gen.NextDouble() < density ? 'b' : 'o';
                }
            }
            return grid;
        }

        static char[,] FillGrid(char[,] grid)
        {
            int N = grid.GetLength(0);
            char[,] result = new char[N, N];
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    result[r, c] = grid[r, c] == 'o' ? CountNeighbors(r, c, grid) : 'b';
                }
            }
            return result;
        }

        static char CountNeighbors(int r, int c, char[,] grid)
        {
            int N = grid.GetLength(0);
            (int, int)[] locs =
            {
                (r - 1, c - 1), (r - 1, c), (r - 1, c + 1),
                (r, c - 1), (r, c + 1),
                (r + 1, c - 1), (r + 1, c), (r + 1, c + 1)
            };
            int count = locs.Where(((int r, int c) pair) => pair.r >= 0 && pair.r < N && pair.c >= 0 && pair.c < N && grid[pair.r, pair.c] == 'b').Count();

            return $"{count}"[0];
        }
    }
}
