using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode._2015;

public sealed class Day5 : DayBase<List<string>>
{
    public override int DayNumber => 5;

    public override List<string> ParseInput(string input)
    {
        return [.. input.Split(Environment.NewLine)];
    }

    public override long SolvePart1(List<string> input)
    {
        // The regex version would look something like this:
        // ^(?!.*(?:ab|cd|xy|pq))(?=(?:[^aeiou]*[aeiou]){3,})(?=.*([a-z])\1)[a-z]+$
        // I now have seven problems.

        var niceCount = 0;

        foreach (var word in input)
        {
            int vowelCount = 0;
            char previousChar = '@';
            bool containsDoubleLetter = false;
            bool containsForbiddenString = false;

            for (int i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];

                if (currentChar == 'a' || currentChar == 'e' || currentChar == 'o' || currentChar == 'u' || currentChar == 'i')
                {
                    vowelCount++;
                }

                if (i > 0)
                {
                    previousChar = word[i - 1];

                    if (previousChar == currentChar)
                    {
                        containsDoubleLetter = true;
                    }

                    if ((previousChar == 'a' && currentChar == 'b') ||
                        (previousChar == 'c' && currentChar == 'd') ||
                        (previousChar == 'p' && currentChar == 'q') ||
                        (previousChar == 'x' && currentChar == 'y'))
                    {
                        containsForbiddenString = true;
                        break;
                    }
                }
            }

            if (containsForbiddenString)
            {
                continue;
            }

            if (vowelCount >= 3 && containsDoubleLetter)
            {
                niceCount++;
            }
        }

        return niceCount;
    }

    public override long SolvePart2(List<string> input)
    {
        var correctCount = 0;

        foreach (var word in input)
        {
            char previousChar = '@';
            char charBeforePreviousChar = '@';
            Dictionary<Pair, List<PairInfo>> pairs = [];
            bool containsOneLetterRepeatedWithExactlyOneInBetween = false;

            for (int i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];

                if (i > 0)
                {
                    previousChar = word[i - 1];
                    var p = new Pair { FirstChar = previousChar, SecondChar = currentChar };
                    var pairInfo = new PairInfo { IndexFirst = i - 1, IndexSecond = i };

                    if (!pairs.ContainsKey(p))
                    {
                        pairs.Add(p, [pairInfo]);
                    }
                    else
                    {
                        pairs[p].Add(pairInfo);
                    }
                }

                if (i > 1 && !containsOneLetterRepeatedWithExactlyOneInBetween)
                {
                    charBeforePreviousChar = word[i - 2];

                    if (currentChar == charBeforePreviousChar)
                    {
                        containsOneLetterRepeatedWithExactlyOneInBetween = true;
                    }
                }
            }

            if (!containsOneLetterRepeatedWithExactlyOneInBetween)
            {
                continue;
            }

            var pairsThatAppearMoreThanOnce = pairs.Where(c => c.Value.Count > 1).ToList();
            if (pairsThatAppearMoreThanOnce.Count == 0)
            {
                continue;
            }

            var overlaps = true;
            foreach (var kvp in pairsThatAppearMoreThanOnce)
            {
                for (int i = 0; i < kvp.Value.Count - 1; i++)
                {
                    var currentPairInfo = kvp.Value[i];
                    for (int j = i + 1; j < kvp.Value.Count; j++)
                    {
                        var nextPair = kvp.Value[j];
                        if (nextPair.IndexFirst > currentPairInfo.IndexSecond)
                        {
                            overlaps = false;
                            break;
                        }
                    }

                    if (!overlaps)
                    {
                        break;
                    }
                }
                if (!overlaps)
                {
                    break;
                }
            }

            if (!overlaps)
            {
                correctCount++;
            }
        }

        return correctCount;
    }

    public struct Pair
    {
        public char FirstChar { get; set; }
        public char SecondChar { get; set; }
    }

    public struct PairInfo
    {
        public int IndexFirst { get; set; }
        public int IndexSecond { get; set; }

    }
}
