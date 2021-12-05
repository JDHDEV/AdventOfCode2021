using System;
using AdventOfCode2021.Modules;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.Write("Enter puzzle to run: ");
                HandleInput(Console.ReadLine());

                Console.WriteLine();
                Console.Write("Continue? (y/n): ");
                string input = Console.ReadLine();

                if (!input.ToLower().Equals("y"))
                {
                    exit = true;
                }
            } while (!exit);
        }

        private static void HandleInput(string input)
        {
            switch (input.ToLower())
            {
                case "day1a":
                    Day1A.Run();
                    break;
                case "day1b":
                    Day1B.Run();
                    break;
                case "day2a":
                    Day2A.Run();
                    break;
                case "day2b":
                    Day2B.Run();
                    break;
                case "day3a":
                    Day3A.Run();
                    break;
                case "day3b":
                    Day3B.Run();
                    break;
                case "day4a":
                    Day4A.Run();
                    break;
                case "day4b":
                    Day4B.Run();
                    break;

                default:
                    Console.WriteLine("Input not recognized.");
                    break;
            }
        }
    }
}
