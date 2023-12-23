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
            int sumOfPoints = 0, startingWinDigits, endingWinDigits, calcPoints;
            List<int> winningNumbers = new List<int>();
            List<int> drawNumbers = new List<int>();

            // For tracking
            // List<string> cardData = new List<string>();

            // WES: Try\Catch against the entire code block is problematic isn't it?  
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

                using (StreamReader reader = new StreamReader(inputData))
                {
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if(!System.String.IsNullOrWhiteSpace(line))
                        {
                            // Split on the colon to separate the Card # & numbers.
                            splitStrings = line.Split(':');
                            // cardData.Add(splitStrings[0]);

                            splitStrings = splitStrings[1].TrimStart().Split('|');

                            foreach(string digits in splitStrings[0].TrimStart().Split(' '))
                            {
                                if(!System.String.IsNullOrWhiteSpace(digits)){
                                    winningNumbers.Add(Int32.Parse(digits));
                                }
                            }

                            foreach(string digits in splitStrings[1].TrimStart().Split(' '))
                            {
                                if(!System.String.IsNullOrWhiteSpace(digits)) {
                                    drawNumbers.Add(Int32.Parse(digits));
                                }
                            }

                            // winningNumbers.Sort();
                            // drawNumbers.Sort();

                            IEnumerable<int> exceptions = winningNumbers.Except(drawNumbers);

                            startingWinDigits = winningNumbers.Count;
                            endingWinDigits = exceptions.Count();
                            calcPoints = startingWinDigits - endingWinDigits;

                            // Console.WriteLine($"Staring Digits({startingWinDigits}) - Ending Digits({endingWinDigits}) = {calcPoints}");

                            switch(calcPoints) 
                            {
                                // case 0:
                                    // break;
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

                            winningNumbers.Clear();
                            drawNumbers.Clear();

                        }
                        else
                        {
                            // Console.WriteLine("Reached EOF!");
                        }
                    }

                    Console.WriteLine($"Sum of the total points: {sumOfPoints}");

                    // TODO: Check using statement and reader.Close() best practice
                    // I think in this iteration, we don't need the Close as it "closes" once it leaves the using { }
                    reader.Close();
                }

            }
            catch {
                throw;
            }

           // TO LOW: 4898.  26,914 JUST RIGHT!!
        }
    }
}