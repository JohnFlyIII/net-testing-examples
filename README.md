# net-testing-examples

A step by step example of incremental progress of a fictictional Calculator implementation and strategies to test it as it grows in complexity.

Each part will have its own source and test projects located in /part-X/src and /part-X/test
Each part will also have scripts to execute build and tests located in /part-X/scripts


## Calculator initial requirements

Build a web based calculator that can perform basic operations.

The calculator should allow the user to:

1) Add two values together
2) Subtract one number from another
3) Calculate the area of a circle given its radius

Expected UI would show sigle ditgits from 0 through 9
as well as a "+", "-", and button to represent the area of a circle calcualtion.

## Part-1

Part 1 will focus on building a basic classs library to hold the logic for the calculations.

## Part-2

Will introduce the UI & API

## Part-3

Introduce "enhancements": adding a database to store values of mathmatical constants so they can be updated with better or more accurate values without requiring code updates.

## Part-4

Further enhance the code to cover edge cases, overflows, underflows, and add test cases to cover those