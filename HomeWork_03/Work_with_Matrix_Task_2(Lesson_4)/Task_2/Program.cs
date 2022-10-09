using System;

namespace Task_2
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

        public static int[,] InputArray(int[,] array, int rows, int columns)
        {
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = rand.Next(-100, 100);
                }
            }

            return array;
        }

        public static void PrintArray(int[,] array, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static int MinValue(int[,] array, int rows, int columns)
        {
            int min = array[0, 0];

            for (int i = 1; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (min < array[i, j])
                    {
                        continue;
                    }
                    else
                    {
                        min = array[i, j];
                    }
                }
            }

            return min;
        }

        public static int MaxValue(int[,] array, int rows, int columns)
        {
            int max = array[0, 0];

            for (int i = 1; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (max > array[i, j])
                    {
                        continue;
                    }
                    else
                    {
                        max = array[i, j];
                    }
                }
            }

            return max;
        }

        public static int SumOfElemens(int[,] array, int rows, int columns)
        {
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sum = sum + array[i, j];
                }
            }

            return sum;
        }

        public static double AverageOfElemens(int[,] array, int rows, int columns)
        {
            double sum = SumOfElemens(array, rows, columns);

            double average = sum / (rows * columns);

            return average;
        }

        public static void BubbleSort(int[,] array, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < columns - 1; k++)
                {
                    for (int j = 0; j < columns - 1; j++)
                    {
                        if (array[i, j] < array[i, j + 1])
                        {
                            int temp = array[i, j];
                            array[i, j] = array[i, j + 1];
                            array[i, j + 1] = temp;
                        }
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter the number of rows:  ");
            int rows = Input();

            Console.Write("Enter the number of columns:  ");
            int columns = Input();

            int[,] array = new int[rows, columns];

            InputArray(array, rows, columns);
            Console.WriteLine("Output random array: ");
            PrintArray(array, rows, columns);

            int minValue = MinValue(array, rows, columns);
            Console.WriteLine($"Min value: {minValue} ");

            int maxValue = MaxValue(array, rows, columns);
            Console.WriteLine($"Max value: {maxValue} ");

            int sum = SumOfElemens(array, rows, columns);
            Console.WriteLine($"Sum of elemens: {sum} ");

            double average = AverageOfElemens(array, rows, columns);
            Console.WriteLine($"Average of elemens: {average} ");

            BubbleSort(array, rows, columns);
            Console.WriteLine("Sorted array in descending order: ");
            PrintArray(array, rows, columns);

            Console.ReadKey();
        }
    }
}