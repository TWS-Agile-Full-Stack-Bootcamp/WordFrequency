using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            if (Regex.Split(inputStr, @"\s+").Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                try
                {
                    //split the input string with 1 to n pieces of spaces
                    string[] words = Regex.Split(inputStr, @"\s+");

                    List<WordFrequency> wordFrequencies = new List<WordFrequency>();
                    foreach (var word in words)
                    {
                        WordFrequency input = new WordFrequency(word, 1);
                        wordFrequencies.Add(input);
                    }

                    //get the map for the next step of sizing the same word
                    Dictionary<string, List<WordFrequency>> map = GetListMap(wordFrequencies);

                    List<WordFrequency> list = new List<WordFrequency>();
                    foreach (var entry in map)
                    {
                        WordFrequency input = new WordFrequency(entry.Key, entry.Value.Count);
                        list.Add(input);
                    }

                    wordFrequencies = list;

                    wordFrequencies.Sort((w1, w2) => w2.WordCount - w1.WordCount);

                    List<string> strList = new List<string>();

                    //stringJoiner joiner = new stringJoiner("\n");
                    foreach (WordFrequency wordFrequency in wordFrequencies)
                    {
                        string s = wordFrequency.Value + " " + wordFrequency.WordCount;
                        strList.Add(s);
                    }

                    return string.Join("\n", strList.ToArray());
                }
                catch (Exception e)
                {
                    return "Calculate Error";
                }
            }
        }

        private Dictionary<string, List<WordFrequency>> GetListMap(List<WordFrequency> inputList)
        {
            Dictionary<string, List<WordFrequency>> map = new Dictionary<string, List<WordFrequency>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Value))
                {
                    List<WordFrequency> arr = new List<WordFrequency>();
                    arr.Add(input);
                    map.Add(input.Value, arr);
                }
                else
                {
                    map[input.Value].Add(input);
                }
            }

            return map;
        }
    }
}
