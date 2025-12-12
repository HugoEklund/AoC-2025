namespace AoC_25.Day6;

public static class Day6_2
{
    public static void Exec()
    {
        long totalSum = 0;
        var input = File.ReadAllLines("Day6/input.txt.txt");
        var currBlockNums = new List<long>();
        
        for (int col = input[0].Length - 1; col >= 0; col--)
        {
            string tempString = "";
            
            for (int row = 0; row < input.Length - 1; row++)
            {
                if (char.IsDigit(input[row][col]))
                {
                    tempString += input[row][col];
                }
            }
            if (tempString.Length > 0)
            {
                currBlockNums.Add(long.Parse(tempString));
            }
            char operand = input[^1][col];

            if (operand == '+' || operand == '*')
            {
                long tempNum = (operand == '+' ? 0 : 1);
                foreach (var num in currBlockNums)
                {
                    if (operand == '+')
                    {
                        tempNum += num;
                    }
                    else
                    {
                        tempNum *= num;
                    }
                }
                totalSum += tempNum;
                currBlockNums.Clear();
            }
        }
        Console.WriteLine(totalSum);
    }
}