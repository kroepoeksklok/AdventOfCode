namespace AdventOfCode;

public interface IDay
{
    int DayNumber { get; }
    object Parse(string input);
    long SolvePart1(object input);
    long SolvePart2(object input);
}
