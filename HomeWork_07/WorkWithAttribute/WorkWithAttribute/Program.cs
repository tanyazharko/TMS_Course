namespace WorkWithAttribute
{
    internal class Program
    {
        static void GetAccess(Employee employee, AccesLevelType accesLevel)
        {
            Type type = employee.GetType();
            object[] attributes = type.GetCustomAttributes(typeof(AccessLevelAttribute), true);
            bool flag = false;

            foreach (AccessLevelAttribute attribute in attributes)
            {
                if ((int)attribute.type <= (int)accesLevel)
                {
                    flag = true;
                    Console.WriteLine("Your level is approved");
                }
            }

            if (!flag)
            {
                Console.WriteLine("Your level is prohibited");
            }
        }

        static void Main(string[] args)
        {
            Director director = new Director();
            Manager manager = new Manager();
            Worker worker = new Worker();

            GetAccess(director, AccesLevelType.Low);
            GetAccess(manager, AccesLevelType.Average);
            GetAccess(worker, AccesLevelType.High);
            GetAccess(worker, AccesLevelType.Low);
        }
    }
}