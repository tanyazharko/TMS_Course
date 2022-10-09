using System;

namespace Lesson_4_Task_1
{
    internal class Program
    {
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

        public static int[] InputArray(int[] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-100, 100);
            }

            return array;
        }

        public static void PrintArray(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; ++i)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        public static int MinValue(int[] array)
        {
            int minArray = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (minArray < array[i])
                {
                    continue;
                }
                else
                {
                    minArray = array[i];
                }
            }

            return minArray;
        }

        public static int MaxValue(int[] array)
        {
            int maxArray = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (maxArray > array[i])
                {
                    continue;
                }
                else
                {
                    maxArray = array[i];
                }
            }

            return maxArray;
        }

        public static int SumOfElemens(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum = sum + array[i];
            }

            return sum;
        }

        public static double AverageOfElemens(int[] array)
        {
            double sum = SumOfElemens(array);

            double average = sum / array.Length;

            return average;
        }

        public static void BubbleSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }

                array[j + 1] = key;
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter the number of element in the array:  ");

            int count = Input();
            int[] array = new int[count];

            InputArray(array);
            Console.Write("Output random array: ");
            PrintArray(array);

            int minValue = MinValue(array);
            Console.WriteLine($"Min value: {minValue} ");

            int maxValue = MaxValue(array);
            Console.WriteLine($"Max value: {maxValue} ");

            int sum = SumOfElemens(array);
            Console.WriteLine($"Sum of elemens: {sum} ");

            double average = AverageOfElemens(array);
            Console.WriteLine($"Average of elemens: {average} ");

            BubbleSort(array);
            Console.WriteLine("Sorted array in descending order: ");
            PrintArray(array);

            InsertionSort(array);
            Console.WriteLine("Sorted array in ascending order: ");
            PrintArray(array);

            Console.ReadKey();
        }
    }
}