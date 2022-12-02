namespace AdventOfCode;

public class Day2
{
    private static readonly string _key1 = "ABC";
    private static readonly string _key2 = "XYZ";
    private static readonly string _fileName = "day2.txt";
    private static readonly string[] lines = ReadFromFile.ReadLines(_fileName);
    static int keyConvert(char input, string key)
    {
        for (int i = 0; i < 3; i++)
        {
            if (key[i] == input)
            {
                return i;
            }
        }
        throw new Exception("character not found in key");
    }

    private static int evaluatePoints(int input1, int input2, bool reverse = false)
    {
        int i = (input2 - input1 + 3) % 3;
        return reverse switch
        {
            true => i+1 + (input2+1) * 3,
            false => input2 + 1 + (i * 3 + 3) % 9
        };
    }

    public static void Part1()
    {
        int runningTotal = 0;
        foreach (string line in lines)
        {
            runningTotal += evaluatePoints(keyConvert(line[0], _key1), keyConvert(line[2], _key2));
        }
        Console.WriteLine(runningTotal);
    }
    public static void Part2()
    {
        int runningTotal = 0;
        foreach (string line in lines)
        {
            runningTotal += evaluatePoints(-keyConvert(line[0], _key1), keyConvert(line[2], _key2) - 1, true);
        }
        Console.WriteLine(runningTotal);
    }
}