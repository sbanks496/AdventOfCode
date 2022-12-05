namespace AdventOfCode;

public class Day5
{
    private const string FileName = "day5.txt";

    public static void Part1()
    {
        string[] lines = ReadFromFile.ReadLines(FileName);
        bool initial = true;
        Dictionary<int, List<char>> input = new Dictionary<int,List<char>>();
        foreach (string line in lines)
        {
            if (initial && line[1] != '1')
            {
                for (int i=0; 4 * i < line.Length; i++)
                {
                    if (line[4*i + 1] != ' ')
                    {
                        input.TryAdd(i+1, new List<char>());
                        input[i+1].Add(line[4 * i + 1]);
                    }
                }
            }
            else if (line == "" || initial && line[1] == '1')
            {
                initial = false;
            }
            else
            {
                string[] instructions = line.Split(' ');
                Console.WriteLine(line);
                for (int i = 0; i < int.Parse(instructions[1]); i++)
                {
                    input[int.Parse(instructions[5])].Insert(0, input[int.Parse(instructions[3])][0]);
                    input[int.Parse(instructions[3])].RemoveAt(0);
                }
            }
        }

        for (int i = 1; i <= input.Count; i++)
        {
            Console.Write(input[i][0]);
        }
    }
}