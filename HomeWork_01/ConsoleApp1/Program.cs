using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void BubbleSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        static void PrintArray(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; ++i)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        public static void Main()
        {
            int[] array = { 4, 78, 1, 2, 3, 11, 889, 5, 45, 78, 55, 7852, 78999 };

            BubbleSort(array);

            Console.WriteLine("Sorted array: ");
            PrintArray(array);
        }
    }
}