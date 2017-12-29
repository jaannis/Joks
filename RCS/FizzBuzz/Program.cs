﻿using System;
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
            //Ievadam konsolē skaitļus
            Console.WriteLine("Ievadi skaitli");
            string input = Console.ReadLine();

            //Pārvēršam to skaitli par int
            int number;
            Int32.TryParse(input, out number);

            //Paņemam no konsoles skaitli un no tā uztaisam range
            IEnumerable<int> skaitlis = Enumerable.Range(1, number);

            //Meklējam Fizus un Buzus
            foreach (int num in skaitlis)
            {

                //Meklējam FizzBuzzu, nezinu kāpēc liek %
                //bet tā daudz kur internetā bija
                if (num % 3 == 0 && num % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }

                //Atrodam Fizu
                else if (num % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }

                //Atrodam Bazu
                else if (num % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }

                //Palaižam pārējos skaitļus
                else
                {
                    Console.WriteLine(num);
                }

            }

            Console.ReadLine();


        }

    }
}
