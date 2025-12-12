namespace AoC_25.Day2;

public static class Day2_1
{
    public static void Exec()
    {
        long invalid = 0;
        var input = File.ReadAllText("Day2/input.txt.txt");
        var range = input.Split(",");
        
        foreach (var num in range)
        {
            var interval = num.Split("-");
            for (long i = long.Parse(interval[0]); i <= long.Parse(interval[1]); i++)
            {
                if (IsInvalid(i)) invalid += i;
            }
        }
        Console.WriteLine(invalid);
    }

    private static bool IsInvalid(long num)
    {
        string s = num.ToString();
        if (s.Length % 2 == 0)
        {
            return s.Substring(0, s.Length / 2) == s.Substring(s.Length / 2);
        }
        return s[0] == '0';
    }
}