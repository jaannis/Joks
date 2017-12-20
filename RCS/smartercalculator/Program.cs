using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartercalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            //izveido kalkulatora objektu

            //paprasīt lietotājam ievadīt ievadi
            Console.WriteLine("Please enter darbība");
            string input = Console.ReadLine();

            //1+2+3 skaits ir 5, pēdējā simbola pozīcija ir 4
            // 1+ skaits ir 2 pēdējā pozīcijā ir 1
            int result;
            int counter = 0;
            while(counter < input.Lenght)
            {
                char symbol = input[counter];
                if(symbol == '+')
                {
                    Console.WriteLine("plus");
                }
                else
                {
                    int number;
                    number = Int32.Parse(symbol.ToString());
                    Console.WriteLine("number" + number);
                }
                counter = counter + 1;
                
            }

            Console.ReadLine();

        }
    }
}
