namespace AdventOfCode;

public abstract class DayBase<T> : IDay<T>
{
    public abstract int DayNumber { get; }
    public abstract T ParseInput(string input);
    public abstract long SolvePart1(T input);
    public abstract long SolvePart2(T input);

    object IDay.Parse(string input)
        => ParseInput(input)!;

    long IDay.SolvePart1(object parsed)
        => SolvePart1((T) parsed);

    long IDay.SolvePart2(object parsed)
        => SolvePart2((T) parsed);
}