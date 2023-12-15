using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_1
{
    class CarModel
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public DateTime ReleaseYear { get; set; } = DateTime.MinValue;

        public CarModel(string Brand, string Model,
            string Color, int ReleaseYear)
        {
            InitializeCar(Brand, Model, Color, ReleaseYear);
        }

        private void InitializeCar(string Brand, string Model,
            string Color, int ReleaseYear)
        {
            this.Brand = Brand + string.Empty;
            this.Model = Model + string.Empty;
            this.Color = Color + string.Empty;

            SetReleaseYear(ReleaseYear);
        }

        private void SetReleaseYear(int year)
        {
            try
            {
                if ((year <= 0) || (year > 2023))
                    throw new Exception("Impossible release date");
                else
                {
                    this.ReleaseYear.AddYears(year);
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Show()
        {
            Console.WriteLine($"Модель {Model}\n" +
                $"Произведена команией {Brand}\n" +
                $"Год выпуска: {ReleaseYear.Year}");
        }
    }
}
