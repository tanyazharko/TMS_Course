using Microsoft.AspNetCore.Mvc;
using User.Models;
using Newtonsoft.Json;

namespace User.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult ListOfUsers(string button)
        {
            List<UserInfo> users = new List<UserInfo>();
            string[] paths = System.IO.File.ReadAllLines("user.json");

            foreach (var s in paths)
            {
                users.Add(JsonConvert.DeserializeObject<UserInfo>(s));
            }

            return View("ListOfUsers", users);
        }

        [HttpPost]
        public IActionResult GetUserInfo(string button, string userName, string surname, string patronymic, string gender, string birthdayDate, string userinfo)
        {
            UserInfo user = new UserInfo(userName, surname, patronymic, gender, birthdayDate, userinfo);

            using (StreamWriter sw = new StreamWriter("user.json", true))
            {
                string s = JsonConvert.SerializeObject(user);
                sw.WriteLine(s);
            }

            return View("Registration");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
    }
}

