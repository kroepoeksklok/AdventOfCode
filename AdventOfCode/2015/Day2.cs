namespace AdventOfCode._2015;

public sealed class Day2 : DayBase<IEnumerable<Box>>
{
    public override int DayNumber => 2;

    public override IEnumerable<Box> ParseInput(string input)
    {
        var boxes = new List<Box>();

        var lines = input.Split(Environment.NewLine);
        foreach(var line in lines)
        {
            var dimensions = line.Split('x');
            var box = new Box(int.Parse(dimensions[0]), int.Parse(dimensions[1]), int.Parse(dimensions[2]));
            boxes.Add(box);
        }

        return boxes;
    }

    public override long SolvePart1(IEnumerable<Box> input)
    {
        long sqFeetOfPaperNeeded = 0;

        foreach (var box in input)
        {
            sqFeetOfPaperNeeded += box.SurfaceArea;
            sqFeetOfPaperNeeded += box.GetSmallestSurfaceArea();
        }

        return sqFeetOfPaperNeeded;
    }

    public override long SolvePart2(IEnumerable<Box> input)
    {
        long sqFeetOfRibbonNeeded = 0;

        foreach (var box in input)
        {
            sqFeetOfRibbonNeeded += box.Volume;
            sqFeetOfRibbonNeeded += box.GetSmallestPerimeter();
        }

        return sqFeetOfRibbonNeeded;
    }
}

public sealed record Box(int Length, int Width, int Height)
{
    public int SurfaceArea =>
        (2 * Length * Width) +
        (2 * Width * Height) +
        (2 * Height * Length);

    public int Volume => Length * Width * Height;

    public int GetSmallestSurfaceArea()
    {
        return Math.Min(Length * Width, Math.Min(Width * Height, Height * Length));
    }

    public int GetSmallestPerimeter()
    {
        return Math.Min(2 * Length + 2 * Width, Math.Min(2 * Width + 2 * Height, 2 * Height + 2 * Length));
    }
}