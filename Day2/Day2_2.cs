namespace AoC_25.Day2;

public static class Day2_2
{
    public static void Exec()
    {
        long invalid = 0;
        var input = File.ReadAllText("Day2/input.txt");
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
        string sNum = num.ToString();
        int sLength = sNum.Length;

        for (int i = 1; i <= sLength / 2; i++)
        {
            if (sLength % i == 0)
            {
                if (string.Concat(Enumerable.Repeat(sNum.Substring(0, i), sLength / i)) == sNum)
                {
                    return true;
                }
            }
        }
        return false;
    }

    #region Old attempt
    // Forgot that the entire word has to be made up of repeated sequences
    
    // private static bool IsInvalid(long num)
    // {
    //     string s = num.ToString();
    //
    //     for (int i = 1; i <= s.Length / 2; i++)
    //     {
    //         if (s.Substring(i, i) == s.Substring(0, i))
    //         {
    //             return true;
    //         }
    //     }
    //     return false;
    // }
    #endregion
}