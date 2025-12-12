namespace AoC_25.Day4;

public static class Day4_1
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("Day4/input.txt.txt");
        int rows = lines.Length;
        int columns = lines[0].Length;
        int accessible = 0;

        var directions = new (int adjR, int adjC)[]
        {
            (-1, -1), (-1, 0), (-1, 1),
            (0, -1), (0, 1),
            (1, -1), (1, 0), (1, 1)
        };

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (lines[r][c] != '@') continue;
                int rolls = 0;

                foreach (var (adjR, adjC) in directions)
                {
                    int newR = r + adjR;
                    int newC = c + adjC;

                    if ((uint) newR < (uint) rows && (uint) newC < (uint) columns && lines[newR][newC] == '@')
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