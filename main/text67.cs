using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Text
{
    private readonly List<string> _lines;

    public Text(string rawText)
    {
       
        _lines = rawText
            .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }


    public Dictionary<string, WordStats> BuildConcordance()
    {
        var concordance = new Dictionary<string, WordStats>();

        for (int i = 0; i < _lines.Count; i++)
        {
            int currentLineNumber = i + 1; 

  
            MatchCollection matches = Regex.Matches(_lines[i].ToLower(), @"\b[a-zа-яё]+\b");

            foreach (Match match in matches)
            {
                string word = match.Value;

                if (concordance.ContainsKey(word))
                {
                    concordance[word].AddOccurrence(currentLineNumber);
                }
                else
                {
                    concordance[word] = new WordStats(currentLineNumber);
                }
            }
        }

      
        return concordance
            .OrderBy(pair => pair.Key, StringComparer.Ordinal)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    
    public string FormatConcordance()
    {
        var concordance = BuildConcordance();
        var sb = new StringBuilder();
        int totalWidth = 35;

        foreach (var entry in concordance)
        {
            string word = entry.Key;
            WordStats stats = entry.Value;


            string paddedWord = word.PadRight(totalWidth, '.');
            string lines = string.Join(" ", stats.LineNumbers);

            sb.AppendLine($"{paddedWord}{stats.Count}: {lines}");
        }

        return sb.ToString();
    }
}