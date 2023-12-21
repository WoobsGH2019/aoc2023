using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

// https://adventofcode.com/2023/day/1

bool isNumber = false;
int number, lineNumber = 0, sum;
int[] digitCollection = new int[1000];
string[] sToNumPatterns = { "one\\z", "two\\z", "three\\z", "four\\z", "five\\z", "six\\z", "seven\\z", "eight\\z", "nine\\z" };
Match patternMatch;
string firstDigit = System.String.Empty;
string secondDigit = System.String.Empty;
string? line = System.String.Empty;
string lex = "";


#region part2
try
{
    using (StreamReader reader = new StreamReader(@"/home/user/repos/aoc2023/day1/c_sharp/input/part2Data"))
    {
        while(line != null)
        {
            line = reader.ReadLine();
            if(!System.String.IsNullOrWhiteSpace(line)) {
                for(int pos=0; pos<line.Length; pos++) 
                {
                    System.ReadOnlySpan<char> character = line[pos].ToString();
                    isNumber = Int32.TryParse(character, out number);

                    if(isNumber && System.String.IsNullOrWhiteSpace(firstDigit)) {
                        firstDigit = number.ToString();
                        lex = "";
                    }
                    else if (isNumber && !System.String.IsNullOrWhiteSpace(firstDigit)) {
                        secondDigit = number.ToString();
                        lex = "";
                    }
                    else {
                        lex += line[pos];

                        foreach(string stringToMatch in sToNumPatterns)
                        {
                            patternMatch = Regex.Match(lex, stringToMatch);
                            if(patternMatch.Success)
                            {
                                // Console.WriteLine($"Match found {stringToMatch} in {lineNumber} with result {patternMatch.Value}.");
                                switch (patternMatch.Value)
                                {
                                    case "one":
                                        // Console.WriteLine("Detected one");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "1";
                                        }
                                        else {
                                            secondDigit = "1";
                                        }

                                        break;
                                    case "two":
                                        // Console.WriteLine("Detected two");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "2";
                                        }
                                        else {
                                            secondDigit = "2";
                                        }

                                        break;
                                    case "three":
                                        // Console.WriteLine("Detected three");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "3";
                                        }
                                        else {
                                            secondDigit = "3";
                                        }

                                        break;
                                    case "four":
                                        // Console.WriteLine("Detected four");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "4";
                                        }
                                        else {
                                            secondDigit = "4";
                                        }

                                        break;
                                    case "five":
                                        // Console.WriteLine("Detected five");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "5";
                                        }
                                        else {
                                            secondDigit = "5";
                                        }

                                        break;
                                    case "six":
                                        // Console.WriteLine("Detected six");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "6";
                                        }
                                        else {
                                            secondDigit = "6";
                                        }

                                        break;
                                    case "seven":
                                        // Console.WriteLine("Detected seven");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "7";
                                        }
                                        else {
                                            secondDigit = "7";
                                        }

                                        break;
                                    case "eight":
                                        // Console.WriteLine("Detected eight");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "8";
                                        }
                                        else {
                                            secondDigit = "8";
                                        }

                                        break;
                                    case "nine":
                                        // Console.WriteLine("Detected nine");
                                        if(System.String.IsNullOrWhiteSpace(firstDigit)) {
                                            firstDigit = "9";
                                        }
                                        else {
                                            secondDigit = "9";
                                        }

                                        break;
                                    default:
                                        // Console.WriteLine("No matches found.  Resume parsing");
                                        break;
                                }
                            }
                        }
                    }
                    // Console.WriteLine($"LineNumber is {lineNumber}");
                }

                //Reached end of line
                if(System.String.IsNullOrWhiteSpace(secondDigit)) {
                    secondDigit = firstDigit;
                }

                digitCollection[lineNumber] = Int32.Parse($"{firstDigit}{secondDigit}");
                // Console.WriteLine($"digitCollection[{lineNumber}] has a value of {digitCollection[lineNumber]}.");

                // Zero everything out before next ReadLine.
                firstDigit = System.String.Empty;
                secondDigit = System.String.Empty;
                lex = "";

                // Increment index
                lineNumber++;
            }
            else
            {
                Console.WriteLine("Reached EOF!");
            }
        }
    }

    // Console.WriteLine("Line numbers are as follows.");
    sum = 0;
    sum = digitCollection.Sum();

    // Console.WriteLine($"digitCollection has a length of {digitCollection.Length}");
    Console.WriteLine($"Part 2 sum: {sum}.");
}
catch (System.Exception)
{
    Console.WriteLine("Broad exception caught.  Make sure file exists and review variable assigments.");
    throw;
}
#endregion




#region part1

// bool sameLine, isDigit, isSingleDigitLine;
// int number, lineNumber = 0, sum = 0;
// int[] digitCollection = new int[1000];
// string digitBuff = "";

// try
// {
//     isSingleDigitLine = false;
//     sameLine = false;

//     foreach(string line in File.ReadLines(@"/home/robert/repos/aoc2023/day1/c_sharp/input/sampleData"))
//     {
//         for(int pos=0; pos < line.Length; pos++)
//         {
//             ReadOnlySpan<char> character = line[pos].ToString();
            
//             isDigit = int.TryParse(character, out number);

//             if(isDigit && sameLine == true) {
//                 // Console.WriteLine("First condition success!");
//                 digitBuff += number; //line[pos];
//                 isSingleDigitLine = false;
//             }
//             else if(isDigit && sameLine == false) {
//                 // Console.WriteLine("Second condition success!");
//                 digitBuff += number; //line[pos];
//                 sameLine = true;
//                 isSingleDigitLine = true;
//             }

//             if(pos == ((line.Length) - 1)) {
                
//                 if(isSingleDigitLine) {
//                     digitBuff += digitBuff;
//                     // Console.WriteLine("The value of single digitBuff is {0}", digitBuff);
//                 }
//                 else {
//                     if(digitBuff.Length > 2)
//                     {
//                         string tempBuf = "";
//                         tempBuf += digitBuff[0].ToString() + digitBuff[digitBuff.Length-1].ToString();
//                         digitBuff = "";
//                         digitBuff += tempBuf;
//                     }
//                     // Console.WriteLine("The value of digitBuff is {0}", digitBuff);
//                 }

//                 digitCollection[lineNumber] = Int32.Parse(digitBuff);
//                 // Console.WriteLine("digitCollection contains the following {0}", digitCollection[lineNumber]);
                
//                 lineNumber++;
//                 digitBuff = "";
//                 sameLine = false;
//             }
//         }
//     }

//     // Console.WriteLine("Line numbers are as follows.");
//     for(int index=0; index < digitCollection.Length; index++) {
//         sum += digitCollection[index];
//         // Console.WriteLine(digitCollection[index]);
//     }

//     Console.WriteLine($"The sum has a value of {sum}.");
// }
// catch (System.Exception)
// {
//     Console.WriteLine("Broad exception caught.  Make sure file exists and review variable assigments.");
//     throw;
// }
#endregion
    