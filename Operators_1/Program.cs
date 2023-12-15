namespace Operators_1
{
    class Block
    {
        public int top = 0,
            bottom = 0,
            left = 0,
            right = 0;

        public Block(int top, int bottom, int left, int right)
        {
            try
            {
                if ((top < 0) || (bottom < 0) || (left < 0) || (right < 0))
                    throw new Exception("Одна из сторон имеет отрицательное значение");

                this.top = top;
                this.bottom = bottom;
                this.left = left;
                this.right = right;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override bool Equals(object otherBlock)
        {
            var block = otherBlock as Block;

            if((this.top == block.top) &&
                (this.bottom == block.bottom) &&
                (this.right == block.right) &&
                (this.left == block.left))
                return true;

            return false;
        }

        public override string ToString()
        {                
            return "Верхнее поле блока: " + this.top.ToString()
                + "\nНижнее поле блока: " + this.bottom.ToString()
                + "\nЛевое поле блока: " + this.left.ToString()
                + "\nПравое поле блока: " + this.right.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int top1 = 20, bottom1 = 20, left1 = 40, right1 = 40;
            int top2 = 20, bottom2 = 20, left2 = 40, right2 = 40;

            var b1 = new Block(top1, bottom1, left1, right1);
            var b2 = new Block(top2, bottom2, left2, right2);

            if (b1.Equals(b2))
            {
                Console.WriteLine("Совпадают!");
            }
            else
                Console.WriteLine("Не совпадают!");

            Console.WriteLine(b1.ToString());
        }
    }
}