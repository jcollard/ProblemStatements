# Title
10 pin Bowling Scores

# Statement

A game of 10 pin bowling is played over the course of 10 frames. 
At the beginning of each frame, 10 pins are arranged at the end of a bowling lane. 
Each frame, The bowler receives 2 attempts to roll a bowling ball down the lane and knock over as many pins as possible.

Scoring works in the following way:

1. The bowler scores 1 point for each pin they knock down in a frame.

2. If all of the pins are knocked down on the second attempt, the bowler receives a Spare. This is worth 10 points plus 1 point for every pin knocked down by the bowler's next ball. For example:

  * In the 1st frame, a bowler knocks down 8 pins with their first ball and the remaining 2 pins with their second ball and receives a Spare. In the second frame, the bowler knocks down 6 pins with their first ball and 3 pins with their second ball. The points earned in the first frame is 16 (10 + 6). 10 from the pins from the first frame and 6 from the first ball in the second frame.

3. If all of the pins are knocked down on the first attempt, the bowler receives a Strike. This is worth 10 points plus 1 point for every pin knocked down by the bowler's next two balls. For example:

  * In the 1st frame, a bowler knocks down all 10 pins with their first ball and receives a Strike. In the second frame, they knock down 6 pins with their first ball and 3 pins with their second ball. The points earned from the first frame is 19 (10 + 6 + 3).

Another example:

  * In the second frame, a bowler knocks down all 10 pins with their first ball and receives a Strike. In the third frame, they knock down all the pins with their first ball receiving a second Strike. In the fourth frame, they knock down 7 pins with their first ball and the remaining 3 pins with their second ball. The points earned from the second frame is 27 (10 + 10 + 7). The points earned from the third frame is 19 (10 + 7 + 3).

Final Frame:

In the 10th frame of a bowling game, there are 3 possible outcomes:

1. The bowler does not knock down all of the pins with their 2 attempts. At this point, they can earn no additional points.

2. The bowler scores a Spare with their second ball. This results in a new set of 10 pins being set and the bowler receives 1 bonus roll to add to their score.

3. The bowler scores a Strike with their first ball. This results in a new set of 10 pins being set and the bowler receives 2 bonus rolls to add to their score.

  3a. If on the first bonus ball the bowler knocks down all of the pins, they receive 10 bonus points for the 10th frame. A new set of 10 pins is set and they are allowed to roll their last bonus ball to be added to their score. The pins knocked down from this last ball are only added as a bonus once to the Strike that was thrown with the first ball in the 10th frame.

Example:

In the 10th frame, a bowler scores a strike with their first ball, a strike with their first bonus ball, and 7 pins with their second bonus ball. The points earned from the 10th frame is 27 (10 + 10 + 7).

Task: Write a program that can calculate the cumulative points earned for each frame in a bowling game.

Score notation for each ball roll:

X => Strike
/ => Spare
- => Zero Points
[[K]] => An integer representing the number of pins knocked down

Example Input:

`X X 9 - 7 / - 1 8 1 - - 9 / X X 7 -`

Example Output:
`29 48 57 67 68 77 77 97 124 141`


# Input description
<<Line 1:>> An integer [[N]] specifying the number of games to score
<<Next [[N]] lines:>> A string containing the result of each ball rolled over the course of 10 frames

# Output description
<<[[N]] lines:>> Each line contains 10 integers separated by a single space representing the cumulative score for each frame of that game

# Constraints
2 <= [[N]] <= 100

# No Strikes or Spares
1
3 2 7 1 2 3 4 4 5 - 1 - 1 1 1 5 1 6 7 -

5 13 18 26 31 32 34 40 47 54

# Validator 1
1
5 1 4 3 8 - 7 2 6 - 5 1 6 1 6 1 5 2 9 -

6 13 21 30 36 42 49 56 63 72

