namespace AdventOfCode;

public class Day1
{
    public static void Part1(string fileName)
    {
        string[] lines = ReadFromFile.ReadLines(fileName);
        int runningTotal = 0;
        int[] maxTotal = {0,0};
        int step = 1;
        foreach (string line in lines)
        {
            if (line == "")
            {
                if (runningTotal > maxTotal[0])
                {
                    maxTotal = new [] {runningTotal, step};
                }
                step += 1;
                runningTotal = 0;
            }
            else
            {
                runningTotal += int.Parse(line);
            }
        }
        Console.WriteLine(string.Join(',', maxTotal));
    }
}