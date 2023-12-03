namespace AdventOfCode;

public static class StringExtensions
{
    public static string FindAllNumbers(this string input)
    {
        string[] numbers = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        string result = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                result += input[i];
            }
            else
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (input.Substring(i).StartsWith(numbers[j]))
                    {
                        // Little bit hacky
                        result += (j + 1).ToString(); 
                    }
                }
            }
        }

        return result;
    }

    public static int GetDigitFromString(this string input)
    {
       return int.Parse(new(input.Where(c => char.IsDigit(c)).ToArray()));
    }
}