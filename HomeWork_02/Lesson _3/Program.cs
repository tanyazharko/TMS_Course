using System;

namespace Lesson_3
{
    internal class Program
    {
        public static void Swap1(ref int x, ref int y)
        {
            x = x + y;
            y = x - y;
            x = x - y;
        }

        public static void Swap2(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void Swap3(ref int x, ref int y)
        {
            (x, y) = (y, x);
        }

        public static void Comparation(int a, int b)
        {
            if (a == b)
            {
                Console.WriteLine($"{a} = {b}");
            }
            else if (a > b)
            {
                Console.WriteLine($"{a} > {b}");
            }
            else if (a < b)
            {
                Console.WriteLine($"{a} < {b}");
            }
        }

        public static int Input()
        {
            string temp = Console.ReadLine();

            if (!int.TryParse(temp, out int i))
            {
                while (!int.TryParse(temp, out i))
                {
                    Console.WriteLine("It is not number! Please,enter a number!");
                    temp = Console.ReadLine();
                }
            }

            return i;
        }

        public static bool IsPalindromic(int number)
        {
            int temp = number;
            int reverseNumber = 0;

            while (temp > 0)
            {
                reverseNumber = (reverseNumber * 10) + (temp % 10);
                temp /= 10;
            }

            return reverseNumber == number;
        }

        public static void Main()
        {
            //Task_1
            Console.Write("Enter first number = ");
            int firstNumber = Input();
            Console.Write("Enter second number = ");
            int secondNumber = Input();

            Console.WriteLine($" {firstNumber}  {secondNumber}");
            Swap1(ref firstNumber, ref secondNumber);
            Console.WriteLine($" {firstNumber}  {secondNumber}");


            //Task_2
            bool flag = true;

            while (flag)
            {
                Console.Write("Enter first number = ");
                int firstNumber1 = Input();

                Console.Write("Enter second number = ");
                int secondNumber1 = Input();

                Comparation(firstNumber1, secondNumber1);

                Console.WriteLine("If you want to close the program click - n,otherwise click -Enter");
                string temp = Console.ReadLine();

                if (temp == "n")
                {
                    flag = false;
                }
            }

            ////Task_3
            Console.Write("Enter number: ");
            int number = Input();

            if (IsPalindromic(number))
            {
                Console.WriteLine("The number is a palindrome");
            }
            else
            {
                Console.WriteLine("The number is not a palindrome");
            }
        }
    }
}