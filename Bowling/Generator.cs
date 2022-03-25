using System;

public class Generator
{
    static string GenerateGame(double chanceStrike, double chanceSpare, int seed)
    {
        Random gen = new Random(seed);
        string game = "";
        for (int i = 0; i < 9; i++)
        {
            game += PlayFrame(chanceStrike, chanceSpare, gen) + " ";
        }
        game += PlayFinalFrame(chanceStrike, chanceSpare, gen);
        return game;
    }

    static string PlayFrame(double chanceStrike, double chanceSpare, Random gen)
    {
        if (gen.NextDouble() < chanceStrike)
        {
            return "X";
        }
        return NonStrike(chanceSpare, gen);
    }

    static string SCORES = "-123456789";

    static string NonStrike(double chanceSpare, Random gen)
    {
        int firstBall = gen.Next(0, 10);
        if (gen.NextDouble() < chanceSpare)
        {
            return $"{SCORES[firstBall]} /";
        }
        int secondBall = gen.Next(0, 10 - firstBall);
        return $"{SCORES[firstBall]} {SCORES[secondBall]}";
    }

    static string PlayFinalFrame(double chanceStrike, double chanceSpare, Random gen)
    {
        int ball;
        if (gen.NextDouble() < chanceStrike)
        {
            if (gen.NextDouble() < chanceStrike)
            {
                if (gen.NextDouble() < chanceStrike) return "X X X";
                ball = gen.Next(0, 10);
                return $"X X {SCORES[ball]}";
            }
            return $"X " + NonStrike(chanceSpare, gen);
        }
        string first = NonStrike(chanceSpare, gen);
        if (!first.EndsWith("/"))
        {
            return first;
        }
        if (gen.NextDouble() < chanceStrike)
        {
            return $"{first} X";
        }
        ball = gen.Next(0, 10);
        return $"{first} {SCORES[ball]}";
    }
}