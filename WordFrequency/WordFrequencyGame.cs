using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string CalculateError = "Calculate Error";

        private const string SpacePatten = @"\s+";

        public string GetResult(string inputStr)
        {
            string[] splitWords = Regex.Split(inputStr, SpacePatten);

            List<Input> inputList = splitWords.Select(word => new Input(word, 1)).ToList();
            //get the map for the next step of sizing the same word
            Dictionary<string, List<Input>> map = GetListMap(inputList);

            List<Input> list = map.Select(keyValuePair => new Input(keyValuePair.Key, keyValuePair.Value.Count)).ToList();

            list.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            List<string> strList = list.Select(item => $"{item.Value} {item.WordCount}").ToList();

            return string.Join("\n", strList.ToArray());
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            return inputList.GroupBy(input => input.Value).ToDictionary(t => t.Key, t => t.ToList());
        }
    }
}