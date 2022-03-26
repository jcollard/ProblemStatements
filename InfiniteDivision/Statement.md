# Title

# Statement
The purpose of this problem is to compute all the decimals of the division between 2 integers. a / b
the result will be given in a specific format x.y(z) where x is the integer part of the result, y is the finite decimal part of the result decimal, and z the infinite part (cycling) of the the division.

Example
11 / 24 = 0.45833333333......
the integer part x = 0
the finite part y = 458
the cyclic part z = 3
the result will be printed : 0.458(3)

Notes:
the finite part may not exist, for example 1/3 -> 0.(3)
the cyclic part is always printed even if it's 0, for example 4/2 -> 2.(0)

# Input description
<<Line 1:>> An integer [[N]] specifying the number of games to score
<<Next [[N]] lines:>> A string containing 10 frames each separated by a space

# Output description
<<[[N]] lines:>> Each line contains 10 integers separated by a single space representing the cumulative score for each frame of that game

# Constraints
1 <= [[N]] <= 10

# Test 1
Input

Output

# Validator 1


# Test 2

# Validator 2

# Test 3

# Validator 3

# Test 4

# Validator 4

# Solution 


# Generator

read N:int
loop N read GAME:string(6)
write 5 13 18 26 31 32 34 40 47 54