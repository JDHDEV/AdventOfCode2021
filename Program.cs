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
                case "day5a":
                    Day5A.Run();
                    break;
                case "day5b":
                    Day5B.Run();
                    break;
                case "day6a":
                    Day6A.Run();
                    break;
                case "day6b":
                    Day6B.Run1();
                    break;
                case "day6b2":
                    Day6B.Run2();
                    break;
                case "day7a":
                    Day7A.Run();
                    break;
                case "day7b":
                    Day7B.Run();
                    break;
                case "day8a":
                    Day8A.Run();
                    break;
                case "day8b":
                    Day8B.Run();
                    break;
                case "day9a":
                    Day9A.Run();
                    break;
                case "day9b":
                    Day9B.Run();
                    break;
                case "day10a":
                    Day10A.Run();
                    break;
                case "day10b":
                    Day10B.Run();
                    break;
                case "day11a":
                    Day11A.Run();
                    break;
                case "day11b":
                    Day11B.Run();
                    break;
                default:
                    Console.WriteLine("Input not recognized.");
                    break;
            }
        }
    }
}
