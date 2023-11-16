namespace Delegates_2
{
    delegate int RandomInt();
    delegate int RandomIntDelegate(params RandomInt[] randoms);

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            RandomInt[] randomInts = new RandomInt[n];

            for(int i = 0; i < n; i++)
            {
                randomInts[i] = () =>
                {
                    Random rand = new Random();
                    int random = rand.Next(0, 100);

                    return random;
                };
            }

            RandomIntDelegate anonymous = delegate (RandomInt[] randoms)
            {
                int count = 0; int sum = 0;
                foreach (RandomInt rand in randoms)
                {
                    int temp = rand.Invoke();
                    sum += temp; count++;
                }

                return sum / count;
            };

            Console.WriteLine(anonymous(randomInts));
        }
    }
}