// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.IO;

namespace AOC
{
  class Program
  {
    static void Main(string[] args)
    {
      string path, seedValues;
      string? line = String.Empty;
      List<int> seedList = new List<int>();

      // File handling
      try
      {
        if (args.Length == 0)
        {
          path = @"../input/sampleData";
        }
        else
        {
          path = args[0];
        }

        using (StreamReader reader = new(path))
        {
          // First line with seed is the only line with the topic and numbers.
          line = reader.ReadLine();
          if(line != null) 
          {
            if(line.Contains(':'))
            {
              seedValues = line.Split(':')[1];
              seedValues = seedValues.TrimStart();
              foreach(string seed in seedValues.Split(' '))
              {
                seedList.Add(Int32.Parse(seed));
              }
            }
          }

          while (line != null)
          {
            line = reader.ReadLine();
            if (!String.IsNullOrWhiteSpace(line))
            {
              foreach(int seed in seedList)
              {
                Console.WriteLine($"Seed {seed}.");
              }
            }
          }
        }
      }
      catch
      {
        throw;
      }
    }
  }
}
