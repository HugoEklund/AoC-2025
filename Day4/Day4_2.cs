namespace AoC_25.Day4;

public static class Day4_2
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("Day4/input.txt.txt");
        int rows = lines.Length;
        int columns = lines[0].Length;
        int removedRolls = 0;
        bool changed;
        
        var matrix = lines.Select(l => l.ToCharArray()).ToArray();
        var directions = new (int adjR, int adjC)[]
        {
            (-1,-1), (-1,0), (-1,1),
            ( 0,-1),         ( 0,1),
            ( 1,-1), ( 1,0), ( 1,1)
        };

        do
        {
            changed = false;
            var toBeRemoved = new List<(int r, int c)>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (matrix[r][c] != '@') continue;
                    int rolls = 0;

                    foreach (var (adjR, adjC) in directions)
                    {
                        int newR = r + adjR;
                        int newC = c + adjC;

                        if ((uint)newR < (uint)rows && (uint)newC < (uint)columns && matrix[newR][newC] == '@')
                        {
                            rolls++;
                        }
                    }

                    if (rolls < 4)
                    {
                        toBeRemoved.Add((r,c));
                    }
                }
            }

            if (toBeRemoved.Count > 0)
            {
                changed = true;
                removedRolls += toBeRemoved.Count;
                foreach (var (r,c) in toBeRemoved)
                {
                    matrix[r][c] = '.';
                }
            }
        } while (changed);
        Console.WriteLine(removedRolls);
    }
}