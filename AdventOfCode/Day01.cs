using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;
    private List<string> lines;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        lines = _input.Split(System.Environment.NewLine).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int value = 0;

        foreach (var line in lines)
        {
            string numbers = new(line.Where(char.IsDigit).ToArray());
            value += int.Parse($"{numbers[0]}{numbers[^1]}");
        }

        return new ValueTask<string>(value.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int value = 0;

        foreach (var line in lines)
        {
            string numbers = line.FindAllNumbers();
            value += int.Parse($"{numbers[0]}{numbers[^1]}");
        }

        return new ValueTask<string>(value.ToString());
    }
}