# Spares
5
3 2 7 / 6 / 3 / 1 1 9 / 1 - 1 / 2 / 5 -
- / 5 - 5 2 5 2 7 2 7 1 1 / 5 1 3 / 3 / -
7 / - / 5 / 7 2 7 / 2 2 6 / - 7 7 / - -
4 4 1 / 2 / - / - 9 8 1 2 / 1 2 7 / 5 / 6
1 / 1 / 5 / 2 / 3 / 5 / 5 / - / 5 / 1 6

5 21 34 45 47 58 59 71 86 91
15 20 27 34 43 51 66 72 85 95
10 25 42 51 63 67 77 84 94 94
8 20 30 40 49 58 69 72 87 103
11 26 38 51 66 81 91 106 117 124

# Validator 2
5
5 / 1 / 5 4 4 / 7 2 4 / 5 1 6 1 6 1 5 2
3 - 6 / 7 / 6 - 3 / 3 / 3 / 8 / 7 2 - / 6
- / 1 / 5 / 9 - 3 6 3 / - / 7 / 1 / - 2
7 / 7 - 5 1 5 / 1 / 3 6 3 / 7 / 3 / 5 2
4 / 2 6 4 / 3 4 5 / 3 / 5 / 5 / 8 / 3 / 4

11 26 35 52 61 76 82 89 96 103
3 20 36 42 55 68 86 103 112 128
11 26 45 54 63 73 90 101 111 113
17 24 30 41 54 63 80 93 108 115
12 20 33 40 53 68 83 101 114 128

# Strikes
5
X 5 / X 5 / 8 / 6 3 7 / - / 8 / 6 1
3 - 6 / X 5 / 9 / X 3 / 7 / 6 / - / 9
X X X 1 / 5 / X 8 / 3 6 3 / X X 6
7 / 7 - X 7 / X 2 / X 8 / 9 - 6 1
X 7 / 9 - 3 / 8 / 5 / X 5 2 X 5 / 8

20 40 60 78 94 103 113 131 147 154
3 23 43 62 82 102 119 135 145 164
30 51 71 86 106 126 139 148 168 194
17 24 44 64 84 104 124 143 152 159
20 39 48 66 81 101 118 125 145 163

# Validator 3
5
3 2 7 / 6 / X 2 / X 1 / 1 1 1 / X 1 /
X X X X 8 / X 8 / 5 2 X 8 1
7 / - / 5 / 7 2 7 / 2 2 6 / - 7 7 / - -
X 8 / 1 / X 1 - X - 9 8 1 2 / 1 2
1 / 1 / 5 / 2 / 3 / 5 / 5 / X X 8 / X

5 21 41 61 81 101 112 114 134 154
30 60 88 108 128 148 163 170 189 198
10 25 42 51 63 67 77 84 94 94
20 31 51 62 63 82 91 100 111 114
11 26 38 51 66 81 101 129 149 169

# Strikes and Spares
5
3 / X 7 / X X X X X X X X 1
X X X X X - / X 4 / X 4 / 8
X X X - / X X X X X 8 / 5
X X 7 / X X X X X - / - / 6
X X X X X X X X X 2 / X

20 40 60 90 120 150 180 210 240 261
30 60 90 110 130 150 170 190 210 228
30 50 70 90 120 150 180 208 228 243
27 47 67 97 127 157 177 197 207 223
30 60 90 120 150 180 210 232 252 272

# Validator 4

5
X X X X X X - / X 1 / 8 / X
X X 3 / X X X X X X X X X
X X X X X X X X X X X X
X X X - / X X X X X X X X
X X X X X X X X X X - /

30 60 90 120 140 160 180 200 218 238
23 43 63 93 123 153 183 213 243 273
30 60 90 120 150 180 210 240 270 300
30 50 70 90 120 150 180 210 240 270
30 60 90 120 150 180 210 240 260 280

# Solution 

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


# Generator

read N:int
loop N read GAME:string(6)
write 5 13 18 26 31 32 34 40 47 54