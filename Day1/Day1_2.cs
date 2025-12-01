namespace AoC_25.Day1;

public class Day1_2
{
    public static void Exec()
    {
        int zeroes = 0;
        int pos = 50;
        var input = File.ReadLines("Day1/input.txt");
        foreach (var line in input)
        {
            string cmd = line.Substring(0, 1);
            int num = int.Parse(line.Substring(1));
            for (int i = 0; i < num; i++)
            {
                pos = Wrap(pos + (cmd == "L" ? -1 : 1));
                
                if (pos == 0) zeroes++;
            }
        }
        Console.WriteLine(zeroes);
    }
    
    private static int Wrap(int val)
    {
        return (val % 100 + 100) % 100;
    }
}