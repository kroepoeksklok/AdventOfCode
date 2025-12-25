using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2015;

public sealed class Day4 : DayBase<string>
{
    public override int DayNumber => 4;

    public override string ParseInput(string input)
    {
        return input;
    }

    public override long SolvePart1(string input)
    {
        return FindHash(input, hash => hash[0] == 0 && hash[1] == 0 && hash[2] < 16);
    }

    public override long SolvePart2(string input)
    {
        return FindHash(input, hash => hash[0] == 0 && hash[1] == 0 && hash[2] == 0);
    }

    private int FindHash(string input, Func<byte[], bool> hashChecker)
    {
        int counter = 1;

        while (true)
        {
            var utf8Encoded = Encoding.UTF8.GetBytes($"{input}{counter}");
            var hash = MD5.HashData(utf8Encoded);

            if (hashChecker(hash))
            {
                break;
            }

            counter++;
        }

        return counter;
    }
}
