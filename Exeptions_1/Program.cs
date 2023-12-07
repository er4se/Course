namespace Exeptions_1
{
    internal class Program
    {
        struct Worker
        {
            public string FullName;
            public string Position;
            public int Year;
            public int Exp { get; private set; }

            public void setExp()
            {
                Exp = 2023 - Year;
            }

            public void Show()
            {
                Console.WriteLine($"Имя сотрудника: {FullName}\n" +
                    $"Должность: {Position}\n" +
                    $"Стаж: {Exp}");
            }
        }

        static void Main(string[] args)
        {
            Worker[] State = new Worker[5];

            for(int i = 0; i < State.Length; i++)
            {
                var tempWorker = new Worker();

                Console.Write("Введите имя: ");
                tempWorker.FullName = Console.ReadLine() + string.Empty;
                Console.Write("Введите должность: ");
                tempWorker.Position = Console.ReadLine() + string.Empty;

            yearLabel:
                try
                {
                    Console.Write("Введите год поступления: ");
                    tempWorker.Year = Convert.ToInt32(Console.ReadLine());

                    if ((tempWorker.Year > 2023) || (tempWorker.Year < 2003))
                        throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Неверный формат года");
                    goto yearLabel;
                }

                tempWorker.setExp();
                State[i] = tempWorker;

                Console.WriteLine();
            }

            Console.Write("Введите стаж: ");
            int Exp = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < State.Length; i++)
            {
                if (Exp < State[i].Exp)
                    State[i].Show();
            }

            Console.ReadKey();
        }
    }
}