using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static Boolean OnBoardCheck(int x)
        {
            if (x > 0 && x < 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static Boolean EndCheck(int[,] x, int[,] final, int z)
        {
            int l;
            for (int i = 0; i < z; i++)
            {
                l = 0;
                for (int n = 0; n < 2; n++)
                {
                    if (x[i, n] == final[0, n])
                    {
                        l++;
                    }
                }
                if (l == 2)
                {
                    return true;
                }

            }
            return false;
        }
        static void PossibleMoves(int[,] start, int[,] end, int[,] Pmov, ref int a)
        {
            // 
            for (int i = 0; i < start.GetLength(0); i++) // the actual "starting move" last thing to change becuase you get 8 subsets from one thing
            {
                for (int g = 0; g < 8; g++) // the set of Pmov being changed. ie set 1 {1, -2}. incriments at the same time as the new end array but resets
                {

                    for (int f = 0; f < 2; f++) // the individual numbers
                    {
                        end[a, f] = start[i, f] + Pmov[g, f];
                        if (OnBoardCheck(end[a, f]) == false)
                        {
                            a--; break;
                        }
                    }
                    a++;
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] start = new int[,] { { 0, 0 } };
            int[,] end = new int[,] { { 0, 0 } };
            do
            {
                Console.WriteLine("Welcome to the Knight Hop program! Enter the coordinates of your knight's current position below to get started.");
                Console.WriteLine();
                Console.Write("Input starting location (X): ");
                start[0, 0] = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Input starting location (Y): ");
                start[0, 1] = Convert.ToInt16(Console.ReadLine());
                if (OnBoardCheck(start[0, 0]) && OnBoardCheck(start[0, 1]))
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, this piece is not on the board");
                }

            } while (true);
            do
            {
                Console.WriteLine();
                Console.Write("Input end location (X): ");
                end[0, 0] = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Input end location (Y): ");
                end[0, 1] = Convert.ToInt16(Console.ReadLine());
                if (OnBoardCheck(end[0, 0]) && OnBoardCheck(end[0, 1]))
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, this location is not on the board");
                }

            } while (true);

            int[,] one = new int[8, 2], two = new int[64, 2], three = new int[512, 2], four = new int[4096, 2], five = new int[32768, 2], six = new int[262144, 2], seven = new int[2097152, 2];
            int oneL = 0, twoL = 0, threeL = 0, fourL = 0, fiveL = 0, sixL = 0, sevenL = 0, blank = 0;
            int[] movesL = { blank, oneL, twoL, threeL, fourL, fiveL, sixL, sevenL };
            int[][,] moves = { start, one, two, three, four, five, six, seven };
            int[,] PossMov = { { 1, 2 }, { 2, 1 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 2, -1 }, { 1, -2 } };


            for (int i = 0; i < 7; i++)
            {
                PossibleMoves(moves[i], moves[i + 1], PossMov, ref movesL[i + 1]);
                if (EndCheck(moves[i + 1], end, movesL[i + 1]))
                {
                    Console.WriteLine();
                    Console.WriteLine("It will take " + (i + 1) + " moves to reach your desired position. Thank you for using the Knight Hop program!");

                    Console.ReadLine();
                    break;
                }
            }




        }
    }
}

