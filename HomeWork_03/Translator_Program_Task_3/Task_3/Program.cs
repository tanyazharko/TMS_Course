using System;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, string>()
            {
                ["laptop"] = "ноутбук",
                ["maths"] = "математика",
                ["emptiness"] = "пустота",
                ["friends"] = "друзья",
                ["city"] = "город",
                ["sky"] = "небо",
                ["phone"] = "телефон",
                ["mother"] = "мама",
                ["unicorn"] = "единорог",
                ["pony"] = "пони"
            };

            bool flag = true;

            while (flag)
            {
                Console.Write("Enter a word in english:  ");

                string word = Console.ReadLine();

                if (String.IsNullOrEmpty(word))
                {
                    Console.WriteLine("It is not a word!!");
                }
                else if (dictionary.ContainsKey(word))
                {
                    Console.WriteLine(dictionary[word]);
                }
                else
                {
                    Console.WriteLine("Word not found!!!");
                }

                Console.WriteLine("If you want to close the program click - n,otherwise click -Enter");

                string temp = Console.ReadLine();

                if (temp == "n")
                {
                    flag = false;
                }
            }
        }
    }
}