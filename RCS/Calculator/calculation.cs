using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class calculation
    {
        public int AskUserForNumber()
        {
            //izvadīt tekstu, kas paprasa ciparu
            Console.WriteLine("Please enter number:");
            //ielasīt ciparu no koncoles
            //izveidot mainīgo, kas glabās tekstu
            int number;
            //ieraksta mainīgājā readline funkcijas skaitli
            string inputText = Console.ReadLine();

            //pārveido lietotāja tekstu par ciparu
            bool success = Int32.TryParse(inputText, out number);
            
            if(success==false)
            {
                Console.WriteLine("Sorry, wrong value entered");
                number = this.AskUserForNumber();
            }

            return number;
        }
    }
}
