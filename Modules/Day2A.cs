using System;

namespace AdventOfCode2021.Modules
{
    class Day2A
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day2.txt");
            int horizontal = 0;
            int depth = 0;

            foreach (string line in lines)
            {
                string[] values = line.Split(' ');
                int change = Int32.Parse(values[1]);

                switch (values[0].ToLower())
                {
                    case "forward":
                        horizontal += change;
                        break;
                    case "up":
                        depth -= change;
                        break;
                    case "down":
                        depth += change;
                        break;
                }
            }

            int result = horizontal * depth;

            Console.WriteLine("Solution:");
            Console.WriteLine(result);
        }
    }
}
