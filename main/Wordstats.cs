using System.Collections.Generic;

public class WordStats
{
    public int Count { get; set; }
    public SortedSet<int> LineNumbers { get; } = new SortedSet<int>();

    public WordStats(int lineNumber)
    {
        Count = 1;
        LineNumbers.Add(lineNumber);
    }

    public void AddOccurrence(int lineNumber)
    {
        Count++;
        LineNumbers.Add(lineNumber);
    }
}