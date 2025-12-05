namespace AoC_25.Day3;

public static class Day3_2
{
    public static void Exec()
    {
        long totSum = 0;
        
        // 2 actions: keep or remove
        // leftmost values have more impact => want bigger nums here
        // => shift larger numbers left
        // for each num:
            // if num < num.next
                // delete

        foreach (var row in File.ReadLines("Day3/input.txt"))
        {
            
            var nums = row.Select(c => c - '0').ToList();
            int dels = nums.Count - 12;

            for (int i = 0; i < nums.Count - 1 && dels > 0;)
            {
                if (nums[i] < nums[i + 1])
                {
                    nums.RemoveAt(i);
                    dels--;
                    if (i > 0) i--;
                }
                else
                {
                    i++;
                }
            } 
            while (nums.Count > 0 && dels > 0)
            {
                nums.RemoveAt(nums.Count - 1);
                dels--;
            }

            long newValue = nums.Aggregate<int, long>(0, (current, i) => current * 10 + i);

            totSum += newValue;
        }
        Console.WriteLine(totSum);
    }
}