namespace AdventOfCode;

public class Day4
{
    private const string FileName = "day4.txt";

    public static void Part1()
    {
        string[] lines = ReadFromFile.ReadLines(FileName);
        int runningTotal = 0;
        foreach (string line in lines)
        {
            HashSet<int>[] lsets = GetSections(line.Split(','));
            if (lsets[0].Union(lsets[1]).ToHashSet().Count == Math.Max(lsets[0].Count, lsets[1].Count))
            {
                runningTotal += 1;
            }
        }
        Console.WriteLine(runningTotal);

    }
    public static void Part2()
    {
        string[] lines = ReadFromFile.ReadLines(FileName);
        int runningTotal = 0;
        foreach (string line in lines)
        {
            HashSet<int>[] lsets = GetSections(line.Split(','));
            if (lsets[0].Intersect(lsets[1]).ToHashSet().Any())
            {
                runningTotal += 1;
            }
        }
        Console.WriteLine(runningTotal);

    }

    private static HashSet<int>[] GetSections(string[] input)
    {
        return input.Select(s => Enumerable.Range(int.Parse(s.Split('-')[0]), int.Parse(s.Split('-')[1]) - int.Parse(s.Split('-')[0]) + 1).ToHashSet()).ToArray();
    }

}