﻿// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

namespace AOC
{
  class Program
  {
    static void Main(string[] args)
    {
      Int64 tempDestination;
      Int64 minSoilDestination, minFertilizerDestination, minWaterDestination, minLightDestination, minTemperatureDestination, minHumidityDestination, minLocationDestination;
      int blockCount = 0, blockEntryCount = 0;
      string path, seedValues;
      string? line = String.Empty;
      List<Int64> seedList = new List<Int64>();
      List<Int64> locationList = new List<Int64>();

      // For future me.... this is disgusting.  Maybe linked list in the class to dynamically handle the various elements
      DataMap[] soilMap = new DataMap[23].Select(sm => new DataMap()).ToArray();
      DataMap[] fertilizerMap = new DataMap[40].Select(fm => new DataMap()).ToArray();
      DataMap[] waterMap = new DataMap[14].Select(wm => new DataMap()).ToArray();
      DataMap[] lightMap = new DataMap[46].Select(lm => new DataMap()).ToArray();
      DataMap[] tempMap = new DataMap[35].Select(tm => new DataMap()).ToArray();
      DataMap[] humidityMap = new DataMap[28].Select(hm => new DataMap()).ToArray();
      DataMap[] locationMap = new DataMap[42].Select(lm => new DataMap()).ToArray();



      // File handling
      try
      {
        if (args.Length == 0)
        {
          path = @"../input/inputData";
        }
        else
        {
          path = args[0];
        }

        using (StreamReader reader = new(path))
        {
          line = reader.ReadLine();
          if(line != null) 
          {
            if(line.Contains(':'))
            {
              seedValues = line.Split(':')[1];
              seedValues = seedValues.TrimStart();
              foreach(string seed in seedValues.Split(' '))
              {
                seedList.Add(Int64.Parse(seed));
              }
            }
          }

          while (line != null)
          {
            line = reader.ReadLine();
            if (!String.IsNullOrWhiteSpace(line))
            {
              if(line.Contains(":"))
              {
                blockCount++;
                blockEntryCount = 0;
                continue;
              }

              switch(blockCount)
              {
                case 1:
                  soilMap[blockEntryCount].SaveData(line);
                  blockEntryCount++;
                  break;
                case 2:
                  fertilizerMap[blockEntryCount].SaveData(line);
                  blockEntryCount++;
                  break;
                case 3:
                  waterMap[blockEntryCount].SaveData(line);
                  blockEntryCount++;
                  break;
                case 4:
                  lightMap[blockEntryCount].SaveData(line);
                  blockEntryCount++;
                  break;
                case 5:
                  tempMap[blockEntryCount].SaveData(line);
                  blockEntryCount++;
                  break;
                case 6:
                  humidityMap[blockEntryCount].SaveData(line);
                  blockEntryCount++;
                  break;
                case 7:
                  locationMap[blockEntryCount].SaveData(line);
                  blockEntryCount++;
                  // Console.WriteLine($"Case 7: With line {line} with blockCount {blockCount} and blockEntryCount {blockEntryCount}.");
                  break;

              }
            }
          }
        }
      }
      catch
      {
        throw;
      }

      //Now that we have all the data, let's perform the lookups.
      foreach(Int64 seed in seedList)
      {
        Console.Write($"Seed {seed}, ");

        minSoilDestination = -1;
        foreach(DataMap soil in soilMap)
        {
          if(soil.CheckRange()) {
            tempDestination = soil.CheckSource(seed);

            // Gets us out of minimum soil destination of -1
            if(tempDestination >= 0 && minSoilDestination == -1) {
              minSoilDestination = tempDestination;
            }

            // Need to find the smallest destination
            if(tempDestination < minSoilDestination && tempDestination != -1) {
              // minSoilDestination = tempDestination;
            }
          }
        }

        // Set mininimum to self if not within any ranges.
        if(minSoilDestination == -1) {
          minSoilDestination = seed;
        }

        Console.Write($"soil {minSoilDestination}, ");

        minFertilizerDestination = -1;
        foreach(DataMap fertilizer in fertilizerMap)
        {
          if(fertilizer.CheckRange()) {
            tempDestination = fertilizer.CheckSource(minSoilDestination);

            if(tempDestination >= 0 && minFertilizerDestination == -1) {
              minFertilizerDestination = tempDestination;
            }

            if(tempDestination < minFertilizerDestination && tempDestination != -1) {
              // minFertilizerDestination = tempDestination;
            }
          }
        }

        if(minFertilizerDestination == -1) {
          minFertilizerDestination = minSoilDestination;
        }
        
        Console.Write($"fertilizer {minFertilizerDestination}, ");


        minWaterDestination = -1;
        foreach(DataMap water in waterMap)
        {
          if(water.CheckRange()) {
            tempDestination = water.CheckSource(minFertilizerDestination);

            if(tempDestination >= 0 && minWaterDestination == -1) {
              minWaterDestination = tempDestination;
            }

            if(tempDestination < minWaterDestination && tempDestination != -1) {
              // minWaterDestination = tempDestination;
            }
          }
        }
        
        if(minWaterDestination == -1) {
          minWaterDestination = minFertilizerDestination;
        }

        Console.Write($"water {minWaterDestination}, ");

        minLightDestination = -1;
        foreach(DataMap light in lightMap)
        {
          if(light.CheckRange()) {
            tempDestination = light.CheckSource(minWaterDestination);

            if(tempDestination >= 0 && minLightDestination == -1) {
              minWaterDestination = tempDestination;
            }

            if(tempDestination < minLightDestination && tempDestination != -1) {
              // minWaterDestination = tempDestination;
            }
          }
        }

        if(minLightDestination == -1) {
          minLightDestination = minWaterDestination;
        }

        Console.Write($"light {minLightDestination}, ");

        minTemperatureDestination = -1;
        foreach(DataMap temp in tempMap)
        {
          if(temp.CheckRange()) {
            tempDestination = temp.CheckSource(minLightDestination);

            if(tempDestination >= 0 && minTemperatureDestination == -1) {
              minTemperatureDestination = tempDestination;
            }

            if(tempDestination < minTemperatureDestination && tempDestination != -1) {
              // minTemperatureDestination = tempDestination;
            }
          }
        }
        
        if(minTemperatureDestination == -1) {
          minTemperatureDestination = minLightDestination;
        }

        Console.Write($"temperature {minTemperatureDestination}, ");

        minHumidityDestination = -1;
        foreach(DataMap humidity in humidityMap)
        {
          if(humidity.CheckRange()) {
            tempDestination = humidity.CheckSource(minTemperatureDestination);

            if(tempDestination >= 0 && minHumidityDestination == -1) {
              minHumidityDestination = tempDestination;
            }

            if(tempDestination < minHumidityDestination && tempDestination != -1) {
              // minHumidityDestination = tempDestination;
            }
          }
        }
        
        if(minHumidityDestination == -1) {
          minHumidityDestination = minTemperatureDestination;
        }

        Console.Write($"humidity {minHumidityDestination}, ");

        minLocationDestination = -1;
        foreach(DataMap location in locationMap)
        {
          if(location.CheckRange()) {
            tempDestination = location.CheckSource(minHumidityDestination);

            if(tempDestination >= 0 && minLocationDestination == -1) {
              minLocationDestination = tempDestination;
            }

            if(tempDestination < minLocationDestination && tempDestination != -1) {
              // minLocationDestination = tempDestination;
            }
          }
        }
        if(minLocationDestination == -1) {
          minLocationDestination = minHumidityDestination;
        }

        Console.WriteLine($"location {minLocationDestination}.");

        locationList.Add(minLocationDestination);
      }

      Console.WriteLine($"Minimum location: {locationList.Min()}.");
      locationList.Sort();
      foreach(Int64 i in locationList)
      {
        Console.WriteLine($"{i}");
      }
      // Console.WriteLine($"Sorted Locations: {locationList}");
    }
  }
}
