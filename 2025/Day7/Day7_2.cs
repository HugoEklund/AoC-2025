namespace AoC_25;

public static class Day7_2
{
    
    public static void Exec()
    {
        var input = File.ReadAllLines("2025/Day7/input.txt");
        int inpWidth = input[0].Length;
        int inpHeight = input.Length;
        var cache = new Dictionary<(int r, int c), long>();

        Console.WriteLine(recTimeline(0, inpWidth / 2, input, inpHeight, inpWidth, cache));
    }

    private static long recTimeline(int r, int c, string[] input, int height, int width, Dictionary<(int r, int c), long> cache)
    {
        if (r >= height || c < 0 || c >= width)
        {
            return 1;
        }

        if (cache.TryGetValue((r, c), out var val))
        {
            return val;
        }
        
        char pos = input[r][c];
        long res;
        
        if (pos.Equals('^'))
        {
            res = recTimeline(r + 1, c - 1, input, height, width, cache) 
                  + recTimeline(r + 1, c + 1, input, height, width, cache);
        }
        else
        {
            res = recTimeline(r + 1, c, input, height, width, cache);
        }

        cache[(r, c)] = res;
        return res;
    }
}