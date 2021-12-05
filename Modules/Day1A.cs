using System;

namespace AdventOfCode2021.Modules
{
    class Day1A
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day1.txt");
            int[] values = new int[lines.Length];
            int increases = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                values[i] = Int32.Parse(lines[i]);

                if (i > 0)
                {
                    if (values[i] > values[i - 1])
                    {
                        increases++;
                    }
                }
            }

            Console.WriteLine("Solution:");
            Console.WriteLine(increases);
        }
    }
}
