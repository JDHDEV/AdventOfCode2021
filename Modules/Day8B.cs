using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Modules
{
    class Day8B
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day8.txt");

            int total = 0;

            foreach (string line in lines)
            {
                char a = ' ';
                char b = ' ';
                char c = ' ';
                char d = ' ';
                char e = ' ';
                char f = ' ';
                char g = ' ';

                string[] notes = line.Split('|');
                List<string> signals = new List<string>(notes[0].Split(' '));
                signals.Remove("");

                string[] numbers = new string[10];

                foreach (string signal in signals.ToArray())
                {
                    if (signal.Length == 2)
                    {
                        numbers[1] = signal;
                        signals.Remove(signal);
                    }

                    if (signal.Length == 3)
                    {
                        numbers[7] = signal;
                        signals.Remove(signal);
                    }

                    if (signal.Length == 4)
                    {
                        numbers[4] = signal;
                        signals.Remove(signal);
                    }

                    if (signal.Length == 7)
                    {
                        numbers[8] = signal;
                        signals.Remove(signal);
                    }
                }

                foreach (char s in numbers[7])
                {
                    if (!numbers[1].Contains(s))
                    {
                        a = s;
                    }
                }

                foreach (string signal in signals.ToArray())
                {
                    if (signal.Length == 6)
                    {
                        if (StrContains(signal, numbers[4]))
                        {
                            numbers[9] = signal;
                            signals.Remove(signal);
                        }
                        else
                        {
                            int contains = 0;

                            if (signal.Contains(numbers[1][0]))
                            {
                                contains++;
                            }

                            if (signal.Contains(numbers[1][1]))
                            {
                                contains++;
                            }

                            if (contains == 1)
                            {
                                numbers[6] = signal;
                                signals.Remove(signal);
                            }
                        }
                    }
                }

                c = Difference(numbers[7], numbers[6])[0];

                foreach (char s in numbers[7])
                {
                    if (s != a && s != c)
                    {
                        f = s;
                    }
                }

                foreach (string signal in signals.ToArray())
                {
                    if (signal.Length == 5)
                    {
                        if (signal.Contains(a) && signal.Contains(c) && signal.Contains(f))
                        {
                            numbers[3] = signal;
                            signals.Remove(signal);
                        }
                    }
                }

                b = Difference(numbers[4], numbers[3])[0];

                foreach (char s in numbers[4])
                {
                    if (numbers[3].Contains(s) && s != c && s != f)
                    {
                        d = s;
                    }
                }

                foreach (char s in numbers[3])
                {
                    if (s != a && s != c && s != d && s != f)
                    {
                        g = s;
                    }
                }

                foreach (char s in numbers[8])
                {
                    if (s != a && s != b && s != c && s != d && s != e && s != f)
                    {
                        e = s;
                    }
                }

                foreach (string signal in signals.ToArray())
                {
                    if (signal.Length == 5)
                    {
                        if (StrEquals(signal, ("" + a + c + d + e + g)))
                        {
                            numbers[2] = signal;
                            signals.Remove(signal);
                        }

                        if (StrEquals(signal, ("" + a + b + d + f + g)))
                        {
                            numbers[5] = signal;
                            signals.Remove(signal);
                        }
                    }

                    if (signal.Length == 6)
                    {
                        if (StrEquals(signal, ("" + a + b + c + e + f + g)))
                        {
                            numbers[0] = signal;
                            signals.Remove(signal);
                        }
                    }
                }

                string[] finalSignals = notes[1].Split(' ');
                int mult = 1000;
                int value = 0;

                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 10; j++)
                    {
                        if (StrEquals(finalSignals[i], numbers[j]))
                        {
                            value += mult * j;
                            continue;
                        }
                    }

                    mult = mult / 10;
                }

                total += value;
            }

            Console.WriteLine("Solution:");
            Console.WriteLine(total);
        }

        static bool StrEquals(string a, string b)
        {
            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (!a.Contains(b[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        static bool StrContains(string a, string b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (!a.Contains(b[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static string Difference(string a, string b)
        {
            string diff = "";
            foreach (char c in a)
            {
                if (!b.Contains(c))
                {
                    diff += c;
                }
            }
            return diff;
        }
    }
}
