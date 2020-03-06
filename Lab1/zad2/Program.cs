using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            long intNumber = 5;
            long longNumber = Int64.MaxValue;

            try
            {
                intNumber = longNumber + intNumber;
            }
            catch (System.OverflowException e)
            {
                Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
            }

            Console.ReadKey();
        }
    }
}
