namespace Time
{
    class Program
    {
        static void PrintTime(object temp)
        {
            Console.Clear();
            Console.WriteLine("Сurrent time: " + DateTime.Now.ToLongTimeString());
        }

        static void Main()
        {
            TimerCallback timeCB = new TimerCallback(PrintTime);
            Timer time = new Timer(timeCB, null, 0, 1000);

            Console.ReadLine();
        }
    }
}