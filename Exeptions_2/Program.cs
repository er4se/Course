namespace Exeptions_2
{
    internal class Program
    {
        struct Price
        {
            public string Name;
            public string Store;
            public int RubelPrice;

            public void Show()
            {
                Console.WriteLine($"Название товара: {Name}\n" +
                    $"Цена: {RubelPrice}");
            }
        }

        static void Main(string[] args)
        {
            Price[] prices = new Price[2];

            for(int i = 0; i < prices.Length; i++)
            {
                var tempPrice = new Price();

                Console.Write("Введите название товара: ");
                tempPrice.Name = Console.ReadLine() + string.Empty;
                Console.Write("Введите название магазина: ");
                tempPrice.Store = Console.ReadLine() + string.Empty;
                Console.Write("Введите цену: ");
                tempPrice.RubelPrice = Convert.ToInt32(Console.ReadLine());

                prices[i] = tempPrice;
                Console.WriteLine();
            }

            storeLabel:

            string Store;
            Console.Write("Введите название магазина: ");
            Store = Console.ReadLine() + string.Empty;

            try
            {
                int f = 0;
                for(int i = 0; i < prices.Length; i++)
                {
                    if (Store == prices[i].Store)
                    {
                        f++;
                        prices[i].Show();
                    }
                }

                if (f == 0)
                    throw new Exception();
            }
            catch
            {
                Console.WriteLine("Не существующее название магазина\n");
                goto storeLabel;
            }

            Console.ReadKey();
        }
    }
}