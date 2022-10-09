using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationAndDeserialization
{
    class Program
    {
        static void Json(Shape[] shapes, Shape[] shapes1)
        {
            try
            {
                Console.WriteLine("Enter name of file for Json serialize ");
                string forSerialization = CorrectFileName();
                forSerialization += ".json";

                using (FileStream fs = new FileStream(forSerialization, FileMode.OpenOrCreate))
                {
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };

                    JsonSerializer.Serialize(fs, shapes, options);
                }

                Console.WriteLine("Enter name of file for Json deserialization ");
                string forDeserialization = CorrectFileName();
                forDeserialization += ".json";

                using (FileStream fs = new FileStream(forDeserialization, FileMode.OpenOrCreate))
                {
                    shapes1 = JsonSerializer.Deserialize<Shape[]>(fs);
                }
            }
            catch
            {
                Console.WriteLine("This file is not found");
            }
        }

        static void Xml(Shape[] shapes, Shape[] shapes1)
        {
            try
            {
                Console.WriteLine("Enter name of file for Xml serialize ");
                string forSerialization = CorrectFileName();
                forSerialization += ".xml";
                XmlSerializer xml = new XmlSerializer(typeof(Shape[]));

                using (FileStream fs = new FileStream(forSerialization, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, shapes);
                }

                Console.WriteLine("Enter name of file for Xml deserialization ");
                string forDeserialization = CorrectFileName();
                forDeserialization += ".xml";

                using (FileStream fs = new FileStream(forDeserialization, FileMode.OpenOrCreate))
                {
                    shapes1 = (Shape[])xml.Deserialize(fs);
                }
            }
            catch
            {
                Console.WriteLine("This file is not found");
            }
        }

        static string CorrectFileName()
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

        public static string GetChoose()
        {
            Console.WriteLine("Сhoose the appropriate option: Json,XML,Newtonsoft");
            string answer = CorrectFileName();

            return answer;
        }

        static void GetShapes(Shape[] shapes)
        {
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Name: {shape.Name} \n Length: {shape.Length} \n Height: {shape.Height}");
            }
        }

        static void Main()
        {
            Shape square = new Shape(new Point(10, 10), 5, 5, "Square");
            Shape rectangle = new Shape(new Point(10, 10), 5, 10, "Rectangle");

            Shape[] shapes = new Shape[] { square, rectangle };
            Shape[] shapes1 = null;

            NewtonsoftJson newtonsoft = new();

            switch (GetChoose())
            {
                case "json":
                    Json(shapes, shapes1);
                    GetShapes(shapes);
                    break;
                case "xml":
                    Xml(shapes, shapes1);
                    GetShapes(shapes);
                    break;
                case "newtonsoft":
                    newtonsoft.Newtonsoft(shapes);
                    GetShapes(shapes);
                    break;
                default:
                    Console.WriteLine("You need to choice from json,xml,newtonsoft");
                    break;
            }
        }
    }
}