using HomeWork_10.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeWork_10.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult ListOfWorkers(string button)
        {
            List<Worker> worker = new List<Worker>();

            string[] paths = System.IO.File.ReadAllLines("worker.json");

            foreach (var s in paths)
            {
                worker.Add(JsonConvert.DeserializeObject<Worker>(s));
            }

            return View("ListOfWokers", worker);
        }

        [HttpPost]
        public IActionResult GetWorkers(string button,string name, int age, string birthdayDate, string address)
        {
            Worker user = new Worker(name, age, birthdayDate, address);

            using (StreamWriter sw = new StreamWriter("worker.json", true))
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
