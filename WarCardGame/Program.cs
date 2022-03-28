// https://www.codingame.com/ide/puzzle/winamax-battle
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{

    static readonly string values = "234567891TJQKA";

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        Queue<char> Player1 = new Queue<char>();
        Queue<char> Player2 = new Queue<char>();
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            Player1.Enqueue(cardp1[0]);

        }
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            Player2.Enqueue(cardp2[0]);
        }
        int rounds = 0;
        while (Player1.Count > 0 && Player2.Count > 0)
        {
            rounds++;
            List<char> p1Cards = new List<char>();
            List<char> p2Cards = new List<char>();
            char p1, p2;
            do {
                p1 = Player1.Dequeue();
                p2 = Player2.Dequeue();
                p1Cards.Add(p1);
                p2Cards.Add(p2);
                if (p1 == p2) 
                {
                    if (Player1.Count < 4 || Player2.Count < 4)
                    {
                        Console.WriteLine($"PAT");
                        return;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        p1Cards.Add(Player1.Dequeue());
                        p2Cards.Add(Player2.Dequeue());
                    }
                }
            } while (p1 == p2);
            int p1Val = values.IndexOf(p1);
            int p2Val = values.IndexOf(p2);
            Queue<char> winner = p1Val > p2Val ? Player1 : Player2;
            p1Cards.ForEach(winner.Enqueue);
            p2Cards.ForEach(winner.Enqueue);            
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        int w = Player1.Count > 0 ? 1 : 2;
        Console.WriteLine($"{w} {rounds}");
    }
}