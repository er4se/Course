using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_1
{
    class Costumer
    {
        public string Name { get; set; } = string.Empty;
        public long Number { get; set; } = 0;
        public CarModel Car { get; set; } = null;

        public Costumer(string Name, long Number, CarModel Car)
        {
            InitializeCostumer(Name, Number);
            AddCar(Car);
        }

        public Costumer(string Name, long Number)
        {
            InitializeCostumer(Name, Number);
        }

        private void InitializeCostumer(string Name, long Number)
        {
            this.Name = Name;
            this.Number = Number;
        }

        public void AddCar(CarModel Car)
        {
            if(this.Car == null)
                this.Car = Car;
        }

        public void Show()
        {
            Console.WriteLine($"Покупатель: {Name}");
            Console.WriteLine("Номер телефона: {0:+7(###)###-##-##}", Number);

            Console.WriteLine("\nАвтомобиль:");
            Car.Show();
        }
    }
}
