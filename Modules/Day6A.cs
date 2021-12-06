using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day6A
    {
        class LanternFish
        {
            LanternFishManager lanternFishManager;
            int timer;

            public LanternFish(LanternFishManager lanternFishManager, int timer)
            {
                this.lanternFishManager = lanternFishManager;
                this.timer = timer;
            }

            public void ProcessDay()
            {
                if (timer == 0)
                {
                    timer = 6;
                    lanternFishManager.SpawnNewLanternFish();
                }
                else
                {
                    timer--;
                }
            }
        }

        class LanternFishManager
        {
            List<LanternFish> fishList = new List<LanternFish>();

            public LanternFishManager(int[] fishTimers)
            {
                foreach (int fishTimer in fishTimers)
                {
                    fishList.Add(new LanternFish(this, fishTimer));
                }
            }

            public void ProcessDay()
            {
                // ToArray() so we only loop through the existing fish and not the ones added this loop
                foreach (LanternFish lanternFish in fishList.ToArray())
                {
                    lanternFish.ProcessDay();
                }
            }

            public void SpawnNewLanternFish()
            {
                fishList.Add(new LanternFish(this, 8));
            }

            public int FishCount()
            {
                return fishList.Count;
            }
        }

        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day6.txt");
            string[] fishTimerStrs = lines[0].Split(',');
            int[] fishTimers = new int[fishTimerStrs.Length];

            for(int i=0; i< fishTimerStrs.Length; i++)
            {
                fishTimers[i] = Int32.Parse(fishTimerStrs[i]);
            }

            LanternFishManager lanternFishManager = new LanternFishManager(fishTimers);

            for (int i = 0; i < 80; i++)
            {
                lanternFishManager.ProcessDay();
            }

            int result = lanternFishManager.FishCount();

            Console.WriteLine("Solution:");
            Console.WriteLine(result);
        }
    }
}
