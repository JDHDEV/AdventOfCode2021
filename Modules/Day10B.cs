using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day10B
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day10.txt");
            List<Int64> socresList = new List<Int64>();

            foreach (string line in lines)
            {
                Stack<char> OpenChunks = new Stack<char>();
                bool corrupt = false;

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].Equals('(') || line[i].Equals('[') || line[i].Equals('{') || line[i].Equals('<'))
                    {
                        OpenChunks.Push(line[i]);
                    }
                    else
                    {
                        if (line[i].Equals(')'))
                        {
                            if (!OpenChunks.Peek().Equals('('))
                            {
                                corrupt = true;
                                break;
                            }
                            else
                            {
                                OpenChunks.Pop();
                            }
                        }
                        else if (line[i].Equals(']'))
                        {
                            if (!OpenChunks.Peek().Equals('['))
                            {
                                corrupt = true;
                                break;
                            }
                            else
                            {
                                OpenChunks.Pop();
                            }
                        }
                        else if (line[i].Equals('}'))
                        {
                            if (!OpenChunks.Peek().Equals('{'))
                            {
                                corrupt = true;
                                break;
                            }
                            else
                            {
                                OpenChunks.Pop();
                            }
                        }
                        else if (line[i].Equals('>'))
                        {
                            if (!OpenChunks.Peek().Equals('<'))
                            {
                                corrupt = true;
                                break;
                            }
                            else
                            {
                                OpenChunks.Pop();
                            }
                        }
                    }
                }

                if (!corrupt && OpenChunks.Count != 0)
                {
                    Int64 score = 0;
                    
                    while (OpenChunks.Count != 0)
                    {
                        score *= 5;

                        char chunk = OpenChunks.Pop();

                        switch (chunk)
                        {
                            case '(':
                                score += 1;
                                break;
                            case '[':
                                score += 2;
                                break;
                            case '{':
                                score += 3;
                                break;
                            case '<':
                                score += 4;
                                break;
                        }
                    }

                    socresList.Add(score);
                }
            }

            socresList.Sort();
            Int64 result = socresList[(socresList.Count / 2)];

            Console.WriteLine("Solution:");
            Console.WriteLine(result);
        }
    }
}
