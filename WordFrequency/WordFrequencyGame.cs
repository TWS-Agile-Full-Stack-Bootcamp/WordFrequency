using System;
using System.Collections.Generic;
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
            List<WordFrequency> mergedWordFrequencies = new List<WordFrequency>();
            //get the map for the next step of sizing the same word
            Dictionary<string, List<WordFrequency>> groupedWordFrequencies = GroupByWord(wordFrequencies);

            foreach (var entry in groupedWordFrequencies)
            {
                WordFrequency wordFrequency = new WordFrequency(entry.Key, entry.Value.Count);
                mergedWordFrequencies.Add(wordFrequency);
            }

            mergedWordFrequencies.Sort((w1, w2) => w2.WordCount - w1.WordCount);
            return mergedWordFrequencies;
        }

        private static List<WordFrequency> ParseInputToWordFrequency(string inputStr)
        {
            //split the input string with 1 to n pieces of spaces
            string[] words = Regex.Split(inputStr, @"\s+");

            List<WordFrequency> wordFrequencies = new List<WordFrequency>();
            foreach (var word in words)
            {
                WordFrequency wordFrequency = new WordFrequency(word, 1);
                wordFrequencies.Add(wordFrequency);
            }

            return wordFrequencies;
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
