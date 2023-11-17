namespace Generics_1
{
    class MyList<T>
    {
        private T[] list;

        public MyList()
        {
            list = new T[0];
        }

        public MyList(int size)
        {
            list = new T[size];
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    if (index >= 0 || index < list.Length)
                        return list[index];
                    else
                        throw new Exception("Неверный индекс массива");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return default(T);
                }
            }
            set
            {
                try
                {
                    if (index >= 0 || index < list.Length)
                        list[index] = value;
                    else
                        throw new Exception("Неверный индекс массива");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Add(T item)
        {
            T[] temp = new T[list.Length + 1];

            int i = 0;
            foreach (T element in list)
            {
                temp[i] = element;
                i++;
            }

            temp[list.Length] = item;

            list = temp;
        }
        
        public int SizeOfMyList()
        {
            return list.Length;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>(2);
            list[0] = 3;
            list[1] = 2;
            list.Add(1);
            
            for(int i = 0; i < list.SizeOfMyList(); i++)
            {
                Console.Write($"{list[i]} ");
            }
        }
    }
}