using System.IO;
using System.Threading.Tasks;

namespace AwaitAndAsync
{
    internal class Program
    {
        public static int Input()
        {
            string temp = Console.ReadLine();
            int i = 0;

            while (!int.TryParse(temp, out i))
            {
                Console.WriteLine("It is not number! Please,enter a number!");
                temp = Console.ReadLine();
            }

            return i;
        }

        async static Task GetCharAsync(char temp)
        {
            Console.WriteLine("Enter count of iterations: ");
            int n = Input();

            await Task.Run(()=>
            {
                for (int i = 1; i <= n; i++)
                {
                    Thread.Sleep(4000);
                    Console.WriteLine($"Symbol:{temp},count of operations: {n},step: {i}");
                }
            });
        }

        static async Task WriteFileAsync(string file, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                await outputFile.WriteAsync(content);
            }
        }

        async static Task Main(string[] args)
        {

            var temp1 = GetCharAsync('4');
            var temp2 = GetCharAsync('a');
            var temp3 = GetCharAsync('$');

            await Task.WhenAll(temp1, temp2, temp3);

            //string filePath = "Write.txt";
            //string text = $"Hello World";

            //Task asyncTask = WriteFileAsync(filePath, text);

            //Task task = asyncTask.ContinueWith(t => Console.WriteLine($"The file has been written: {t.IsCompleted}"));

            //task.Wait();
        }
    }
}