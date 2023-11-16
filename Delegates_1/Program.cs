using System.Windows.Input;

namespace Delegates_1
{
    public delegate void Delegate(int x, int y);

    internal class Program
    {
        static void Main(string[] args)
        {
            Delegate myDelegate = (x, y) => Console.WriteLine("Инициализация");

            var ICommand = "none";
            Console.WriteLine("Введите команду" +
                "(Add, Sub, Mul или Div): ");
            ICommand = Console.ReadLine();

            switch (ICommand)
            {
                case "Add":
                    myDelegate = (x, y) => Console.WriteLine(x + y);
                    break;
                case "Sub":
                    myDelegate = (x, y) => Console.WriteLine(x - y);
                    break;
                case "Mul":
                    myDelegate = (x, y) => Console.WriteLine(x * y);
                    break;
                case "Div":
                    myDelegate = (x, y) =>
                    {
                        if (y != 0)
                            Console.WriteLine(x / y);
                        else Console.WriteLine("Деление на ноль!");
                    };
                    break;
            }

            int x = 2, y = 3;
            myDelegate.Invoke(x, y);
        }
    }
}