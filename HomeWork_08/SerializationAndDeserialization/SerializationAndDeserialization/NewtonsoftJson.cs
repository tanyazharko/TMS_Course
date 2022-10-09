using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationAndDeserialization
{
    internal class NewtonsoftJson
    {
        public static string CorrectFileName()
        {
            string? fileName = Console.ReadLine().ToLower();

            if (!string.IsNullOrEmpty(fileName))
            {
                return fileName;
            }
            else
            {
                throw new ArgumentNullException("Name of file is empty!");
            }
        }
        public void Newtonsoft(Shape[] shapes)
        {
            try
            {
                Console.WriteLine("Enter name of file for Newtonsoft serialize ");
                string pathName = CorrectFileName();
                pathName += ".json";

                string pathNewtonsoftSerialize= @$"{pathName}";
                string s = JsonConvert.SerializeObject(shapes);
                File.WriteAllText(pathNewtonsoftSerialize, s);

                Console.WriteLine("Enter name of file for Newtonsoft deserialization ");
                string pathName1 = CorrectFileName();
                pathName1 += ".json";

                string pathNewtonsoftDeserialize = @$"{pathName1}";
                string path = File.ReadAllText(pathNewtonsoftDeserialize);
                Shape[]? newShapes = JsonConvert.DeserializeObject<Shape[]>(path);
            }
            catch
            {
                Console.WriteLine("This file is not found");
            }
        }
    }
}
