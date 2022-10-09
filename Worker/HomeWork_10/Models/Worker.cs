namespace HomeWork_10.Models
{
    public class Worker
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string BirthdayDate { get; set; }
        public string Address { get; set; }

        public Worker(string name, int age, string birthdayDate, string address)
        {
            Name = name;
            Age = age;
            BirthdayDate = birthdayDate;
            Address = address;
        }
    }
}
