namespace AOC
{
  class DataMap
  {
    private Int64 destination { get; set; }
    private Int64 source { get; set; }
    private Int64 range { get; set; }

    public DataMap()
    {
      destination = 0;
      source = 0;
      range = 0;
    }

    // Create sort function so we can efficently look where to send previous lookups?

    public void SaveData(string argData)
    {
      Int64 destinationData, sourceData, rangeData;

      destinationData = Int64.Parse(argData.Split(' ')[0]);
      sourceData = Int64.Parse(argData.Split(' ')[1]);
      rangeData = Int64.Parse(argData.Split(' ')[2]);

      destination = destinationData;
      source = sourceData;
      range = rangeData;
    }

    // This prevents us from looking at initialized empty elements.... gross.
    public bool CheckRange()
    {
      if(range > 0) {
        return true;
      }
      else {
        return false;
      }
    }

    public void PrintData()
    {
      Console.WriteLine($"Destination: {destination}; Source: {source}; Range: {range}");
    }

    public Int64 CheckSource(Int64 argValueToCheck)
    {
      Int64 result;
      Int64 ceiling = source + range;

      if(argValueToCheck >= source && argValueToCheck < ceiling)
      {
        result = (destination - source) + argValueToCheck;
        //Console.WriteLine($"Result: {result}.");
        return result;
      }
      else
      {
        return -1;
      }
    }


  }
}
