using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            void WriteIntInDifferentFormats (int number, string[] formats)
            {
                foreach (string format in formats)
                {
                    Console.WriteLine(number.ToString(format));
                }
                Console.WriteLine(Int32.Parse(number.ToString()));
            }

            string[] formatsList = { "C0", "E", "F2", "G", "N", "X" };

            Console.WriteLine("Input first integer: ");
            int firstInt;
            while (!int.TryParse(Console.ReadLine(), out firstInt))
            {
                Console.WriteLine("Input first integer: ");
            }

            Console.WriteLine("Input second integer: ");
            int secondInt;
            while (!int.TryParse(Console.ReadLine(), out secondInt))
            {
                Console.WriteLine("Input second integer: ");
            }

            int result = firstInt / secondInt;

            WriteIntInDifferentFormats(number: result, formats: formatsList);

            Console.ReadKey();
        }
    }
}
