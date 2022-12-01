namespace AdventOfCode;

public class ReadFromFile
{
//    static readonly string fileName = 

    public static string[] ReadLines(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines("../../../input/" + fileName);
        return lines;
    }
}