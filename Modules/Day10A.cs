using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day10A
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day10.txt");

            int points = 0;

            foreach (string line in lines)
            {
                Stack<char> OpenChunks = new Stack<char>();

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
                                points += 3;
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
                                points += 57;
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
                                points += 1197;
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
                                points += 25137;
                                break;
                            }
                            else
                            {
                                OpenChunks.Pop();
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Solution:");
            Console.WriteLine(points);
        }
    }
}
