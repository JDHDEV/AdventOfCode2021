using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day3B
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day3.txt");

            string oxygenRatingStr = ProccessList(lines, 0, true);
            string co2RatingStr = ProccessList(lines, 0, false);

            int oxygenRating = Convert.ToInt32(oxygenRatingStr, 2);
            int co2Rating = Convert.ToInt32(co2RatingStr, 2);
            int result = oxygenRating * co2Rating;

            Console.WriteLine("Solution:");
            Console.WriteLine(result);
        }

        private static string ProccessList(string[] list, int index, bool common)
        {
            List<string> ZeroList = new List<string>();
            List<string> OneList = new List<string>();

            foreach (string line in list)
            {
                if (line[index].Equals('0'))
                {
                    ZeroList.Add(line);
                }
                else
                {
                    OneList.Add(line);
                }
            }

            if (common)
            {
                if (OneList.Count >= ZeroList.Count)
                {
                    if (OneList.Count == 1)
                    {
                        return OneList[0];
                    }
                    else
                    {
                        return ProccessList(OneList.ToArray(), index + 1, common);
                    }
                }
                else
                {
                    if (ZeroList.Count == 1)
                    {
                        return ZeroList[0];
                    }
                    else
                    {
                        return ProccessList(ZeroList.ToArray(), index + 1, common);
                    }
                }
            }
            else
            {
                if (ZeroList.Count <= OneList.Count)
                {
                    if (ZeroList.Count == 1)
                    {
                        return ZeroList[0];
                    }
                    else
                    {
                        return ProccessList(ZeroList.ToArray(), index + 1, common);
                    }
                }
                else
                {
                    if (OneList.Count == 1)
                    {
                        return OneList[0];
                    }
                    else
                    {
                        return ProccessList(OneList.ToArray(), index + 1, common);
                    }
                }
            }
        }
    }
}
