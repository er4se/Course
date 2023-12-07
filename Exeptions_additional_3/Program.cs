namespace Exeptions_additional_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Calc = new Calculator();

            Console.Write("X: ");
            Calc.x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y: ");
            Calc.y = Convert.ToInt32(Console.ReadLine());

            char Command = Console.ReadKey().KeyChar;
            int result = 0;

            switch(Command)
            {
                case '+':
                    result = Calc.Add();
                    break;
                case '-':
                    result = Calc.Sub();
                    break;
                case '*':
                    result = Calc.Mul();
                    break;
                case '/':
                    result = Calc.Div();
                    break;
            }

            Console.WriteLine($"Результат: {result}");
        }
    }
}