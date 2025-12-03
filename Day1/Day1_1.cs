namespace AoC_25.Day1;

public class Day1_1
{
    public static void Exec()
    {
        int zeroes = 0;
        int pos = 50;
        foreach (var line in File.ReadLines("Day1/input.txt"))
        {
            string cmd = line.Substring(0, 1);
            int num = int.Parse(line.Substring(1));
            pos = Wrap(pos += (cmd == "L" ? -num : num));
            
            if (pos == 0) zeroes++;
        }
        Console.WriteLine(zeroes);
    }
    
    private static int Wrap(int val)
    {
        return (val % 100 + 100) % 100;
    }
}