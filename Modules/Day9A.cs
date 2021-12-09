using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day9A
    {
        struct point
        {
            public int x;
            public int y;
        }
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day9.txt");

            int length = lines.Length;
            int width = lines[0].Length;

            int[,] heightMap = new int[length, width];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    heightMap[i, j] = Int32.Parse(lines[i][j].ToString());
                }
            }

            List<point> lowPointList = new List<point>();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int curHeight = heightMap[i, j];

                    if (i - 1 < 0 || curHeight < heightMap[i - 1, j])
                    {
                        if (i + 1 >= length || curHeight < heightMap[i + 1, j])
                        {
                            if (j - 1 < 0 || curHeight < heightMap[i, j - 1])
                            {
                                if (j + 1 >= width || curHeight < heightMap[i, j + 1])
                                {
                                    point lowPoint = new point();
                                    lowPoint.x = i;
                                    lowPoint.y = j;
                                    lowPointList.Add(lowPoint);
                                }
                            }
                        }
                    }
                }
            }

            int total = 0;

            foreach (point lowPoint in lowPointList)
            {
                total += heightMap[lowPoint.x, lowPoint.y] + 1;
            }

            Console.WriteLine("Solution:");
            Console.WriteLine(total);
        }

    }
}
