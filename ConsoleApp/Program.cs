using ConsoleApp.Handlers;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> temp = new List<Subject>()
            {
                new Subject() { SubjectId = 1, Title = "Web Development" },
                new Subject() { SubjectId = 2, Title = "Mobile Development" },
            };

            bool choice = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1. JSON Serailization");
                Console.WriteLine("2. XML Serailization");
                Console.WriteLine("3. Binary Serailization");
                Console.WriteLine("#. Press any other key to quit app");
                Console.WriteLine("Enter your choice");
                string Option = Console.ReadLine();

                try
                {
                    string Amount = string.Empty;

                    switch (Option)
                    {
                        case "1":
                            Console.Clear();
                            try
                            {
                                JsonSerializationHandler<Subject> handler = new JsonSerializationHandler<Subject>();
                                string result = handler.Serailize(temp);
                                Console.WriteLine(result);

                                List<Subject> subjects = handler.Deserialize(result);
                                if (subjects != null)
                                {
                                    foreach (var item in subjects)
                                    {
                                        Console.WriteLine($"Id: {item.SubjectId} Title: {item.Title}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case "2":
                            Console.Clear();
                            try
                            {
                                string path = $"{DateTime.Now.Ticks.ToString()}.xml";
                                XmlSerializationHandler<Subject> handler = 
                                    new XmlSerializationHandler<Subject>(path);

                                handler.Serialize(temp);

                                var result = handler.Deserialize();
                                if (result != null)
                                {
                                    foreach (var item in result)
                                    {
                                        Console.WriteLine($"Id: {item.SubjectId} Title: {item.Title}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case "3":
                            Console.Clear();
                            try
                            {
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        default:
                            choice = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            } while (choice == true);

            Console.WriteLine("Thanks!");
        }
    }
}
