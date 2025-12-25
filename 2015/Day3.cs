namespace AdventOfCode._2015;

public sealed class Day3 : DayBase<string>
{
    public override int DayNumber => 3;

    public override string ParseInput(string input)
    {
        return input;
    }

    public override long SolvePart1(string input)
    {
        var santa = new GiftBringer();
        DeliverGifts(santa, input, 0, 1);

        return santa.NumberOfHousesWithGifts;
    }

    public override long SolvePart2(string input)
    {
        var santa = new GiftBringer();
        var roboSanta = new GiftBringer();

        // Two small loops without modulo is slightly faster than 1 big loop _with_ modulo
        DeliverGifts(santa, input, 0, 2);
        DeliverGifts(roboSanta, input, 1, 2);

        return santa.VisitedHouses.Union(roboSanta.VisitedHouses).Count();
    }

    private static void DeliverGifts(GiftBringer giftBringer, string input, int start, int jump)
    {
        for (int i = start; i < input.Length; i += jump)
        {
            var direction = input[i];

            if (direction == '>')
            {
                giftBringer.MoveEast();
            }
            else if (direction == '<')
            {
                giftBringer.MoveWest();
            }
            else if (direction == '^')
            {
                giftBringer.MoveNorth();
            }
            else if (direction == 'v')
            {
                giftBringer.MoveSouth();
            }
        }
    }

    private sealed class GiftBringer
    {
        private Coordinate _currentCoordinate;
        private readonly Dictionary<Coordinate, int> _visitedCoordinates = [];

        public GiftBringer()
        {
            _currentCoordinate = new Coordinate { X = 0, Y = 0 };
            _visitedCoordinates.Add(_currentCoordinate, 1);
        }

        public void MoveEast()
        {
            _currentCoordinate.X += 1;
            UpPresentCount();
        }

        public void MoveWest()
        {
            _currentCoordinate.X -= 1;
            UpPresentCount();
        }

        public void MoveSouth()
        {
            _currentCoordinate.Y -= 1;
            UpPresentCount();
        }

        public void MoveNorth()
        {
            _currentCoordinate.Y += 1;
            UpPresentCount();
        }

        private void UpPresentCount()
        {
            if (_visitedCoordinates.ContainsKey(_currentCoordinate))
            {
                _visitedCoordinates[_currentCoordinate]++;
            }
            else
            {
                _visitedCoordinates.Add(_currentCoordinate, 1);
            }
        }

        public int NumberOfHousesWithGifts => _visitedCoordinates.Count;
        public IEnumerable<Coordinate> VisitedHouses => _visitedCoordinates.Keys;
    }

    private struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
