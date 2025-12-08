namespace AoC_25.Day5;

public static class Day5_2
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("Day5/input.txt");
        int sepIndex = Array.FindIndex(lines, string.IsNullOrWhiteSpace);
        var someRanges = lines[..sepIndex];
        var someSortedRanges = new List<(long start, long end)>();

        foreach (var range in someRanges)
        {
            var anInterval = range.Split("-");
            long start = long.Parse(anInterval[0]);
            long end = long.Parse((anInterval[1]));
            someSortedRanges.Add((start, end));
        }
        someSortedRanges.Sort((a, b) => a.start.CompareTo(b.start));

        var someMergedRanges = new List<(long start, long end)>();
        long currStart = someSortedRanges[0].start;
        long currEnd = someSortedRanges[0].end;

        for (int i = 1; i < someSortedRanges.Count; i++)
        {
            var (nextStart, nextEnd) = someSortedRanges[i];

            if (nextStart <= currEnd + 1)
            {
                currEnd = Math.Max(currEnd, nextEnd);
            }
            else
            {
                someMergedRanges.Add((currStart, currEnd));
                currStart = nextStart;
                currEnd = nextEnd;
            }
        }
        someMergedRanges.Add((currStart, currEnd));
        
        long totalFresh = 0;
        foreach (var (start, end) in someMergedRanges)
        {
            totalFresh += (end - start + 1);
        }

        Console.WriteLine(totalFresh);
    }
}