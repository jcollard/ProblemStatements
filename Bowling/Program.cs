using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(CumSum(ScoreFrames(Console.ReadLine())));
        }
    }

    static string CumSum(int[] frames)
    {
        int sum = 0;
        string scores = "";
        foreach (int s in frames)
        {
            sum += s;
            scores += $"{sum} ";
        }
        return scores.Trim();
    }

    static int[] ScoreFrames(string n)
    {
        int[] frames = new int[10];
        int i = 0;
        bool firstBall = true;
        string allowed = "-123456789X/";
        int[] bonuses = new int[10];
        int lastBall = 0;

        while (n.Length > 0)
        {
            char ch = n[0];
            n = n.Substring(1);
            if (ch == ' ') continue;
            if (!allowed.Contains(ch)) throw new ArgumentException($"Cannot score '{ch}'.");

            // Set base score
            int score = ch == '/' ? 10 - lastBall : allowed.IndexOf(ch);
            lastBall = score;
            // Console.WriteLine($"Scoring {ch}, Raw: {score}");

            // Only add points to the first 10 frames
            if (i < 10) frames[i] += score;

            // Calculate bonuses
            for (int j = 0; j < 10; j++)
            {
                if (bonuses[j] > 0)
                {
                    frames[j] += score;
                    bonuses[j]--;
                }
            }

            // Check to see if we should advance to the next frame
            if (ch == 'X' && i < 10)
            {
                bonuses[i] += 2;
                i++;
                firstBall = true;
            }
            else if (ch == '/' && i < 10)
            {
                bonuses[i]++;
                i++;
                firstBall = true;
            }
            else if (!firstBall)
            {
                firstBall = true;
                i++;
            }
            else
            {
                firstBall = false;
            }
        }
        return frames;
    }
}
