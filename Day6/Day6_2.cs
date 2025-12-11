namespace AoC_25.Day6;

public static class Day6_2
{
    public static void Exec()
    {
        long totalSum = 0;
        string tempString = "";
        long tempNum = 0;
        var input = File.ReadAllLines("Day6/exampleInput.txt");
        var someSums = new long[input[0].Length - 1];
        
        for (int col = input[0].Length - 1; col >= 0; col--)
        {
            char operand = input[input.Length - 1][col];
            for (int row = 0; row < input.Length - 1; row++)
            {
                if (operand == ' ') continue;
                if (char.IsDigit(input[row][col]))
                {
                    tempString += input[row][col];
                }
            }
            if (tempString != "")
            {
                tempNum = long.Parse(tempString);
            }

            if (operand == '+')
            {
                someSums[col] += tempNum;
                tempString = "";
            }
            else
            {
                someSums[col] *= tempNum;
                tempString = "";
            }

            foreach (var sum in someSums)
            {
                totalSum += sum;
            }
        }
        Console.WriteLine(totalSum);
    }
}