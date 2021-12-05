using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Modules
{
    class Day4B
    {
        class BingoNumber
        {
            int value;
            bool marked;
            public BingoNumber(int value)
            {
                this.value = value;
                marked = false;
            }

            public int GetValue()
            {
                return value;
            }

            public bool IsMarked()
            {
                return marked;
            }

            public bool Mark(int newValue)
            {
                if (value == newValue)
                {
                    marked = true;
                    return true;
                }
                return false;
            }
        }

        class BingoBoard
        {
            BingoNumber[,] bingoNumbers = new BingoNumber[5, 5];
            bool bingo = false;

            public BingoBoard(string[] values)
            {
                for (int i = 0; i < 5; i++)
                {
                    string[] rowNumbersStr = values[i].Split(' ');
                    int j = 0;
                    for (int k = 0; k < rowNumbersStr.Length; k++)
                    {
                        if (rowNumbersStr[k] != "")
                        {
                            bingoNumbers[i, j++] = new BingoNumber(Int32.Parse(rowNumbersStr[k]));
                        }
                    }
                }
            }

            public bool IsBingo()
            {
                return bingo;
            }

            public bool Mark(int newValue)
            {
                bool marked = false;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (bingoNumbers[i, j].Mark(newValue))
                        {
                            marked = true;
                        }
                    }
                }

                // Check bingo last because number might be on the card twice.
                if (marked)
                {
                    CheckBingo();
                }

                return bingo;
            }

            public bool CheckBingo()
            {
                for (int i = 0; i < 5; i++)
                {
                    if (bingoNumbers[i, 0].IsMarked() &&
                        bingoNumbers[i, 1].IsMarked() &&
                        bingoNumbers[i, 2].IsMarked() &&
                        bingoNumbers[i, 3].IsMarked() &&
                        bingoNumbers[i, 4].IsMarked())
                    {
                        bingo = true;
                    }

                    if (bingoNumbers[0, i].IsMarked() &&
                        bingoNumbers[1, i].IsMarked() &&
                        bingoNumbers[2, i].IsMarked() &&
                        bingoNumbers[3, i].IsMarked() &&
                        bingoNumbers[4, i].IsMarked())
                    {
                        bingo = true;
                    }
                }

                return bingo;
            }

            public int FindSum()
            {
                int sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!bingoNumbers[i, j].IsMarked())
                        {
                            sum += bingoNumbers[i, j].GetValue();
                        }
                    }
                }

                return sum;
            }
        }

        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\Inputs\Day4.txt");
            string[] numberStrs = lines[0].Split(',');

            List<BingoBoard> BingoBoards = new List<BingoBoard>();

            for (int i = 2; i < lines.Length; i += 6)
            {
                BingoBoards.Add(new BingoBoard(new string[5] { lines[i], lines[i + 1], lines[i + 2], lines[i + 3], lines[i + 4] }));
            }

            int result = 0;

            foreach (string numberStr in numberStrs)
            {
                int number = Int32.Parse(numberStr);

                foreach (BingoBoard bingoBoard in BingoBoards)
                {
                    if (!bingoBoard.IsBingo() && bingoBoard.Mark(number))
                    {
                        result = bingoBoard.FindSum() * number;
                    }
                }
            }

            Console.WriteLine("Solution:");
            Console.WriteLine(result);
        }
    }
}
