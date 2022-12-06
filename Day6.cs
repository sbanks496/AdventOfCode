namespace AdventOfCode;

public class Day6
{
    private const string FileName = "day6.txt";
    public static void Part1()
    {
        string line = ReadFromFile.ReadLines(FileName)[0];
        int i = 0;
        while ( i < line.Length)
        {
            if (line.Substring(i, 4).ToHashSet().Count == 4)
            {
                Console.WriteLine(i+4);
                i = line.Length;
            }

            i++;
        }
    }
    
    public static void Part2()
    {
        string line = ReadFromFile.ReadLines(FileName)[0];
        int i = 0;
        const int mlength = 14;
        while ( i < line.Length)
        {
            if (line.Substring(i, mlength).ToHashSet().Count == mlength)
            {
                Console.WriteLine(i+mlength);
                i = line.Length;
            }

            i++;
        }
    }
}