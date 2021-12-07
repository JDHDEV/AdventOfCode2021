using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day7A
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day7.txt");
            string[] crabPosStr = lines[0].Split(',');
            int[] crabPos = new int[crabPosStr.Length];

            for (int i = 0; i < crabPosStr.Length; i++)
            {
                crabPos[i] = Int32.Parse(crabPosStr[i]);
            }

            List<int> crabPosList = new List<int>(crabPos);
            crabPosList.Sort();

            int largestCrab = crabPosList[crabPosList.Count - 1];
            int smallestFuel = Int32.MaxValue;
            for (int i = 0; i <= largestCrab; i++)
            {
                int fuel = 0;

                foreach (int crab in crabPosList)
                {
                    fuel += Math.Abs(crab - i);
                }

                if (fuel < smallestFuel)
                {
                    smallestFuel = fuel;
                }
            }
            
            Console.WriteLine("Solution:");
            Console.WriteLine(smallestFuel);
        }
    }
}
