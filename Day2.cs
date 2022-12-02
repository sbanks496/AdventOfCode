namespace AdventOfCode;

public class Day2
{
    private static readonly (char, char, char) _key1 = ('A', 'B', 'C');
    private static readonly (char, char, char) _key2 = ('X', 'Y', 'Z');
    private static readonly int[] _playPoints = {1,2,3};
    private static readonly int[] _scorePoints = {3, 6, 0};
    private static readonly string _fileName = "day2.txt";
    static int keyConvert(char input, (char, char, char) key)
    {
        if (input == key.Item1)
        {
            return 0;
        }
        else if (input == key.Item2)
        {
            return 1;
        }
        else if (input == key.Item3)
        {
            return 2;
        }
        throw new Exception();
    }

    private static int evaluatePoints(int input1, int input2)
    {
        int i = (input2 - input1 + 3) % 3;
        return _playPoints[input2] + _scorePoints[i];
    }

    public static void Part1()
    {
        string[] lines = ReadFromFile.ReadLines(_fileName);
        int runningTotal = 0;
        foreach (string line in lines)
        {
            runningTotal += evaluatePoints(keyConvert(line[0], _key1), keyConvert(line[2], _key2));
        }
        Console.WriteLine(runningTotal);
    }
}