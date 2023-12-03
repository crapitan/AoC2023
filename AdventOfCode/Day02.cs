using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;
    private List<string> lines;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
        lines = _input.Split(System.Environment.NewLine).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        var bag = new { Red = 12, Green = 13, Blue = 14 };

        // Add for every possible game 
        int value = 0;

        foreach (var line in lines)
        {
            var rounds = line.Split(":")[1].Split(";");

            int maxRed = 0, maxGreen = 0, maxBlue = 0;

            foreach (var round in rounds)
            {
                int roundRed = 0, roundGreen = 0, roundBlue = 0;

                var cubes = round.Split(",");

                foreach (var cube in cubes)
                {
                    switch (cube)
                    {
                        case var _ when cube.Contains("red"):
                            roundRed += cube.GetDigitFromString();
                            break;
                        case var _ when cube.Contains("blue"):
                            roundBlue += cube.GetDigitFromString();
                            break;
                        case var _ when cube.Contains("green"):
                            roundGreen += cube.GetDigitFromString();
                            break;
                    }
                }

                maxRed = maxRed < roundRed ? roundRed : maxRed;
                maxGreen = maxGreen < roundGreen ? roundGreen : maxGreen;
                maxBlue = maxBlue < roundBlue ? roundBlue : maxBlue;
            }

            if (bag.Red >= maxRed && bag.Green >= maxGreen && bag.Blue >= maxBlue)
            {
                value += line.Split(":")[0].GetDigitFromString();
            }
        }

        return new ValueTask<string>(value.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        // Add for every possible game 
        int value = 0;

        foreach (var line in lines)
        {
            var rounds = line.Split(":")[1].Split(";");

            int maxRed = 0, maxGreen = 0, maxBlue = 0;

            foreach (var round in rounds)
            {
                int roundRed = 0, roundGreen = 0, roundBlue = 0;

                var cubes = round.Split(",");

                foreach (var cube in cubes)
                {
                    switch (cube)
                    {
                        case var _ when cube.Contains("red"):
                            roundRed += cube.GetDigitFromString();
                            break;
                        case var _ when cube.Contains("blue"):
                            roundBlue += cube.GetDigitFromString();
                            break;
                        case var _ when cube.Contains("green"):
                            roundGreen += cube.GetDigitFromString();
                            break;
                    }
                }

                maxRed = maxRed < roundRed ? roundRed : maxRed;
                maxGreen = maxGreen < roundGreen ? roundGreen : maxGreen;
                maxBlue = maxBlue < roundBlue ? roundBlue : maxBlue;
            }

            value += maxRed * maxGreen * maxBlue;
        }

        return new ValueTask<string>(value.ToString());
    }
}