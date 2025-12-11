namespace AoC_25.Day6;

public static class Day6_1
{
    public static void Exec()
    {
        int totalSum = 0;
        int[] sum = null;
        int[] prod = null;
        
        foreach (var row in File.ReadLines("Day6/input.txt"))
        {
            var cols = row.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (int.TryParse(cols[0], out _) == null)
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    int num = int.Parse(cols[i]);
                    if (sum == null)
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