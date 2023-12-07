using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions_additional_3
{
    internal class Calculator
    {
        public int x { get; set; }
        public int y { get; set; }

        public int Add()
        {
            return x + y;
        }

        public int Sub()
        {
            return x - y;
        }

        public int Mul()
        {
            return x * y;
        }

        public int Div()
        {
            try
            {
                int c = x / y;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                y = 1;
            }

            return x / y;
        }
    }
}
