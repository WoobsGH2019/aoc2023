using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using Microsoft.Win32.SafeHandles;

namespace AOC
{
   class Progam
   {
        static int SumOfTopRow(string argLine, int argCol)
        {
            bool addNumber = false;
            string numberBuff = "";
            int sum = 0;

            // This is super unsafe.  Input data doesn't have 'tricky' symbols near the edges
            // What if argCol had a value of 2.  The subsequent argCol-3 takes us out of bounds.
            for(int colIndex=(argCol-3); colIndex >= argCol - 3 && colIndex <= argCol + 3; colIndex++)
            {
                // Console.WriteLine($"colToCheck values: {argLine[colIndex]}");

                if(char.IsAsciiDigit(argLine[colIndex])) {
                    numberBuff += argLine[colIndex];
                    if(colIndex - argCol >= -1 && colIndex - argCol <= 1) {
                        addNumber = true;                        
                    }
                }
                else {
                    if(addNumber) {
                        sum += int.Parse(numberBuff);
                        addNumber = false;
                    }

                    numberBuff = "";
                }
            }

           if(addNumber) {
                sum += int.Parse(numberBuff);
            }

            return sum;
        }

        static int SumOfCurrentRow(string argLine, int argCol)
        {
            bool addNumber = false;
            string numberBuff = "";
            int sum = 0;
            
            for(int colIndex=(argCol-3); colIndex >= argCol -3 && colIndex <= argCol +3; colIndex++)
            {
                // Console.WriteLine($"colToCheck values: {argLine[colToCheck]}");

                if(char.IsAsciiDigit(argLine[colIndex])) {
                    numberBuff += argLine[colIndex];
                    if(colIndex - argCol >= -1 && colIndex - argCol <= 1) {
                        addNumber = true;                        
                    }
                }
                else {
                    if(addNumber) {
                        sum += int.Parse(numberBuff);
                        addNumber = false;
                    }
                   
                    numberBuff = "";
                }
            }

            if (addNumber)
            {
                sum += int.Parse(numberBuff);
            }

            return sum;
        }

        static int SumOfBottomRow(string argLine, int argCol)
        {
            bool addNumber = false;
            string numberBuff = "";
            int sum = 0;

            // This is super unsafe.  Input data doesn't have symbols near the edges
            // What if argCol had a value of 2.  The subsequent argCol-3 takes us out of bounds.
            for(int colIndex=(argCol-3); colIndex >= argCol - 3 && colIndex <= argCol + 3; colIndex++)
            {
                // Console.WriteLine($"colToCheck values: {argLine[colToCheck]}");

                if(char.IsAsciiDigit(argLine[colIndex])) {
                    numberBuff += argLine[colIndex];
                    if(colIndex - argCol >= -1 && colIndex - argCol <= 1) {
                        addNumber = true;
                    }
                }
                else {
                    if(addNumber) {
                        sum += int.Parse(numberBuff);
                        addNumber = false;
                    }

                    numberBuff = "";
                }
            }

            if (addNumber)
            {
                sum += int.Parse(numberBuff);
            }

            return sum;
        }

        static void CollectGears(string argLine, int argCol, ref int argHitCount, ref List<int> argGearValues)
        {
           bool addNumber = false;
           string numberBuff = "";

            // Again, super unsafe.  We get to cheat with the sample file the way it is structured.
            for (int colIndex = (argCol - 3); colIndex >= argCol - 3 && colIndex <= argCol + 3; colIndex++)
            {
                // Console.WriteLine($"colToCheck2 values: {argLine[colIndex]}");

                if (char.IsAsciiDigit(argLine[colIndex]))
                {
                    numberBuff += argLine[colIndex];
                    if (colIndex - argCol >= -1 && colIndex - argCol <= 1)
                    {
                        addNumber = true;
                    }
                }
                else
                {
                    if(addNumber)
                    {
                        // Console.WriteLine($"Adding numberBuff: {numberBuff}");
                        argHitCount++;
                        argGearValues.Add(Int32.Parse(numberBuff));
                        addNumber = false;
                    }

                    numberBuff = "";
                }
            }

            if (addNumber)
            {
                // Console.WriteLine($"Adding numberBuff2: {numberBuff}");
                argHitCount++;
                argGearValues.Add(Int32.Parse(numberBuff));
            }
        }
        static int Main(string[] args)
        {
            string path, line;
            string[] data;
            int hitCount, part1TotalSum = 0, part2GearRatio = 0;
            List<char> symbols = new List<char>();
            List<int> gearValues = new List<int>();

            // File handling
            try
            {
                if(args.Length == 0){
                    path = @"./input/sampleData";
                }
                else {
                    path = args[0];
                }

                if (!File.Exists(path)) {
                    Console.WriteLine($"File doesn't exist at {path}");
                    System.Environment.Exit(1);
                }

                data = File.ReadAllLines(path, System.Text.Encoding.UTF8);
            }
            catch (System.Exception)
            {
                throw;
            }

            // Logic
            // Grab 'symbols' for part 1
            for(int r=0; r<data.Length; r++)
            {
                line = data[r];

                for(int c=0; c<line.Length; c++)
                {
                    if(line[c] != '.')
                    {
                        if (char.IsDigit(line[c])) {
                        }
                        else {
                            if(!symbols.Contains(line[c]))
                            {
                                symbols.Add(line[c]);
                                // Console.WriteLine($"Adding {line[c]}");
                            }
                        }
                    }                        
                }
            }

            // Parse and sum the parts.
            for (int row = 0; row < data.Length; row++)
            {
                line = data[row];
                // Console.WriteLine(line);

                for (int col = 0; col < line.Length; col++)
                {
                    foreach(char symbol in symbols)
                    {
                        if(line[col] == symbol) {
                            // Console.WriteLine($"In row {row} and column {col}.  We're in symbols {symbol}");

                            part1TotalSum += SumOfTopRow(data[row - 1], col);
                            // Console.WriteLine($"Sum from top row: {totalSum}.");

                            part1TotalSum += SumOfCurrentRow(line, col);
                            // Console.WriteLine($"Sum from current row: {totalSum}");

                            part1TotalSum += SumOfBottomRow(data[row + 1], col);
                            // Console.WriteLine($"Sum from bottom row: {totalSum}");
                        }
                    }
                }
            }

            // Part 2
            for(int row = 0; row < data.Length; row++)
            {
                line = data[row];

                for(int col = 0; col < line.Length; col++)
                {
                    hitCount = 0;

                    if(line[col] == '*') {
                        CollectGears(data[row-1], col, ref hitCount, ref gearValues);
                        CollectGears(line,col, ref hitCount, ref gearValues);
                        CollectGears(data[row+1], col, ref hitCount, ref gearValues);

                        if(hitCount == 2)
                        {
                            // Console.WriteLine($"Multiply {gearValues[0]} & {gearValues[1]}");
                            part2GearRatio += gearValues[0] * gearValues[1];
                        }

                        gearValues.Clear();
                    }
                }
            }
            Console.WriteLine($"Part 1 sum: {part1TotalSum}");
            Console.WriteLine($"Part 2 gear ratio: {part2GearRatio}");

            //Part 2 Sample: 467835
            return 0;
        }
    } 
}
