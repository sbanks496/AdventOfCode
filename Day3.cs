using System.Collections.Immutable;

namespace AdventOfCode;

public class Day3
{
    private const string FileName = "day3.txt";

    private static ImmutableArray<string> CompartmentSplit(string rucksack)
    {
        int items = rucksack.Length;
        return (items % 2) switch
        {
            0 => ImmutableArray.Create(rucksack.Substring(0, items / 2), rucksack.Substring(items / 2)),
            1 => throw new Exception("Rucksack contains odd number of items")
        };
    }

    private static char GetDuplicate(ImmutableArray<string> compartments)
    {
        ImmutableHashSet<char> duplicates = compartments[0].ToImmutableHashSet().Intersect(compartments[1].ToImmutableHashSet());
        return  duplicates.Single();
    }

    private static int GetPriority(char input)
    {
        if (input is < 'A' or > 'z')
        {
            throw new Exception("Character is out of range");
        }
        if (input > 'Z')
        {
            return input - '`';
        }

        return input - '&';
    }
    public static void Part1()
    {
        string[] lines = ReadFromFile.ReadLines(FileName);
        int runningTotal = 0;
        foreach (string line in lines)
        {
            runningTotal += GetPriority(GetDuplicate(CompartmentSplit(line)));
        }
        Console.WriteLine(runningTotal);
    }
    public static void Part2()
    {
        string[] lines = ReadFromFile.ReadLines(FileName);
        int runningTotal = 0;
        int tracker = 0;
        HashSet<char> intersecter = lines[0].ToHashSet();
        foreach (string line in lines)
        {
            if (tracker < 3)
            {
                intersecter.IntersectWith(line.ToHashSet());
                tracker += 1;
            }
            else
            {
                tracker = 1;
                runningTotal += GetPriority(intersecter.Single());
                intersecter = line.ToHashSet();
                
            }
        }
        runningTotal += GetPriority(intersecter.Single());
        Console.WriteLine(runningTotal);
    }
}