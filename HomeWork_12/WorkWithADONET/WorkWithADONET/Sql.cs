using Microsoft.AspNetCore.Mvc.RazorPages;
using NodaTime;
using Npgsql;
using System.Reflection;
using System.Xml.Linq;
using WorkWithADONET;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WorkWithADONET
{
    public class Sql
    {
        NpgsqlConnection connection;
        private const string TABLE_NAME = "Users";

        public Sql()
        {
            connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=CourseWork;Username=postgres;Password=123");
            connection.Open();
        }

        public async Task Add(User user)
        {
            string commandText = $"INSERT INTO {TABLE_NAME} (id,Username, Name, Gender, DateOfBirth, Age,Weight,Height) VALUES (@id, @username,@name, @gender, @dateOfBirth, @age, @weight, @height)";
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id", user.Id);
                cmd.Parameters.AddWithValue("username", user.Username);
                cmd.Parameters.AddWithValue("name", user.Name);
                cmd.Parameters.AddWithValue("gender", user.Gender);
                cmd.Parameters.AddWithValue("dateOfBirth", user.DateOfBirth);
                cmd.Parameters.AddWithValue("age", user.Age);
                cmd.Parameters.AddWithValue("weight", user.Weight);
                cmd.Parameters.AddWithValue("height", user.Height);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<User> Get(int id)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE ID = @id";

            await using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id", id);

                await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        User user = ReadUser(reader);
                        return user;
                    }
            }
            return null;
        }

        private static User ReadUser(NpgsqlDataReader reader)
        {
            int? id = reader["id"] as int?;
            string username = reader["username"] as string;
            string name = reader["name"] as string;
            string gender = reader["gender"] as string;
            LocalDate? dateOfBirth = reader["dateOfBirth"] as LocalDate?;
            int? age = reader["age"] as int?;
            decimal? weight = reader["weight"] as decimal?;
            decimal? height = reader["height"] as decimal?;

            User user = new User
            {
                Id = id.Value,
                Username = username,
                Name = name,
                Gender = gender,
                DateOfBirth = dateOfBirth.Value,
                Age = age.Value,
                Weight = weight.Value,
                Height = height.Value
            };
            return user;
        }

        public async Task Update(int id, User user)
        {
            var commandText = $@"UPDATE {TABLE_NAME}
                SET Username = @username, Name = @name, Gender = @gender, DateOfBirth = @dateOfBirth, Age = @age, Weight = @weight, Height = @height
                WHERE id = @id
        ";

            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id", user.Id);
                cmd.Parameters.AddWithValue("username", user.Username);
                cmd.Parameters.AddWithValue("name", user.Name);
                cmd.Parameters.AddWithValue("gender", user.Gender);
                cmd.Parameters.AddWithValue("dateOfBirth", user.DateOfBirth);
                cmd.Parameters.AddWithValue("age", user.Age);
                cmd.Parameters.AddWithValue("weight", user.Weight);
                cmd.Parameters.AddWithValue("height", user.Height);
               
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task Delete(int id)
        {
            string commandText = $"DELETE FROM {TABLE_NAME} WHERE ID=(@p)";
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("p", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}

//using (CourseWorkContext db = new CourseWorkContext())
//{
//    User user1 = new User { Username = "Tom11112", Name = "Tom", Gender = "Male", Age = 33, Weight = 90, Height = 189 };

//    db.Users.Add(user1);
//    db.SaveChanges();
//}

//using (CourseWorkContext db = new CourseWorkContext())
//{
//    var users = db.Users.ToList();
//    Console.WriteLine("Users list:");

//    foreach (User u in users)
//    {
//        Console.WriteLine($"{u.Username}.{u.Name} - {u.Age}");
//    }
//}

//using (CourseWorkContext db = new CourseWorkContext())
//{
//    User user = db.Users.FirstOrDefault();

//    if (user != null)
//    {
//        user.Username = "Bob_1121";
//        user.Name = "Bob";
//        user.Gender = "Male";
//        user.Age = 33;
//        user.Weight = 90;
//        user.Height = 189;

//        db.SaveChanges();
//    }
//}

//using (CourseWorkContext db = new CourseWorkContext())
//{
//    User user = db.Users.FirstOrDefault();

//    if (user != null)
//    {
//        db.Users.Remove(user);
//        db.SaveChanges();
//    }
//}
