using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<WordFrequency> wordFrequencies = ParseInputToWordFrequency(inputStr);

            List<WordFrequency> mergedWordFrequencies = MergeWordFrequencies(wordFrequencies);

            return Render(mergedWordFrequencies);
        }

        private static string Render(List<WordFrequency> mergedWordFrequencies)
        {
            List<string> strList = new List<string>();

            //stringJoiner joiner = new stringJoiner("\n");
            foreach (WordFrequency wordFrequency in mergedWordFrequencies)
            {
                string s = wordFrequency.Word + " " + wordFrequency.WordCount;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());
        }

        private List<WordFrequency> MergeWordFrequencies(List<WordFrequency> wordFrequencies)
        {
            Dictionary<string, List<WordFrequency>> groupedWordFrequencies = GroupByWord(wordFrequencies);

            List<WordFrequency> mergedWordFrequencies = groupedWordFrequencies.Select(entry => new WordFrequency(entry.Key, entry.Value.Count)).ToList();

            mergedWordFrequencies.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            return mergedWordFrequencies;
        }

        private List<WordFrequency> ParseInputToWordFrequency(string inputStr)
        {
            //split the input string with 1 to n pieces of spaces
            string[] words = Regex.Split(inputStr, @"\s+");

            return words.Select(word => new WordFrequency(word, 1)).ToList();
        }

        private Dictionary<string, List<WordFrequency>> GroupByWord(List<WordFrequency> wordFrequencies)
        {
            Dictionary<string, List<WordFrequency>> groupedWordFrequencies = new Dictionary<string, List<WordFrequency>>();
            foreach (var wordFrequency in wordFrequencies)
            {
                if (!groupedWordFrequencies.ContainsKey(wordFrequency.Word))
                {
                    groupedWordFrequencies.Add(wordFrequency.Word, new List<WordFrequency>() { wordFrequency });
                }
                else
                {
                    groupedWordFrequencies[wordFrequency.Word].Add(wordFrequency);
                }
            }

            return groupedWordFrequencies;
        }
    }
}
