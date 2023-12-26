// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// AOC 2023 : https://adventofcode.com/2023/day/4




using System.Linq;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputData;
            string? line = System.String.Empty;
            string[] splitStrings;
            int sumOfPoints = 0, currentPosition = 0, startingWinDigits, endingWinDigits, calcPoints, MAXSIZE;
            List<int> winningNumbers = new List<int>();
            List<int> drawNumbers = new List<int>();

            static void WinningScratches(ref int[] argScratches, int argCurrentPosition, int argWinningCount)
            {
                int valueToAdd = argScratches[argCurrentPosition];

                for(int count = 1; count <= argWinningCount; count++)
                {
                    // Console.WriteLine($"Doubling at pos {argCurrentPosition+count} with value {argScratches[argCurrentPosition+count]}.");
                    argScratches[argCurrentPosition + count] += valueToAdd;                                        
                }
            }

            // Try\Catch against the entire code block is problematic isn't it?  
            // Especially when I want to only try\catch the StreamReader
            // Day5, maybe using StreamReader reader = new StreamReader(...); <-- try\catch only this
            try {
                if(args.Length == 0)
                {
                    inputData = @"../input/sampleData";
                }
                else
                {
                    inputData = args[0];
                }


                MAXSIZE = File.ReadLines(inputData).Count();
                int[] scratchCards = new int[MAXSIZE];

                for (int index = 0; index < scratchCards.Length; scratchCards[index++] = 1);
                // Console.WriteLine($"scratchCard after initialization");

                using (StreamReader reader = new StreamReader(inputData))
                {
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (!System.String.IsNullOrWhiteSpace(line))
                        {
                            // Split to retrieve the list of numbers we want. 
                            splitStrings = line.Split(':');
                            splitStrings = splitStrings[1].TrimStart().Split('|');

                            foreach (string digits in splitStrings[0].TrimStart().Split(' '))
                            {
                                if (!System.String.IsNullOrWhiteSpace(digits))
                                {
                                    winningNumbers.Add(Int32.Parse(digits));
                                }
                            }

                            foreach (string digits in splitStrings[1].TrimStart().Split(' '))
                            {
                                if (!System.String.IsNullOrWhiteSpace(digits))
                                {
                                    drawNumbers.Add(Int32.Parse(digits));
                                }
                            }

                            IEnumerable<int> exceptions = winningNumbers.Except(drawNumbers);

                            startingWinDigits = winningNumbers.Count;
                            endingWinDigits = exceptions.Count();
                            calcPoints = startingWinDigits - endingWinDigits;

                            // Console.WriteLine($"Staring Digits({startingWinDigits}) - Ending Digits({endingWinDigits}) = {calcPoints}");

                            switch (calcPoints)
                            {
                                case 1:
                                    sumOfPoints += 1;
                                    break;

                                case 2:
                                    sumOfPoints += 2;
                                    break;

                                case 3:
                                    sumOfPoints += 4;
                                    break;

                                case 4:
                                    sumOfPoints += 8;
                                    break;

                                case 5:
                                    sumOfPoints += 16;
                                    break;

                                case 6:
                                    sumOfPoints += 32;
                                    break;

                                case 7:
                                    sumOfPoints += 64;
                                    break;

                                case 8:
                                    sumOfPoints += 128;
                                    break;

                                case 9:
                                    sumOfPoints += 256;
                                    break;

                                case 10:
                                    sumOfPoints += 512;
                                    break;

                                default:
                                    break;
                            }

                            // Console.WriteLine($"Win Count: {startingWinDigits}");
                            // Console.WriteLine($"Ending Count: {endingWinDigits}");
                            WinningScratches(ref scratchCards, currentPosition, calcPoints);

                            winningNumbers.Clear();
                            drawNumbers.Clear();
                            currentPosition++;

                        }
                    }

                    // foreach(int s in scratchCards)
                    // {
                    //     Console.WriteLine($"{s}.");
                    // }

                    Console.WriteLine($"Part 1 - Sum of the total points: {sumOfPoints}");
                    Console.WriteLine($"Part 2 - Sum of scratchcards: {scratchCards.Sum()}");

                    // TODO: Check using statement and reader.Close() best practice
                    // I think in this iteration, we don't need the Close as it "closes" once it leaves the using { }
                    reader.Close();
                }

            }
            catch {
                throw;
            }
        }
    }
}