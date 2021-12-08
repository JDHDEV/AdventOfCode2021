using System;

namespace AdventOfCode2021.Modules
{
    class Day8A
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day8.txt");

            int digits = 0;

            foreach (string line in lines)
            {
                string[] notes = line.Split('|');
                string[] signals = notes[1].Split(' ');

                foreach (string signal in signals)
                {
                    if (signal.Length == 2 ||
                        signal.Length == 3 ||
                        signal.Length == 4 ||
                        signal.Length == 7)
                    {
                        digits++;
                    }
                }
            }

            Console.WriteLine("Solution:");
            Console.WriteLine(digits);
        }
    }
}
