namespace AoC_25.Day4;

public static class Day4_1
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("Day4/input.txt");
        int rows = lines.Length;
        int columns = lines[0].Length;
        int accessible = 0;
        
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                int rolls = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (lines[r][c] == '@')
                    {
                        rolls++;
                    }
                }
                
                if (rolls < 4)
                {
                    accessible++;
                }
            }
        }
        Console.WriteLine(accessible);
    }
}