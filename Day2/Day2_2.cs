namespace AoC_25.Day2;

public class Day2_2
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
    
    // for every num:
        // iterate forward and save every num in "new" array until curr index = substring(0)
    // found:
        // check if toString.length => "new".length * 2
        // true:
            // check if substring(curr, "new".length * 2) = "new" array
                // true:
                    // invalid ID, duplicate found
        // false:
            // no repeat = valid ID
            
    // not found (out of bounds/null):
        // valid ID = ignore and move onto next num 

    private static bool IsInvalid(long num)
    {
        string s = num.ToString();
        if (s.Length % 2 == 0)
        {
            return s.Substring(0, s.Length / 2) == s.Substring(s.Length / 2);
        }
        return false;
    }
}