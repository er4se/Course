using System;
using System.Threading;

namespace Threads_1
{
    class ChainClass
    {
        object block = new object();

        static Random random = new Random();
        public void Chain(object coordinate)
        {
            int x = (int)coordinate;
            int len = random.Next(3, 5);
            int eternal_i = random.Next(0, Console.WindowHeight - 1);
            int diff = 0;

            for (int i = eternal_i; i < (Console.WindowHeight - 1); i++)
            {
                lock (block)
                {
                    int symbolCode = random.Next(0, 26);
                    char symbol = (char)('a' + symbolCode);

                    diff = i - len;
                    if (diff < 0)
                    {
                        diff = len + diff;
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                    Program.WriteAt(symbol, x, diff);

                    for(int j = 0; j < len; j++)
                    {
                        diff = i - j;
                        if (diff < 0)
                        {
                            diff = len + diff;
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Program.WriteAt(symbol, x, diff);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Program.WriteAt(symbol, x, i - 1);

                    Console.ForegroundColor= ConsoleColor.White;
                    Program.WriteAt(symbol, x, i);
                    //Thread.Sleep(100);
                }

                if (i == (Console.WindowHeight - 2))
                {
                    i = 0;
                }
            }
        }
    }


    class Program
    {
        static int origRow;
        static int origCol;
        static public void WriteAt(char s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();
            origRow = Console.CursorTop + 1;
            origCol = Console.CursorLeft;

            ChainClass chain = new ChainClass();

            ParameterizedThreadStart ChainThread = new ParameterizedThreadStart(chain.Chain);
            
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                new Thread(ChainThread).Start(i);
            }
        }
    }
}