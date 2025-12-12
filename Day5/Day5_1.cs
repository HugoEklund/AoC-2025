namespace AoC_25.Day5;

public static class Day5_1
{
    public static void Exec()
    {
        int fresh = 0;
        var lines = File.ReadAllLines("Day5/input.txt.txt");
        int sepIndex = Array.FindIndex(lines, string.IsNullOrWhiteSpace);
        var someRanges = lines[..sepIndex];
        var someIngredientIDs = lines[(sepIndex + 1)..];
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
        
        var someStarts = new long[someMergedRanges.Count];
        var someEnds   = new long[someMergedRanges.Count];
        
        for (int i = 0; i < someMergedRanges.Count; i++)
        {
            someStarts[i] = someMergedRanges[i].start;
            someEnds[i]   = someMergedRanges[i].end;
        }
        
        foreach (var start in someIngredientIDs)
        {
            long id = long.Parse(start);

            int searchRes = Array.BinarySearch(someStarts, id);
            bool isInside;
                
            if (searchRes >= 0)
            {
                isInside = (id <= someEnds[searchRes]);
            }
            else // gav upp här lol
            {
                int ins  = ~searchRes;
                int cand = ins - 1;
                isInside = (cand >= 0 && id <= someEnds[cand]);
            }

            if (isInside) fresh++;
        }

        Console.WriteLine(fresh);
    }
}