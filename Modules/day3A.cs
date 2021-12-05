using System;

namespace AdventOfCode2021.Modules
{
    class Day3A
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day3.txt");
            string gammaStr = "";
            string epsilonStr = "";
            int bits = lines[0].Length;
            int[] counts = new int[bits];
            int halflength = lines.Length / 2;

            foreach (string line in lines)
            {
                for (int i = 0; i < bits; i++)
                {
                    if (line[i].Equals('1'))
                    {
                        counts[i] += 1;
                    }
                }
            }

            for (int i = 0; i < bits; i++)
            {
                if (counts[i] > halflength)
                {
                    gammaStr += '1';
                    epsilonStr += '0';
                }
                else
                {
                    gammaStr += '0';
                    epsilonStr += '1';
                }
            }

            int gamma = Convert.ToInt32(gammaStr, 2);
            int epsilon = Convert.ToInt32(epsilonStr, 2);
            int result = gamma * epsilon;

            Console.WriteLine("Solution:");
            Console.WriteLine(result);
        }
    }
}
