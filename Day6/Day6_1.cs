namespace AoC_25.Day6;

public static class Day6_1
{
    public static void Exec()
    {
        long totalSum = 0;
        long[]? sum = null;
        long[]? prod = null;
        
        foreach (var row in File.ReadLines("Day6/input.txt.txt"))
        {
            var cols = row.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (int.TryParse(cols[0], out _))
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    long num = int.Parse(cols[i]);
                    if (sum == null)
                    {
                        sum = new long[cols.Length];
                        prod = new long[cols.Length];
                    }

                    if (sum[i] == 0 && prod[i] == 0)
                    {
                        sum[i] = num;
                        prod[i] = num;
                    }
                    else
                    {
                        sum[i] += num;
                        prod[i] *= num;
                    }
                }
            }
            else
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    totalSum += cols[i] == "+" ? sum[i] : prod[i];
                }
            }
        }
        Console.WriteLine(totalSum);
    }
}