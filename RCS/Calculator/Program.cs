using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // izveido kalkulēšans objektu
            calculation calc;
            calc = new calculation();

            //paprasīt lietotājam vērtību
            int firstNumber = calc.AskUserForNumber();

            //jāpaprasa otra vērtība
            int secondNumber = calc.AskUserForNumber();


            //jāsaskaita
            int result = firstNumber + secondNumber;
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
