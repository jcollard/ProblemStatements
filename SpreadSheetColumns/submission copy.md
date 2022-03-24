# Title
Find Spreadsheet Column Name

# Statement

Column names in a spreadsheet application are identified using a string containing capital letters ordered first by shortest length and then alphabetically. For example, the following list shows columns in ascending order:

`A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, AA, AB, ..., AX, AY, AZ, BA, ...`

Task: Given a string representing a column in a spreadsheet determine its position.

Example:

"A" => 0
"B" => 1
"AA" => 26
"AB" => 27
"AAA" => 702
"AAB" => 703

# Input description
<<Line 1:>> An integer [[N]] specifying the number of columns to determine.
<<Next [[N]] lines:>> A string, [[C_ID]] representing a column identifier

# Output description
A single line containing [[N]] integers separated by a single space with the associated column positions.

# Constraints
2 <= [[N]] <= 100
1 <= [[Length(C_ID)]] <= 6

# Test 1
3
A
B
C

0 1 2

# Validator 1
5
Q
D
D
N
E

16 3 3 13 4

# Test 2
5
BX
AK
AJ
BM
AM

75 36 35 64 38

# Validator 2

5
AO
BG
CJ
CC
BT

40 58 87 80 71

# Test 3

10
CQD
FZI
LIW
KDH
INS
BWV
CJR
AFF
ECI
BUM

2473 4740 8368 7547 6466 1971 2305 837 3466 1910

# Validator 3

10
JEY
BYK
BSX
HEY
CIG
DPX
JZB
HBL
CKC
KMG

6914 2012 1869 5562 2268 3143 7437 5471 2316 7780

# Test 4

10
GNFCJK
AOJMJY
AJVZEK
EWNHGX
AWLRJK
BYCQVW
HDTACO
ETQDKT
AXZNCK
HOOILX

89675050 18920848 16855524 70169005 22615174 35251966 97231200 68848201 23315328 102175707

# Validator 4

10
BCYKLJ
DWNZKP
IHDITN
HHFCOF
FZBDUP
ANBTNB
AXQLPY
DHBTO
CIIEVS
ALEFGU

25580837 58299893 110665113 98814695 83208049 18328077 23156144 1970398 39919066 17457226

# Solution 

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

# Generator

read N:int
loop N read CID:string(6)
write 0 1 2