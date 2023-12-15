namespace LINQ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Costumer> costumers= new List<Costumer>();

            Console.Write("Введите количество покупателей: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < amount; i++)
            {
                Console.WriteLine("\nВведите данные покупателя (ФИО, номер без восьмерки)");
                string Name = Console.ReadLine() + string.Empty;
                long Number = Convert.ToInt64(Console.ReadLine());

                var tempCost = new Costumer(Name, Number);

                Console.WriteLine("\nВведите данные авто (марка, модель, цвет, год выпуска)");
                string Brand = Console.ReadLine() + string.Empty;
                string Model = Console.ReadLine() + string.Empty;
                string Color = Console.ReadLine() + string.Empty;
                int Year = Convert.ToInt32(Console.ReadLine());

                var tempCar = new CarModel(Brand, Model, Color, Year);

                tempCost.AddCar(tempCar);

                costumers.Add(tempCost);
            }

            Console.Write("\nВведите имя покупателя: ");
            string CostName = Console.ReadLine() + string.Empty;
            Console.WriteLine();

            var query = from costumer in costumers
                        where costumer.Name == CostName
                        select costumer;

            foreach(var costumer in query)
            {
                costumer.Show();
            }
        }
    }
}