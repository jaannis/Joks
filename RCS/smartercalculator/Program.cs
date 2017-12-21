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
            math parser;
            parser = new math();

            //paprasīt lietotājam ievadīt ievadi
            Console.WriteLine("Please enter darbība");
            string input = Console.ReadLine();

            //izsauc aprēķināšanas funkciju un saglabā rezultātu
            int result = parser.ParseMath(input);

            //izvada rezultātu uz ekrāna
            Console.WriteLine("Your result" + result);

            Console.ReadLine();

        }
    }
}
