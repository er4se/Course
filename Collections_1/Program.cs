using System.Collections;
using System.Collections.Generic;

namespace Collections_1
{
    class MyList<T> : IEnumerable, IEnumerator
    {
        private T[] list;
        int position = -1;

        //Конструктор для известного размера MyList
        public MyList(int numberOfElements)
        {
            list = new T[numberOfElements];
        }

        //Конструктор для неизвестного размера MyList
        public MyList()
        {
            list = new T[0];
        }

        //Индексатор для MyList
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

        //Добавление элемента в MyList
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
        
        //Удаление элемента в MyList
        public void Erase(T item)
        {
            int sizeCount = 0;

            foreach (T element in list)
            {
                if(element.Equals(item)) sizeCount++;
            }

            T[] temp = new T[list.Length - sizeCount];

            int i = 0;
            foreach (T element in list)
            {
                if (!element.Equals(item))
                {
                    temp[i] = element;
                    i++;
                }
            }

            list = temp;
        }

        //Реализация интерфейса IEnumerator
        public object Current
        {
            get
            {
                if (position == -1)
                    throw new ArgumentException();
                return list[position];
            }
        }
        public bool MoveNext()
        {
            if (position < list.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;

        //Реализация интерфейса IEnumerable
        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < list.Length; i++)
            {
                yield return list[i];
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list= new MyList<int>(10);
            
            for(int i = 0; i < 10; i++)
            {
                list[i] = Convert.ToInt32(Console.ReadLine());
            }

            list.Erase(7);

            foreach(int i in list)
            {
                Console.Write(i + " ");
            }
        }
    }
}