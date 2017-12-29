using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksperments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ievadi skaitli");
            string input = Console.ReadLine();


            int number;
            Int32.TryParse(input, out number);

            IEnumerable<int> skaitlis = Enumerable.Range(1, number);

            foreach (int num in skaitlis)
            {
                if (num % 3 == 0 && num % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }

                else if (num % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }

                else if (num % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(num);
                }

            }

            Console.ReadLine();


        }

    }
}
