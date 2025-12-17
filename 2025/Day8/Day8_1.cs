namespace AoC_25;

public static class Day8_1
{
    public static void Exec()
    {
        var input = File.ReadLines("2025/Day8/input.txt").Select(r => r.Split(','))
            .Select(n => (x: int.Parse(n[0]), y: int.Parse(n[1]), z: int.Parse(n[2]))).ToList();
        
        
    }
}