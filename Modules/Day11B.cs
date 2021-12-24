using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day11B
    {
        struct point
        {
            public int x;
            public int y;
        }

        static int[,] energyLevels;
        static Queue<point> flashQueue;
        static int[,] flashed;

        static void Test(int x, int y)
        {
            if ((flashed[x, y] == 0) && ((++energyLevels[x, y]) > 9))
            {
                point flashPoint = new point();
                flashPoint.x = x;
                flashPoint.y = y;
                flashQueue.Enqueue(flashPoint);
                flashed[x, y] = 1;
            }
        }

        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day11.txt");

            energyLevels = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    energyLevels[i, j] = Int32.Parse(lines[i][j].ToString());
                }
            }

            int steps = 0;
            bool allFlashed = false;

            while (!allFlashed)
            {
                steps++;

                flashQueue = new Queue<point>();
                flashed = new int[10, 10];

                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        Test(x, y);
                    }
                }

                while (flashQueue.Count > 0)
                {
                    point flashPoint = flashQueue.Dequeue();

                    if ((flashPoint.x - 1 >= 0) && (flashPoint.y - 1 >= 0))
                    {
                        Test(flashPoint.x - 1, flashPoint.y - 1);
                    }

                    if (flashPoint.y - 1 >= 0)
                    {
                        Test(flashPoint.x, flashPoint.y - 1);
                    }

                    if ((flashPoint.x + 1 <= 9) && (flashPoint.y - 1 >= 0))
                    {
                        Test(flashPoint.x + 1, flashPoint.y - 1);
                    }


                    if ((flashPoint.x - 1 >= 0))
                    {
                        Test(flashPoint.x - 1, flashPoint.y);
                    }

                    if ((flashPoint.x + 1 <= 9))
                    {
                        Test(flashPoint.x + 1, flashPoint.y);
                    }


                    if ((flashPoint.x - 1 >= 0) && (flashPoint.y + 1 <= 9))
                    {
                        Test(flashPoint.x - 1, flashPoint.y + 1);
                    }

                    if (flashPoint.y + 1 <= 9)
                    {
                        Test(flashPoint.x, flashPoint.y + 1);
                    }

                    if ((flashPoint.x + 1 <= 9) && (flashPoint.y + 1 <= 9))
                    {
                        Test(flashPoint.x + 1, flashPoint.y + 1);
                    }
                }

                bool notFlashed = false;
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (energyLevels[x, y] > 9)
                        {
                            energyLevels[x, y] = 0;
                        }

                        if (flashed[x, y] == 0)
                        {
                            notFlashed = true;
                        }
                    }
                }

                if (!notFlashed)
                {
                    allFlashed = true;
                }
            }

            Console.WriteLine("Solution:");
            Console.WriteLine(steps);
        }
    }
}
