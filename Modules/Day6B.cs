using System;
using System.IO;

namespace AdventOfCode2021.Modules
{
    class Day6B
    {
        static Int64[] counts = new Int64[7];
        public static void Run1()
        {
            string fileName = "Day.0.dat";

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                fileStream.WriteByte(0);
            }

            for (int i = 0; i < 256; i++)
            {
                Int64 count = 0;

                string fileNameIn = "Day." + i + ".dat";
                string fileNameOut = "Day." + (i + 1) + ".dat";

                using (FileStream fileStreamIn = new FileStream(fileNameIn, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fileStreamOut = new FileStream(fileNameOut, FileMode.Create))
                    {
                        bool read = true;
                        while (read)
                        {
                            int newByte = fileStreamIn.ReadByte();

                            if (newByte < 0)
                            {
                                read = false;
                            }
                            else if (newByte == 0)
                            {
                                fileStreamOut.WriteByte((byte)6);
                                fileStreamOut.WriteByte((byte)8);
                                count += 2;
                            }
                            else
                            {
                                newByte--;
                                fileStreamOut.WriteByte((byte)newByte);
                                count++;
                            }
                        }

                        Console.Write('.');
                    }
                }

                File.Delete(fileNameIn);

                if (i == 255)
                {
                    File.Delete(fileNameOut);
                }

                if (i == 249)
                {
                    counts[6] = count;
                }

                if (i == 250)
                {
                    counts[5] = count;
                }

                if (i == 251)
                {
                    counts[4] = count;
                }

                if (i == 252)
                {
                    counts[3] = count;
                }

                if (i == 253)
                {
                    counts[2] = count;
                }

                if (i == 254)
                {
                    counts[1] = count;
                }

                if (i == 255)
                {
                    counts[0] = count;
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            string ExampleFishTimers = "3,4,3,1,2";
            Int64 exampleCountTotal = AddCounts(ExampleFishTimers);

            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day6.txt");
            Int64 countTotal = AddCounts(lines[0]);

            Console.WriteLine("Example Solution:");
            Console.WriteLine(exampleCountTotal);
            Console.WriteLine();

            Console.WriteLine("Solution:");
            Console.WriteLine(countTotal);
        }

        static Int64 AddCounts(string fishTimerStrs)
        {
            Int64 countTotal = 0;

            string[] timerStrs = fishTimerStrs.Split(',');

            foreach (string timerStr in timerStrs)
            {
                int timer = Int32.Parse(timerStr);
                countTotal += counts[timer];
            }

            return countTotal;
        }

        public static void Run2()
        {
            string ExampleFishTimers = "3,4,3,1,2";
            Int64 exampleCountTotal = ProcessFishTimers(ExampleFishTimers);

            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day6.txt");
            Int64 countTotal = ProcessFishTimers(lines[0]);

            Console.WriteLine("Example Solution:");
            Console.WriteLine(exampleCountTotal);
            Console.WriteLine();

            Console.WriteLine("Solution:");
            Console.WriteLine(countTotal);
        }

        static Int64 ProcessFishTimers(string fishTimerStrs)
        {
            Int64[] fishTimers = new Int64[9];
            string[] timerStrs = fishTimerStrs.Split(',');
            
            foreach (string timerStr in timerStrs)
            {
                int timer = Int32.Parse(timerStr);
                fishTimers[timer]++;
            }

            for (int i = 0; i < 256; i++)
            {
                Int64 pregnantFish = fishTimers[0];

                for (int j = 0; j < 8; j++)
                {
                    fishTimers[j] = fishTimers[j + 1];
                }

                fishTimers[6] += pregnantFish;
                fishTimers[8] = pregnantFish;
            }

            Int64 countTotal = 0;

            for (int i = 0; i < 9; i++)
            {
                countTotal += fishTimers[i];
            }

            return countTotal;
        }
    }
}