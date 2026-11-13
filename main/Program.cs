using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        string sampleText =
            "Peter Piper picked a peck of pickled peppers. A peck of pickled\n" +
            "peppers Peter Piper picked. If Peter Piper picked a peck of\n" +
            "pickled peppers, where is the peck that Peter Piper picked?";

        Text textProcessor = new Text(sampleText);
        string result = textProcessor.FormatConcordance();

        Console.WriteLine(result);
    }
}