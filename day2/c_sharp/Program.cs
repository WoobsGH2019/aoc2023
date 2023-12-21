// See https://aka.ms/new-console-template for more information
// AOC: https://adventofcode.com/2023/day/2
// AOC Part deux: https://adventofcode.com/2023/day/2#part2
// Input: https://adventofcode.com/2023/day/2/input

using System.IO;
using System.Collections.Immutable;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Reflection.Metadata;

namespace AOC
{
    class MyProgram
    {
        static void Main(string[] args)
        {
            // string path = @"./input/part1Sample";
            string path = @"./input/part1Data";
            
            string[] data;

            // Pattern matching against the elf draws.  Retrieves the number of cubes of each color.
            const string RED = "\\d* red", GREEN = "\\d* green", BLUE = "\\d* blue";

            // Part 1
            const int REDLIMIT = 12, GREENLIMIT = 13, BLUELIMIT = 14;
            // Part 2
            int maxRed, maxGreen, maxBlue;

            int gameNumber = 0, redCubesDrawn = 0, greenCubesDrawn = 0, blueCubesDrawn = 0;
            string gameInfo = "", cubeDraws = "";
            int drawCount, startIndex = 0, sumOfGames = 0, sumOfPowerOfDraws = 0;
            string[] draw;
            bool goodGame;
            Match patternMatch;

            if(!System.IO.File.Exists(path)) {
                Console.WriteLine($"File does not exist at {path}.");
                System.Environment.Exit(1);
            }

            try
            {
                data = File.ReadAllLines(path, System.Text.Encoding.UTF8);
            }
            catch (System.Exception)
            {
                
                throw;
            }

            // Logic & Impl

            foreach(string line in data)
            {
                gameInfo = line.Split(':')[0];
                cubeDraws = line.Split(':')[1];

                goodGame = true;
                maxRed = maxGreen = maxBlue = 0;
                startIndex = gameInfo.LastIndexOf(' ');
                gameNumber = int.Parse(gameInfo.Substring(startIndex, (gameInfo.Length-startIndex)));

                drawCount = 0;
                foreach(char character in cubeDraws)
                {
                    if(character == ';') {
                        drawCount++;
                    }
                }

                draw = cubeDraws.Split(';');
                for(int count = 0; count <= drawCount; count++)
                {
                    patternMatch = Regex.Match(draw[count], RED);
                    if(patternMatch.Success) {
                        redCubesDrawn = int.Parse((patternMatch.Value).Split(' ')[0]);

                        if(redCubesDrawn > REDLIMIT) {
                            goodGame = false;
                        }

                        if(redCubesDrawn > maxRed) {
                            maxRed = redCubesDrawn;
                        }
                    }

                    patternMatch = Regex.Match(draw[count], GREEN);
                    if(patternMatch.Success) {
                        greenCubesDrawn = int.Parse((patternMatch.Value).Split(' ')[0]);

                        if(greenCubesDrawn > GREENLIMIT) {
                            goodGame = false;
                        }

                        if(greenCubesDrawn > maxGreen) {
                            maxGreen = greenCubesDrawn;
                        }
                    }

                    patternMatch = Regex.Match(draw[count], BLUE);
                    if(patternMatch.Success) {
                        blueCubesDrawn = int.Parse((patternMatch.Value).Split(' ')[0]);

                        if(blueCubesDrawn > BLUELIMIT) {
                            goodGame = false;
                        }

                        if(blueCubesDrawn > maxBlue) {
                            maxBlue = blueCubesDrawn;
                        }
                    }
                }

                if(goodGame) {
                    sumOfGames += gameNumber;
                }

                sumOfPowerOfDraws += maxRed * maxGreen * maxBlue;
            }

            Console.WriteLine($"Sum of games is {sumOfGames}");
            Console.WriteLine($"Sum of power of draws is {sumOfPowerOfDraws}");
        }
    }
}
