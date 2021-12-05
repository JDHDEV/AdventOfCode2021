using System;

namespace AdventOfCode2021.Modules
{
    class Day1B
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day1.txt");
            int[] values = new int[lines.Length];
            int increases = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                values[i] = Int32.Parse(lines[i]);

                if (i > 2)
                {
                    if ((values[i] + values[i - 1] + values[i - 2]) > (values[i - 1] + values[i - 2] + values[i - 3]))
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
