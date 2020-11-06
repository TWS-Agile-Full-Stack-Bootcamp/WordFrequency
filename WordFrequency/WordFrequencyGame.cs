using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
                try
                {
                    //split the input string with 1 to n pieces of spaces
                    string[] words = Regex.Split(inputStr, @"\s+");

                    List<WordFrequency> wordFrequencies = new List<WordFrequency>();
                    foreach (var word in words)
                    {
                        WordFrequency wordFrequency = new WordFrequency(word, 1);
                        wordFrequencies.Add(wordFrequency);
                    }

                    //get the map for the next step of sizing the same word
                    Dictionary<string, List<WordFrequency>> groupedWordFrequencies = GroupByWord(wordFrequencies);

                    List<WordFrequency> list = new List<WordFrequency>();
                    foreach (var entry in groupedWordFrequencies)
                    {
                        WordFrequency wordFrequency = new WordFrequency(entry.Key, entry.Value.Count);
                        list.Add(wordFrequency);
                    }

                    wordFrequencies = list;

                    wordFrequencies.Sort((w1, w2) => w2.WordCount - w1.WordCount);

                    List<string> strList = new List<string>();

                    //stringJoiner joiner = new stringJoiner("\n");
                    foreach (WordFrequency wordFrequency in wordFrequencies)
                    {
                        string s = wordFrequency.Word + " " + wordFrequency.WordCount;
                        strList.Add(s);
                    }

                    return string.Join("\n", strList.ToArray());
                }
                catch (Exception e)
                {
                    return "Calculate Error";
                }
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
