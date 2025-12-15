namespace AoC_25;

public static class Day7_1
{
    public static void Exec()
    {
        /*
         * File.ReadLines
         * being at S (width / 2)
         * iterate row by row, step over .
         * if ^
         *  increment integer
         *  create two beams on next row @[curr - 1] && @[curr + 1]
         *
         * no overlapping beams => store beams in e.g. HashSet
         * consider bounds
         */
        int totSplits = 0;
        var currBeams = new HashSet<(int row, int col)>();
        var nextBeams = new HashSet<(int row, int col)>();
        
        var input = File.ReadAllLines("2025/Day7/input.txt");
        int inpWidth = input[0].Length;
        int inpHeight = input.Length;

        currBeams.Add((0, inpWidth / 2));
        
        for (int i = 0; i < inpHeight; i++)
        {
            foreach (var (r,c) in currBeams)
            {
                char pos = input[r][c];

                if (pos.Equals('.') || pos.Equals('S'))
                {
                    nextBeams.Add((r + 1, c));
                }
                else if (pos.Equals('^'))
                {
                    totSplits++;
                    nextBeams.Add((r + 1, c - 1));
                    nextBeams.Add((r + 1, c + 1));
                }
            }
            currBeams = nextBeams;
            nextBeams = new HashSet<(int row, int col)>();
        }
        
        Console.WriteLine(totSplits);
    }
}