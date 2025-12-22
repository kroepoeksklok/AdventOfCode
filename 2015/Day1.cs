namespace AdventOfCode._2015;

public sealed class Day1 : DayBase<string>
{
    public override int DayNumber => 1;

    public override string ParseInput(string input)
    {
        return input;
    }

    public override long SolvePart1(string input)
    {
        int currentFloor = 0;
        foreach(var character in input)
        {
            if(character == '(')
            {
                currentFloor++;
            } 
            else if (character == ')')
            {
                currentFloor--;
            }
        }

        return currentFloor;
    }

    public override long SolvePart2(string input)
    {
        int currentFloor = 0;
        var instructionNumber = 0;

        for(int i = 0; i < input.Length; i++)
        {
            var character = input[i];
            if (character == '(')
            {
                currentFloor++;
            }
            else if (character == ')')
            {
                currentFloor--;
            }

            if(currentFloor == -1)
            {
                instructionNumber = i + 1;
                break;
            }
        }

        return instructionNumber;
    }
}
