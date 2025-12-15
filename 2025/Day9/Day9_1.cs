namespace AoC_25;

public static class Day9_1
{
    public static void Exec()
    {
        var input = File.ReadLines("2025/Day9/input.txt").Select(n => n.Split(','))
            .Select(p => (x: int.Parse(p[0]), y: int.Parse(p[1]))).ToList();

        long area = input.SelectMany((i, j) => input.Skip(j + 1)
            .Select(q => (long)(Math.Abs(i.x - q.x) + 1) * (Math.Abs(i.y - q.y) + 1))).Max();
        
        Console.WriteLine(area);
    }
}