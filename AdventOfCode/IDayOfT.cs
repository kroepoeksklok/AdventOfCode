namespace AdventOfCode;

public interface IDay<T> : IDay
{
    T ParseInput(string input);
    long SolvePart1(T input);
    long SolvePart2(T input);
}
