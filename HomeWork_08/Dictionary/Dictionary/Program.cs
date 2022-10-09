namespace Dictionary
{
    class Program
    {
        static void Main()
        {
            ApplicationDictionary<string, string> dict = new ApplicationDictionary<string, string>();

            dict.Add("one", "один");
            dict.Add("two", "два");
            dict.Add("car", "машина");
            dict.ListOfKey();
            Console.WriteLine();
            dict.Remove("car");
            dict.ListOfKey();
            dict.GetValueByKey("one");
        }
    }
}