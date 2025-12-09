namespace AoC_25.Day3;

public static class Day3_1
{
    public static void Exec()
    {
        int totSum = 0;

        foreach (var row in File.ReadLines("Day3/input.txt"))
        {
            int[] nums = row.Select(c => c - '0').ToArray();
            int highestPair = 0;
            for (int i = 0; i < row.Length - 1; i++)
            {
                for (int j = i + 1; j < row.Length; j++)
                {
                    int currPair = nums[i] * 10 + nums[j];
                    if (currPair > highestPair)
                    {
                        highestPair = currPair;
                    }
                }
            } 
            totSum += highestPair;
        }
        Console.WriteLine(totSum);
    }
}