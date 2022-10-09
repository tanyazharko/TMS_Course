namespace User.Models
{
    //public record class UserInfo(string Surname,string Name, string Date,string Female);
    public class UserInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public string BirthdayDate { get; set; }
        public string InfoAboutUser { get; set; }

        public UserInfo(string name, string surname, string patronymic, string gender, string birthdayDate, string infoAboutUser)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Gender = gender;
            BirthdayDate = birthdayDate;
            InfoAboutUser = infoAboutUser;
        }

        public override string ToString()
        {
            return $"Name of user: {Name} , Surname: {Surname} , Patronymic: {Patronymic}," +
                $" Gender: {Gender} , Birthday: {BirthdayDate} , InfoAboutUser: {InfoAboutUser}";
        }
    }
}
