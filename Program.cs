using AdventOfCode.Properties;
using System.Diagnostics;

namespace AdventOfCode;

internal class Program
{
    private static readonly Dictionary<int, IEnumerable<DayToSolve>> _solvedDays = new()
    {
        { 2015, new[] { 
                new DayToSolve(new _2015.Day1(), Resources._2015Day01),
                new DayToSolve(new _2015.Day2(), Resources._2015Day02),
                new DayToSolve(new _2015.Day3(), Resources._2015Day03),
                new DayToSolve(new _2015.Day4(), Resources._2015Day04)
            } 
        }
    };

    static void Main()
    {
        foreach (var yearPuzzles in _solvedDays)
        {

            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine($"|                 Year: {yearPuzzles.Key}                 |");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("| Day | Part | Duration    | Answer          |");
            Console.WriteLine("+--------------------------------------------+");

            foreach(var day in yearPuzzles.Value)
            {
                SolveDay(day);
            }

            Console.WriteLine("+--------------------------------------------+");
        }
    }

    private static void SolveDay(DayToSolve dayToSolve)
    {
        IDay day = dayToSolve.Day;

        var parsed = day.Parse(dayToSolve.Input);
        RunPart(day.SolvePart1, day.DayNumber, 1, parsed);
        RunPart(day.SolvePart2, day.DayNumber, 2, parsed);
    }

    private static void RunPart(Func<object, long> partFunction, int dayNumber, int partNumber, object parsedInput)
    {
        var sw = Stopwatch.StartNew();
        var answer = partFunction(parsedInput);
        sw.Stop();
        var duration = sw.ElapsedTicks / 10000d;
        Console.WriteLine(string.Format("| {0,3} | {1,4} | {2,8} ms | {3,15} |", dayNumber, partNumber, duration, answer));
    }
}

internal record DayToSolve(IDay Day, string Input);