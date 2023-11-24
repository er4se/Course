using System;
using System.Threading;

namespace Threads_1
{
                                                                                    //---------------------Программа не совершенна!---------------------//
                                                                                    //Процессору требуется несколько секунд, чтобы запустить все потоки!//
                                                                                    //------------------------------------------------------------------//
    class ChainClass
    {
        object block = new object();                                                //Блокировщик потоков
        static Random random = new Random();                                        //Рандом
        public void Chain(object coordinate)                                        //Функция для вывода одной "капли дождя", получает на вход координату X
        {
            int x = (int)coordinate;                                                //Координата X в плоскости консоли
            int len = random.Next(3, 5);                                            //Случайная длина "капли" (от 3 до 5 в данном случае, при желании можно поменять)
            int eternal_i = random.Next(0, Console.WindowHeight - 1);               //Генерация стартовой точки "капли дождя" по Y
            int diff = 0;                                                           //Функция для сохранения положения хвоста "капли"

            for (int i = eternal_i; i < (Console.WindowHeight); i++)                //Цикл проходит консоль по Y
            {
                lock (block)                                                        //Блокировка для потока
                {
                    int symbolCode = random.Next(0, 26);                            //Генерация кода случайного символа
                    char symbol = (char)('a' + symbolCode);                         //Перевод в char

                    diff = i - len;                                                 //Получение Y координаты для конца "капли"
                    if (diff == 0)                                                  //Стирание конца "капли" в начале консоли (костыль)
                    {
                        Console.ForegroundColor = Console.BackgroundColor;
                        Program.WriteAt(symbol, x, 0);                              //WriteAt - пишет один символ по конкретным координатам (X, Y)
                    }
                    if (diff <= 0)                                                  //Стирание конца "капли" в конце консоли (костыль)
                    {
                        diff = (Console.WindowHeight ) + diff - 1;
                    }

                    Console.ForegroundColor = Console.BackgroundColor;              //Стирание происходит путем присваивания шрифту цвета фона консоли
                    Program.WriteAt(symbol, x, diff);

                    for(int j = 0; j < len; j++)                                    //Темно-зеленый хвост "капли", который занимает большую часть места
                    {                                                               //Потенциально стоит оптимизировать
                        diff = i - j;
                        if (diff < 0)
                        {
                            diff = len + diff;
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Program.WriteAt(symbol, x, diff);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;                   //Зеленый хвост "капли" - занимает одну точку консоли
                    Program.WriteAt(symbol, x, i - 1);

                    Console.ForegroundColor= ConsoleColor.White;                    //Начало "капли" - занимает одну точку консоли
                    Program.WriteAt(symbol, x, i);
                }

                if (i == (Console.WindowHeight - 1))                                //Цикл становиться бесконечным
                {
                    i = 0;
                }
            }
        }
    }


    class Program
    {
        static int origRow;                                                         //Координаты курсора, нужны для работы WriteAt
        static int origCol;
        static public void WriteAt(char s, int x, int y)                            //Пишет символ char s по координатам (X, Y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);                //Переносит курсор на координаты (X, Y)
                Console.Write(s);                                                   //Пишет символ
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            ChainClass chain = new ChainClass();

            ParameterizedThreadStart ChainThread = new ParameterizedThreadStart(chain.Chain);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                new Thread(ChainThread).Start(i);                                  //Генерация потоков для ChainClass.Chain(object c)
            }
        }
    }
}