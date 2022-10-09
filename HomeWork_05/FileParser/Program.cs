namespace FileParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter filename in format [FileName].[Format]");

            string fileName = Console.ReadLine();

            FileParser fileParser = FileParser.GetParser(fileName);

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Erroy!Try again");
            }
            else
            {
                fileParser.Parse();
            }
        }
    }
}