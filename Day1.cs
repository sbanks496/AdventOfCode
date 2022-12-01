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
    public static void Part2(string fileName, int topElves)
    {
        string[] lines = ReadFromFile.ReadLines(fileName);
        int runningTotal = 0;
        List<Tuple<int,int>> elfSnacks = new List<Tuple<int,int>> { new (0,0)};
        int step = 1;
        foreach (string line in lines)
        {
            if (line == "")
            {
                elfSnacks.Add(new(runningTotal, step));
                step += 1;
                runningTotal = 0;
            }
            else
            {
                runningTotal += int.Parse(line);
            }
        }
        elfSnacks.Sort((x, y) => y.Item1.CompareTo(x.Item1));
        int topSnacks = 0;
        for (int i = 1; i <= topElves; i++)
        {
            Console.WriteLine(string.Join(',', elfSnacks[i-1]));
            topSnacks += elfSnacks[i - 1].Item1;
        }
        Console.Write(topSnacks);
    }

}