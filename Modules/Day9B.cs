using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day9B
    {
        struct point
        {
            public int x;
            public int y;
            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
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
                                    point lowPoint = new point(i, j);
                                    lowPointList.Add(lowPoint);
                                }
                            }
                        }
                    }
                }
            }

            List<int> basinSizes = new List<int>();

            foreach (point lowPoint in lowPointList)
            {
                int size = 1;

                int[,] hasChecked = new int[length, width];
                hasChecked[lowPoint.x, lowPoint.y] = 1;

                Stack<point> pointsToTest = new Stack<point>();
                pointsToTest.Push(lowPoint);

                while (pointsToTest.Count > 0)
                {
                    point testPoint = pointsToTest.Pop();
                    int x = testPoint.x;
                    int y = testPoint.y;

                    if (x - 1 >= 0 && hasChecked[x - 1, y] == 0 && heightMap[x - 1, y] != 9)
                    {
                        pointsToTest.Push(new point(x - 1, y));
                        hasChecked[x - 1, y] = 1;
                        size++;
                    }

                    if (x + 1 < length && hasChecked[x + 1, y] == 0 && heightMap[x + 1, y] != 9)
                    {
                        pointsToTest.Push(new point(x + 1, y));
                        hasChecked[x + 1, y] = 1;
                        size++;
                    }

                    if (y - 1 >= 0 && hasChecked[x, y - 1] == 0 && heightMap[x, y - 1] != 9)
                    {
                        pointsToTest.Push(new point(x, y - 1));
                        hasChecked[x, y - 1] = 1;
                        size++;
                    }

                    if (y + 1 < width && hasChecked[x, y + 1] == 0 && heightMap[x, y + 1] != 9)
                    {
                        pointsToTest.Push(new point(x, y + 1));
                        hasChecked[x, y + 1] = 1;
                        size++;
                    }
                }
                basinSizes.Add(size);
            }

            basinSizes.Sort();
            basinSizes.Reverse();

            int total = basinSizes[0] * basinSizes[1] * basinSizes[2];

            Console.WriteLine("Solution:");
            Console.WriteLine(total);
        }
    }
}
