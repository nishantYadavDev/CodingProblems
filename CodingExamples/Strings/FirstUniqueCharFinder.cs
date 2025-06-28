using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Problem: Given a string s, return the index of the first non-repeating character. If none exists, return -1.
//Constraints:
//	• 1 <= s.length <= 10⁵
//	• s contains only lowercase English letters.

namespace CodingExamples.Strings
{

    public class FirstUniqueCharFinder
    {
        private string input;
        private char uniqueChar = '$';
        public const int STRING_MAX_LENGTH = 10000;
        public const int STRING_MIN_LENGTH = 1;
        int[] charFrequencyArray = new int[26];
        public struct ValueIndexPair
        {
            public int index;
            public int value;
            public ValueIndexPair(int index, int value)
            {
                this.index = index;
                this.value = value;
            }
        }
        private Dictionary<char, ValueIndexPair> charFrequencyMap;
        private char[] lowerCaseLetters = Enumerable.Range('a', 26)
                                    .Select(c => (char)c)
                                    .ToArray();
        public FirstUniqueCharFinder(string input)
        {
            if (input == null)
            {
                throw new NullReferenceException();

            }
            if (input.Length < STRING_MIN_LENGTH || input.Length > STRING_MAX_LENGTH)
            {
                throw new LengthOutOfRangeException($"String length is not in Range ", STRING_MIN_LENGTH, STRING_MAX_LENGTH);

            }
            //if numbers are not in specified range then also throw the exception

            if (input.Any(x => !lowerCaseLetters.Contains(x)))
            {
                throw new ArgumentOutOfRangeException($"String Contain a character  that is not in Range {lowerCaseLetters.ToString()}");
            }
            charFrequencyMap = new();
            this.input = input.ToLower();

        }

        public int FindIndexOfUniqueChar()
        {
            for (int i = 0; i < input.Length; i++)
            {
                Char c = input[i];
                if (charFrequencyMap.TryGetValue(c, out ValueIndexPair result))
                {
                    result.value++;
                    result.index = i;
                    charFrequencyMap[c] = result;

                }
                else
                {
                    ValueIndexPair r = new ValueIndexPair(i, 1);

                    if (charFrequencyMap.TryAdd(c, r))
                    {
                        uniqueChar = c;
                    }
                }
            }
            var indexPairDefault = new ValueIndexPair(-1, -1);
            var defaultKeyValuePair = new KeyValuePair<char, ValueIndexPair>('$', indexPairDefault);
            var valueFound = charFrequencyMap.Where(x => x.Value.value == 1).FirstOrDefault(defaultKeyValuePair);
            uniqueChar = valueFound.Key;
            return valueFound.Value.index;
        }
        public int FindIndexOfUniqueCharUsingFixedArray()
        {
            foreach (char c in input)
            {
                charFrequencyArray[c - 'a']++;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (charFrequencyArray[input[i] - 'a'] == 1)
                {
                    uniqueChar = input[i];
                    return i;
                }

            }
            return -1;

        }

        public char GetUniqueChar()
        {
            return uniqueChar;
        }
    }
}
