using System;

namespace AdventOfCode2021.Modules
{
    class Day5B
    {
        class LineSegment
        {
            public int x1, y1, x2, y2;

            public LineSegment() { }

            public bool IsHorizontal()
            {
                return (y1 == y2);
            }

            public bool IsVertical()
            {
                return (x1 == x2);
            }

            public int DeltaX()
            {
                return x2 - x1;
            }

            public int DeltaY()
            {
                return y2 - y1;
            }
        }

        class VentDiagram
        {
            int[,] diagram;

            public VentDiagram(int x, int y)
            {
                diagram = new int[x, y];
            }

            public void PlotLineSegment(LineSegment lineSegment)
            {
                if (lineSegment.IsHorizontal())
                {
                    int y = lineSegment.y1;
                    if (lineSegment.DeltaX() >= 0)
                    {
                        for (int x = lineSegment.x1; x <= lineSegment.x2; x++)
                        {
                            diagram[x, y]++;
                        }
                    }
                    else
                    {
                        for (int x = lineSegment.x1; x >= lineSegment.x2; x--)
                        {
                            diagram[x, y]++;
                        }
                    }
                }
                else if (lineSegment.IsVertical())
                {
                    int x = lineSegment.x1;
                    if (lineSegment.DeltaY() >= 0)
                    {
                        for (int y = lineSegment.y1; y <= lineSegment.y2; y++)
                        {
                            diagram[x, y]++;
                        }
                    }
                    else
                    {
                        for (int y = lineSegment.y1; y >= lineSegment.y2; y--)
                        {
                            diagram[x, y]++;
                        }
                    }
                }
                else
                {
                    if (lineSegment.DeltaX() >= 0)
                    {
                        if (lineSegment.DeltaY() >= 0)
                        {
                            int x = lineSegment.x1;
                            int y = lineSegment.y1;
                            for (; x <= lineSegment.x2 && y <= lineSegment.y2; y++, x++)
                            {
                                diagram[x, y]++;
                            }
                        }
                        else
                        {
                            int x = lineSegment.x1;
                            int y = lineSegment.y1;
                            for (; x <= lineSegment.x2 && y >= lineSegment.y2; y--, x++)
                            {
                                diagram[x, y]++;
                            }
                        }
                    }
                    else
                    {
                        if (lineSegment.DeltaY() >= 0)
                        {
                            int x = lineSegment.x1;
                            int y = lineSegment.y1;
                            for (; x >= lineSegment.x2 && y <= lineSegment.y2; y++, x--)
                            {
                                diagram[x, y]++;
                            }
                        }
                        else
                        {
                            int x = lineSegment.x1;
                            int y = lineSegment.y1;
                            for (; x >= lineSegment.x2 && y >= lineSegment.y2; y--, x--)
                            {
                                diagram[x, y]++;
                            }
                        }
                    }
                }
            }

            public int CountOverlaps()
            {
                int overlaps = 0;
                for (int i = 0; i < diagram.GetLength(0); i++)
                {
                    for (int j = 0; j < diagram.GetLength(1); j++)
                    {
                        if (diagram[i, j] > 1)
                        {
                            overlaps++;
                        }
                    }
                }

                return overlaps;
            }
        }

        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day5.txt");
            int largeX = 0;
            int LargeY = 0;

            LineSegment[] lineSegments = new LineSegment[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] vertices = lines[i].Split(' ');
                string[] v1 = vertices[0].Split(',');
                string[] v2 = vertices[2].Split(',');

                lineSegments[i] = new LineSegment();
                lineSegments[i].x1 = Int32.Parse(v1[0]);
                lineSegments[i].y1 = Int32.Parse(v1[1]);
                lineSegments[i].x2 = Int32.Parse(v2[0]);
                lineSegments[i].y2 = Int32.Parse(v2[1]);

                if (lineSegments[i].x1 > largeX)
                {
                    largeX = lineSegments[i].x1;
                }

                if (lineSegments[i].y1 > LargeY)
                {
                    LargeY = lineSegments[i].y1;
                }

                if (lineSegments[i].x2 > largeX)
                {
                    largeX = lineSegments[i].x2;
                }

                if (lineSegments[i].y2 > LargeY)
                {
                    LargeY = lineSegments[i].y2;
                }
            }

            VentDiagram ventDiagram = new VentDiagram(largeX + 1, LargeY + 1);

            foreach (LineSegment lineSegment in lineSegments)
            {
                ventDiagram.PlotLineSegment(lineSegment);
            }
            
            int result = ventDiagram.CountOverlaps();

            Console.WriteLine("Solution:");
            Console.WriteLine(result);
        }
    }
}
