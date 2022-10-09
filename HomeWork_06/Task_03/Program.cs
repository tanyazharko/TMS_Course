using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task_03
{
    internal class Anagram
    {
        private string sourceWord;
        public Anagram(string sourceWord)
        {
            this.sourceWord = sourceWord;
        }

        public int Candidates { get; set; }

        public string[] FindAnagrams(string[] candidates)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < candidates.Length; i++)
            {
                if (this.sourceWord.Length == candidates[i].Length &&
                    this.sourceWord.ToLower(CultureInfo.CurrentCulture) != candidates[i].ToLower(CultureInfo.CurrentCulture) &&
                    this.IsAnagram(candidates[i]))
                {
                    result.Add(candidates[i]);
                }
            }

            return result.ToArray();
        }

        private bool IsAnagram(string candidate)
        {
            List<char> temp = new List<char>();

            for (int i = 0; i < candidate.Length; i++)
            {
                temp.Add(candidate[i]);
            }

            for (int i = 0; i < this.sourceWord.Length; i++)
            {
                for (int j = 0; j < temp.Count; j++)
                {
                    if (char.ToLower(this.sourceWord[i], CultureInfo.CurrentCulture) == char.ToLower(temp[j], CultureInfo.CurrentCulture))
                    {
                        temp.Remove(temp[j]);
                        break;
                    }
                }
            }

            return temp.Count == 0;
        }

        static void Main(string[] args)
        {
            //string sourceWord = Console.ReadLine();

            //Anagram anagram = new Anagram(sourceWord);

            //string[] stringArray = new string[3];

            //for (int i = 0; i < stringArray.Length; i++)
            //{
            //    stringArray[i] = Console.ReadLine();
            //}
        }
    }
}

// Anagram
//Example 1:
//("master", { "stream", "pigeon", "maters" }, ExpectedResult = { "stream", "maters" })
//("listen", { "enlists", "google", "inlets", "banana" }, ExpectedResult = { "inlets" })

